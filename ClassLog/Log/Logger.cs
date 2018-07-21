using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLog.Log
{
    public class Logger
    {
        ILogger InternalLogger;

        public Logger()
        {
            LoggerFactory factory = new LoggerFactory();
            InternalLogger = factory.CreateLogger();
        }

        public void Log(Level level, string message)
        {
            InternalLogger.Log(level, message);
        }
    }
}
