using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using Fiddler;
using FiddlerCore;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using DxComOperate;

namespace repeat
{

    public class HttpParam
    { 
        public static void SendSession(Session oSession, bool bAsync = true)
        {
            DxWinHttp http = new DxWinHttp();
            http.Open(oSession.RequestMethod, oSession.fullUrl, bAsync);
            
            if(AllPlayers.bSetProxy)
                http.SetProxy(2, "127.0.0.1:8888", "0");
            
            for (int i = 0; i < oSession.RequestHeaders.Count(); ++i)
            {
                http.SetRequestHeader(oSession.RequestHeaders[i].Name, oSession.RequestHeaders[i].Value);
            }
            http.Send(oSession.GetRequestBodyAsString());
        }
    };

    public class Player
    {
        public int nStartIndex = 0;
        public List<Session> listSession = new List<Session>();
        public Thread thread;

        void WaitToStart(int nSecInAdvance = 0)
        {
            DateTime dtStartTime = AllPlayers.dtStartTime.AddSeconds(-1.0f * nSecInAdvance);

            // wait start time
            while ((DateTime.Now < dtStartTime))
            {
                if ((dtStartTime - DateTime.Now).TotalMilliseconds > 60000)
                    Thread.Sleep(60000);
                else if ((dtStartTime - DateTime.Now).TotalMilliseconds > 1000)
                    Thread.Sleep(1000);
                else if ((dtStartTime - DateTime.Now).TotalMilliseconds > 50)
                    Thread.Sleep(50);
                else
                    Thread.Sleep(1);
            }
        }

        
        public void Run()
        {
            if (!AllPlayers.bRepeat)
            {
                WaitToStart();
                Program.form1.richTextBoxStatus_AddString(string.Format("{0}-{1}开始发送\n", nStartIndex, nStartIndex + listSession.Count() - 1));
                foreach (Session session in listSession)
                {
                    HttpParam.SendSession(session);    
                }
                Program.form1.richTextBoxStatus_AddString(string.Format("{0}-{1}发送完成\n", nStartIndex, nStartIndex + listSession.Count() - 1));
            }
            else 
            {
                WaitToStart();

                Program.form1.richTextBoxStatus_AddString(string.Format("{0}-{1}开始发送\n", nStartIndex, nStartIndex + listSession.Count() - 1));
                int nIndex = 0;
                int nCount = listSession.Count();
                while (DateTime.Now <= AllPlayers.dtEndTime)
                {
                    HttpParam.SendSession(listSession[nIndex % nCount]);
                    nIndex++;
                    if (nIndex % nCount == 0)
                    {
                        Program.form1.richTextBoxStatus_AddString(string.Format("{0}-{1}发送完第{2}轮\n", nStartIndex, nStartIndex + listSession.Count() - 1, (int)(nIndex / nCount)));
                    }
                }
            }
        }
    };

    class AllPlayers
    {
        public static bool bSetProxy = false;
        public static bool bRepeat = false;
        public static int nThreadNum;
        public static DateTime dtStartTime;
        public static DateTime dtEndTime;
        public static string strSazFile = @"";

        public static string strConfigFileName;
        public static string strWhiteListFileName;
        public static String strBlackListFileName;
        public static String strSazFileName;

        public static List<Session> listSession = new List<Session>();
        public static List<string> listWhite = new List<string>();
        public static List<string> listBlack = new List<string>();

        public void Init()
        {
            strConfigFileName = System.Environment.CurrentDirectory + @"\" + @"config.txt";
            strWhiteListFileName = System.Environment.CurrentDirectory + @"\" + @"whitelist.txt";
            strBlackListFileName = System.Environment.CurrentDirectory + @"\" + @"blacklist.txt";

            string[] arrayConfig = File.ReadAllLines(strConfigFileName);
            JObject joInfo = (JObject)JsonConvert.DeserializeObject(arrayConfig[0]);
            if ((string)joInfo["SetProxy"] == @"0")
                bSetProxy = false;
            else
                bSetProxy = true;
            if ((string)joInfo["Repeat"] == @"0")
                bRepeat = false;
            else
                bRepeat = true;
            nThreadNum = (int)joInfo["ThreadNum"];
            dtStartTime = DateTime.Parse((string)joInfo["StartTime"]);
            dtEndTime = DateTime.Parse((string)joInfo["EndTime"]);
            strSazFile = (string)joInfo["SazFile"];
            if (strSazFile != "")
            {
                strSazFileName = System.Environment.CurrentDirectory + @"\" + strSazFile;
            }
            else 
            {
                string desktop = System.Environment.CurrentDirectory;
                DirectoryInfo folderDesktop = new DirectoryInfo(desktop);
                foreach (FileInfo NextFile in folderDesktop.GetFiles())
                {
                    if (string.Equals(NextFile.Extension, ".saz", StringComparison.OrdinalIgnoreCase))
                    {
                        strSazFile = NextFile.Name;
                        strSazFileName = NextFile.DirectoryName + @"\" + NextFile.Name;
                    }
                }

            }

            // whiltelist
            listWhite = new List<string>();
            if (File.Exists(strWhiteListFileName))
            {
                string[] arrayWhite = File.ReadAllLines(strWhiteListFileName);
                for (int nWhite = 0; nWhite < arrayWhite.Length; ++nWhite)
                {
                    string[] arrayParam = arrayWhite[nWhite].Split(new string[] { "####" }, System.StringSplitOptions.None);
                    listWhite.Add(arrayParam[arrayParam.Length - 1]);
                }
            }

            // blacklist
            listBlack = new List<string>();
            if (File.Exists(strBlackListFileName))
            {
                string[] arrayBlack = File.ReadAllLines(strBlackListFileName);
                for (int nBlack = 0; nBlack < arrayBlack.Length; ++nBlack)
                {
                    string[] arrayParam = arrayBlack[nBlack].Split(new string[] { "####" }, System.StringSplitOptions.None);
                    listBlack.Add(arrayParam[arrayParam.Length - 1]);
                }
            }

            // session
            listSession = new List<Session>();
            repeatFiddler.ReadSessions(strSazFileName, ref listSession);
            Program.form1.richTextBoxStatus_AddString(string.Format("读取到{0}条消息\n", listSession.Count()));
            if (bRepeat)
            {
                // remove repeat
                if (listSession[0].RequestMethod == "POST")
                {
                    List<Session> listResult = new List<Session>();
                    foreach (Session session in listSession)
                    {
                        bool bFound = false;
                        foreach (Session inResult in listResult)
                        {
                            if (session.GetRequestBodyAsString() == inResult.GetRequestBodyAsString())
                            {
                                bFound = true;
                                break;
                            }
                        }
                        if (!bFound)
                        {
                            listResult.Add(session);
                        }
                    }
                    listSession = listResult;
                    Program.form1.richTextBoxStatus_AddString(string.Format("POST-body删除重复，剩余{0}条消息\n", listSession.Count()));
                }
                else if (listSession[0].RequestMethod == "GET")
                {
                    List<Session> listResult = new List<Session>();
                    foreach (Session session in listSession)
                    {
                        bool bFound = false;
                        foreach (Session inResult in listResult)
                        {
                            if (session.fullUrl == inResult.fullUrl)
                            {
                                bFound = true;
                                break;
                            }
                        }
                        if (!bFound)
                        {
                            listResult.Add(session);
                        }
                    }

                    listSession = listResult;
                    Program.form1.richTextBoxStatus_AddString(string.Format("GET-url删除重复，剩余{0}条消息\n", listSession.Count()));
                }

                if (listWhite.Count() > 0)
                {
                    List<Session> listResult = new List<Session>();
                    foreach (string str in listWhite)
                    {
                        bool bFound = false;
                        foreach (Session session in listSession)
                        {
                            if (session.fullUrl.IndexOf(str) >= 0)
                                bFound = true;
                            else if (session.GetRequestBodyAsString().IndexOf(str) >= 0)
                                bFound = true;

                            if (bFound)
                            {
                                listResult.Add(session);
                                break;
                            }
                        }
                    }
                    listSession = listResult;
                    Program.form1.richTextBoxStatus_AddString(string.Format("白名单后，剩余{0}条消息\n", listSession.Count()));
                }

                if (listBlack.Count() > 0)
                {
                    List<Session> listResult = new List<Session>();
                    foreach (Session session in listSession)
                    {
                        bool bFound = false;
                        foreach (string str in listBlack)
                        {
                            if (session.fullUrl.IndexOf(str) >= 0)
                                bFound = true;
                            else if (session.GetRequestBodyAsString().IndexOf(str) >= 0)
                                bFound = true;

                            if (bFound)
                                break;
                        }
                        if (!bFound)
                        {
                            listResult.Add(session);
                        }
                    }
                    listSession = listResult;
                    Program.form1.richTextBoxStatus_AddString(string.Format("黑名单后，剩余{0}条消息\n", listSession.Count()));
                }
            }

            Program.form1.Form1_Init();
        }


        public void Run()
        {
            Thread thread = new Thread(RunInThread);
            thread.Start();
        }

        void RunInThread()
        {
            if (listSession.Count() <= 0)
                return;

            Program.form1.richTextBoxStatus_AddString(string.Format("等待起始时间...\n"));

            int nCountPerThread = (int)(listSession.Count() / nThreadNum);
            List<Player> listPlayer = new List<Player>();
            for (int nThread = 0; nThread < nThreadNum; ++nThread)
            {
                int nStart = nThread * nCountPerThread;
                int nEnd = nStart + nCountPerThread;
                if (nThread == (nThreadNum - 1))
                    nEnd = listSession.Count();

                Player player = new Player();
                player.nStartIndex = nStart;
                for (int nSession = nStart; nSession < nEnd; ++nSession)
                {
                    player.listSession.Add(listSession[nSession]);
                }
                listPlayer.Add(player);
            }

            for (int nPlayer = 0; nPlayer < listPlayer.Count(); ++nPlayer)
            {
                listPlayer[nPlayer].thread = new Thread(listPlayer[nPlayer].Run);
                listPlayer[nPlayer].thread.Start();
            }

            for (int nPlayer = 0; nPlayer < listPlayer.Count(); ++nPlayer)
            {
                listPlayer[nPlayer].thread.Join();
            }

            Program.form1.buttonRun_Enabled();
        }  
    };

    public class repeatFiddler
    {
        public static void ReadSessions(string strPath, ref List<Fiddler.Session> oAllSessions)
        {
            Session[] oLoaded = Utilities.ReadSessionArchive(strPath, false);

            if ((oLoaded != null) && (oLoaded.Length > 0))
            {
                oAllSessions.AddRange(oLoaded);
                //WriteCommandResponse("Loaded: " + oLoaded.Length + " sessions.");
            }

            //HttpParam.SendSession(oLoaded[0]);
        }

        public static void doRun()
        {
            List<Fiddler.Session> listSession = new List<Fiddler.Session>();
            //ReadSessions(listSession);
        }
        
        
        public static void Init()
        {
            // <-- Personalize for your Application, 64 chars or fewer
            Fiddler.FiddlerApplication.SetAppDisplayName("RepeatFiddler");

            string sSAZInfo = Assembly.GetAssembly(typeof(Ionic.Zip.ZipFile)).FullName;
            DNZSAZProvider.fnObtainPwd = () =>
            {
                Console.WriteLine("Enter the password (or just hit Enter to cancel):");
                string sResult = Console.ReadLine();
                Console.WriteLine();
                return sResult;
            };

            FiddlerApplication.oSAZProvider = new DNZSAZProvider();

            Console.WriteLine(String.Format("Starting {0} ({1})...", Fiddler.FiddlerApplication.GetVersionString(), sSAZInfo));

            //Fiddler.CONFIG.IgnoreServerCertErrors = false;
            //FiddlerApplication.Prefs.SetBoolPref("fiddler.network.streaming.abortifclientaborts", true);
            //FiddlerCoreStartupFlags oFCSF = FiddlerCoreStartupFlags.Default;
            //int iPort = 8877;
            //Fiddler.FiddlerApplication.Startup(iPort, oFCSF);
        }


        public static void doQuit()
        {
            //Fiddler.FiddlerApplication.Shutdown();        
        }
    };
     
}
