using ClassLog.Log;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLog.Loggers;

namespace Tests
{
    [TestClass]
    public class MyTestClass
    {

        [TestMethod]
        public void Logar()
        {
            Logger logger = new Logger();
            logger.Log(Level.DEBUG, "Teste para gravação de mensagem");
        }
    }
}
