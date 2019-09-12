using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace MetelStockPrepareK
{
    public class DBAction
    {
        private readonly string ORA_CON_INFO = "User Id=metstock; Password=man100; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.0.6)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = meteldb))); ";
        //private readonly string ORA_CON_INFO = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.0.6)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=meteldb)));User ID=metstock;Password=man100;Connection Timeout=30;";
        //private readonly string ORA_CON_INFO = @"User Id=metstock; Password=man100; Data Source=METIPTIME; Pooling=false";

        #region oracle 관련 메소드

        private OracleConnection connectDB()
        {
            OracleConnection conn = new OracleConnection(ORA_CON_INFO);
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

        public string insertMetItemDayK(DataTable dt)
        {
            /*************************************************************
             *  opt10081 주식종목 일봉데이터를 가져오는 api
             *  opt20006 업종 일봉 조회 요청
             * **********************************************************/
            string result = "";
            OracleConnection conn = connectDB();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            int lenDt = dt.Rows.Count;
            for (int i = 0; i < lenDt; i++)
            {
                DataRow row = dt.Rows[i];
                string itemCd = row.Field<string>("ITEM_CD");
                string ymd = row.Field<string>("YMD");
                string lprice = row.Field<string>("LPRICE");
                string eprice = row.Field<string>("EPRICE");
                string hprice = row.Field<string>("HPRICE");
                string sprice = row.Field<string>("SPRICE");
                string volumn = row.Field<string>("VOLUMN");
                string vamt = row.Field<string>("VAMT");

                try
                {
                    string query = $@"INSERT INTO MET_ITEM_DAY_K(ITEM_CD, YMD, LPRICE,SPRICE, EPRICE, HPRICE, VOLUMN, VAMT, CRT_DT, CRT_ID)
                                    VALUES('{itemCd}', '{ymd}', {lprice.ToString()}, {sprice.ToString()}, {eprice.ToString()}, {hprice.ToString()}, {volumn.ToString()}, {vamt.ToString()}, sysdate, 'meteladmin')";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    result = $@"{i} : {DateTime.Now.ToString()} INSERT INTO MET_ITEM_DAY_K ITEM_CD:{itemCd} YMD:{ymd}";
                }
                catch (Exception ex)
                {
                    return $@"ERROR INSERT FAILED MET_ITEM_DAY_K ::: {ex.Message} ";
                }
            }
            conn.Close();
            return result;
        }

        public string getYmdCodeDataMetItemDay(string code)
        {
            string ymd = "";
            OracleConnection conn = connectDB();
            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = $@"SELECT decode(min(YMD),NULL,'', to_char(to_date(min(YMD))-1,'YYYYMMDD')) AS YMD FROM MET_ITEM_DAY_K WHERE item_cd ='{code}' ";
                using(OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ymd = reader["YMD"].ToString();
                    }
                }
            }
            conn.Close();
            return ymd;
        }

        public string insertMetItemKCode(string code, string nm, string marketType)
        {
            string result = "";
            OracleConnection conn = connectDB();
            using (OracleCommand cmd = new OracleCommand())
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $@"INSERT INTO MET_ITEM_K (ITEM_CD, ITEM_NM, MARKET_TYPE, CRT_TM, CRT_ID) VALUES('{code}','{nm}','{marketType}',sysdate, 'metadmin')";
                    cmd.ExecuteNonQuery();
                    result = $@"{DateTime.Now.ToString()}INSERT INTO MET_ITEM_K ITEM_CD:{code} ITEM_NM:{nm}";
                }
                catch (Exception ex)
                {
                    return $@"ERROR INSERT FAILED MET_ITEM_K ::: {ex.Message} ";
                }
            }
            conn.Close();
            return result;
        }

        public List<string> getItemCdNotInDayChart()
        {
            List<string> result = new List<string>();
            OracleConnection conn = connectDB();
            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = $@"SELECT A.ITEM_CD AS ITEM_CD FROM MET_ITEM_K A WHERE A.ITEM_CD NOT IN (SELECT B.ITEM_CD FROM MET_ITEM_DAY_K B GROUP BY B.ITEM_CD)";
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add( reader["ITEM_CD"].ToString() );
                    }
                }
            }
            conn.Close();
            return result;
        }

        public string getStringYmdNotInDays(string code)
        {
            string resultString = "";
            List<string> result = new List<string>();
            OracleConnection conn = connectDB();
            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = $@"
                        SELECT A.DAY AS YMD FROM
                        (SELECT TO_CHAR( TO_DATE(TO_CHAR(SYSDATE-30,'YYYYMMDD'), 'YYYYMMDD') + ROWNUM-1, 'YYYYMMDD') AS DAY
                                        FROM DUAL
                                        CONNECT BY level <= ROUND( TO_DATE(TO_CHAR(SYSDATE,'YYYYMMDD'), 'YYYYMMDD') - TO_DATE(TO_CHAR(SYSDATE-30,'YYYYMMDD'), 'YYYYMMDD') )
                        ) A WHERE NOT EXISTS(SELECT B.YMD FROM MET_ITEM_DAY_K B WHERE A.DAY=B.YMD AND B.ITEM_CD='{code}')
                        AND TO_CHAR(TO_DATE(A.DAY),'d') NOT IN ('1','7')
                        ORDER BY A.DAY DESC
                    ";
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add( reader["YMD"].ToString() );
                    }
                }
            }
            conn.Close();
            int count = result.Count;
            for (int i = 0; i < count; i++)
            {
                resultString += i == 0 ? result[i] : "," + result[i];
            }
            return resultString;
        }

        public List<string> getItemsNotInDays(string ymd)
        {
            List<string> result = new List<string>();
            OracleConnection conn = connectDB();
            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = $@"SELECT A.ITEM_CD AS ITEM_CD from MET_ITEM_K A 
                        WHERE NOT EXISTS (SELECT 'X' FROM MET_ITEM_DAY_K B WHERE A.ITEM_CD = B.ITEM_CD AND B.YMD='{ymd}')
                    ";
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add( reader["ITEM_CD"].ToString() );
                    }
                }
            }
            conn.Close();
            return result;
        }

        public bool isItemsNotInDays(string code, string ymd)
        {
            int cnt = 0;
            List<string> result = new List<string>();
            OracleConnection conn = connectDB();
            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = $@"SELECT COUNT(0) AS CNT FROM MET_ITEM_DAY_K B WHERE 1=1 AND B.ITEM_CD='{code}' AND B.YMD='{ymd}'";
                object obj = cmd.ExecuteScalar();
                cnt = (int)obj;
            }
            conn.Close();
            return cnt==0?true:false;
        }

        #endregion
    }
}
