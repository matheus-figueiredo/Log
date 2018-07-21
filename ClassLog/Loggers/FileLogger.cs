using ClassLog.Log;
using ClassLog.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLog.Loggers
{
    internal class FileLogger : DefaultLogger
    {
        string Path;
        public FileLogger(string path)
        {
            //Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/log.txt";
            Path = path;
        }

        protected override void DoLog(string message)
        {
            File.AppendAllText(Path, message + Environment.NewLine);
        }

    }
}
