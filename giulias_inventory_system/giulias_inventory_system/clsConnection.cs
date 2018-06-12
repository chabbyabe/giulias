using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace giulias_inventory_system
{
    class clsConnection     //Added by Abe 4/16/18 6:41 pm ==== Used to connect to the database
    {
        MySqlConnection DBConn = new MySqlConnection();

        // 04/17/18 10:16 am by Abegail Isidro
        public MySqlCommand command = null;
        public MySqlDataAdapter sqlDataAdapt = null;
        public MySqlDataReader sqlReader = null;

        public MySqlConnection DBConnection
        {
            get
            {
                return DBConn;
            }
        }

        public void OpenConnection()
        {
            try
            {
                DBConn.ConnectionString = "Database=giulia; server='localhost'; uid='root'; pwd='';";
                DBConn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public void CloseConnection()
        {
            DBConn.Close();
        }

        // 04/17/18 10:16 am by Abegail Isidro
        public MySqlCommand SQLCommand(string sql)
        {
            command = new MySqlCommand(sql, DBConn);
            return command;
        }

        // 04/17/18 10:16 am by Abegail Isidro
        public MySqlDataAdapter AdapterCommand(string sql)
        {
            sqlDataAdapt = new MySqlDataAdapter(sql, DBConn);
            return sqlDataAdapt;
        }
    }
}
