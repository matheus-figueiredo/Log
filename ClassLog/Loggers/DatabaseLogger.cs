using ClassLog.Log;
using ClassLog.Logger;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLog.Loggers
{
    internal class DatabaseLogger : DefaultLogger
    {

        protected override void DoLog(string message)
        {
            try
            {
                if (!File.Exists("database.db"))
                {
                    SQLiteConnection.CreateFile("MyDatabase.sqlite");
                }
                SQLiteConnection m_dbConnection;
                m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
                m_dbConnection.Open();

                string sql = "CREATE TABLE TABELA_TESTE3 (ID_Message INTEGER PRIMARY KEY NOT NULL, Message STRING)";

                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                string sql2 = $"INSERT INTO TABELA_TESTE3 (Message) values ('{message}')";

                SQLiteCommand command2 = new SQLiteCommand(sql2, m_dbConnection);
                command2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
