using ClassLog.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLog.Configuration;

namespace ClassLog.Logger
{
    internal abstract class DefaultLogger : ILogger
    {

        private Level level = Level.DEBUG;

        public void Log(Level level, string message)
        {

            if (this.level <= level) {
                message = FormatMessage(message, level);
                this.DoLog(message);
            }

        }

        protected string FormatMessage(string message, Level level)
        {
            string format = Configuration.Configuration.MessageFormat;
            string timestamp = DateTime.Now.ToString();

            string formatedMessage = format.Replace("[TIMESTAMP]", timestamp)
                .Replace("[LEVEL]", level.ToString())
                .Replace("[MESSAGE]", message);

            return formatedMessage;
        }

        protected abstract void DoLog(string message);

        public void SetLevel(Level level) => this.level = level;
 
    }
}
