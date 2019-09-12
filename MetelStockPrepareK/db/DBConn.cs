using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetelStockPrepareK.db
{


    public class DBConn
    {
        private readonly string ORA_CON_INFO = "User Id=metstock; Password=man100; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.0.6)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = meteldb))); ";

        private static DBConn instance = null;

        private OracleConnection conn = null;

        private DBConn()
        {

        }  

        public static DBConn getInstance()
        {
            if(instance == null)
            {
                instance = new DBConn();
            }
            return instance;    
        }

        public OracleConnection connect()
        {
            if (conn == null)
                conn = new OracleConnection(ORA_CON_INFO);

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("conn fail!" + ex.Message);
            }
            return conn;
        }

        public void close()
        {
            if (conn != null)
            {
                conn.Close();
                conn = null;
            }
        }
    }
}
