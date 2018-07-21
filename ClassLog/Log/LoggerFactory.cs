using ClassLog.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLog.Log
{
    internal class LoggerFactory
    {
        private Target Target;
        private Level Level;

        internal ILogger CreateLogger()
        {
            Level = GetLevel();
            Target = GetTarget();

            switch (Target)
            {
                case Target.CONSOLE:
                    ConsoleLogger logger = new ConsoleLogger();
                    logger.SetLevel(Level);
                    return logger;
                case Target.FILE:
                    FileLogger fileLogger = new FileLogger(Configuration.Configuration.FilePath);
                    fileLogger.SetLevel(Level);
                    return fileLogger;
                case Target.HTTP:
                    HttpLogger httpLogger = new HttpLogger(Configuration.Configuration.HttpUrl);
                    httpLogger.SetLevel(Level);
                    return httpLogger;
                default:
                    ConsoleLogger consoleLogger = new ConsoleLogger();
                    consoleLogger.SetLevel(Level);
                    return consoleLogger;
            }
        }

        private Level GetLevel()
        {
            Level level;
            try
            {
                string levelString = Configuration.Configuration.Level;
                Enum.TryParse(levelString?.ToUpper(), out level);
            }
            catch (System.Exception)
            {
                level = Level.DEBUG;
            }

            return level;
        }

        private Target GetTarget()
        {
            Target target;
            try
            {

                string targetString = Configuration.Configuration.Target;
                Enum.TryParse(targetString?.ToUpper(), out target);
            }
            catch (System.Exception)
            {
                target = Target.CONSOLE;
            }

            return target;
        }
    }
}
