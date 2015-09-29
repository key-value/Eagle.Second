using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Eagle.Infrastructrue
{
    public static class SystemConst
    {
        static SystemConst()
        {
            Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            MachineName = config.AppSettings.Settings["MachineName"].Value;
            IpAddress = config.AppSettings.Settings["IpAddress"].Value;
            MachineId = config.AppSettings.Settings["MachineId"].Value;
            var runServer = config.AppSettings.Settings["Server"].Value;
            var list = config.AppSettings.Settings["ProcessList"].Value;
            AuspiciousIp = ConfigurationManager.AppSettings["AuspiciousIp"];
            var auspiciousPort = ConfigurationManager.AppSettings["AuspiciousPort"];
            int.TryParse(auspiciousPort, out AuspiciousPort);
            if (string.IsNullOrEmpty(list))
            {
                ProcessList = new List<string>();
            }
            else
            {
                ProcessList = list.Split(',').ToList();
            }
            Server = runServer == "True" || runServer == "true";
            MsmqAddress = ConfigurationManager.AppSettings["MsmqAddress"];
            PirateAddress = ConfigurationManager.AppSettings["PirateAddress"];
        }
        public static string TimeStyle = "yy-MM-dd HH:mm:ss";

        public static string MachineName;

        public static string MachineId;

        public static string IpAddress;

        public static bool Server;

        public static List<string> ProcessList;

        public static string AuspiciousIp;

        public static int AuspiciousPort;

        public static string MsmqAddress;

        public static string PirateAddress;
    }
}