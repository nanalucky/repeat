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

namespace repeat
{
    public class Player
    {
    };

    class AllPlayers
    {

        public void Init()
        {
        }
  
    };

    public class repeatFiddler
    {
        private static void ReadSessions(List<Fiddler.Session> oAllSessions)
        {
            Session[] oLoaded = Utilities.ReadSessionArchive(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                                                           + Path.DirectorySeparatorChar + "sazsendertest.saz", false);

            if ((oLoaded != null) && (oLoaded.Length > 0))
            {
                oAllSessions.AddRange(oLoaded);
                //WriteCommandResponse("Loaded: " + oLoaded.Length + " sessions.");
            }
        }

        public static void doRun()
        {
            List<Fiddler.Session> listSession = new List<Fiddler.Session>();
            ReadSessions(listSession);
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

            Fiddler.CONFIG.IgnoreServerCertErrors = false;
            FiddlerApplication.Prefs.SetBoolPref("fiddler.network.streaming.abortifclientaborts", true);
            FiddlerCoreStartupFlags oFCSF = FiddlerCoreStartupFlags.Default;
            int iPort = 8877;
            Fiddler.FiddlerApplication.Startup(iPort, oFCSF);
        }


        public static void doQuit()
        {
            Fiddler.FiddlerApplication.Shutdown();        
        }
    };
     
}
