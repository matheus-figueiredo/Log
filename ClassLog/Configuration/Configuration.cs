using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLog.Configuration
{
    internal static class Configuration
    {
        public static string Target { get; private set; }
        public static string Level { get; private set; }
        public static string MessageFormat { get; private set; }
        public static string FilePath { get; private set; }
        public static string HttpUrl { get; private set; }
        public static string ConnectionString { get; private set; }
        static private string LogConfigPath;

        static Configuration()
        {
            try
            {
                LogConfigPath = ConfigurationManager.AppSettings["LogConfigFile"];
                LoadConfigurations();
            }
            catch(System.Exception)
            {

            }
        }

        public static void LoadConfigurations()
        {
            StringBuilder result = new StringBuilder();
            XDocument xdoc = XDocument.Load(LogConfigPath);
            XElement root = xdoc.Element("configuration");

            if (root != null)
            {
                SetTargetAttributes(root);
                SetMessageFormat(root);
            }
        }

        private static void SetTargetAttributes(XElement root)
        {
            XElement target = root.Element("target");

            if (target != null)
            {
                Target = target.Attribute("name")?.Value;
                Level = target.Attribute("minlevel")?.Value;

                if (Target?.ToLower() == "file")
                {
                    FilePath = target.Attribute("path")?.Value;
                }
                else if (Target?.ToLower() == "http")
                {
                    HttpUrl = target.Attribute("url")?.Value;
                }
                else if (Target?.ToLower() == "database")
                {
                    ConnectionString = target.Attribute("connectionString")?.Value; ;
                }
            }
        }

        private static void SetMessageFormat(XElement root)
        {
            XElement target = root.Element("messageFormat");
            if (target != null)
            {
                MessageFormat = target.Attribute("pattern")?.Value;
            }
        }
    }
}
