using ClassLog.Logger;
using ClassLog.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLog.Loggers
{
    internal class ConsoleLogger : DefaultLogger
    {
        protected override void DoLog(string message)
        {
            Console.WriteLine(message);
        }

    }
}
