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
            strSazFileName = System.Environment.CurrentDirectory + @"\" + strSazFile;

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

            Program.form1.Form1_Init();
        }


        public void Run()
        {
/*            Program.form1.UpdateLoginTimes();

            // first login
            foreach (Player player in listPlayer)
            {
                player.thread.Start();
            }

            // relogin
            Thread threadRelogin = new Thread(new ThreadStart(this.WaitForRelogin));
            threadRelogin.Start();
*/        }
  
    };

    public class repeatFiddler
    {
        public static void ReadSessions(string strPath, ref List<Fiddler.Session> oAllSessions)
        {
            Session[] oLoaded = Utilities.ReadSessionArchive(strPath, false);

            if ((oLoaded != null) && (oLoaded.Length > 0))
            {
                oAllSessions.AddRange(oAllSessions);
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
