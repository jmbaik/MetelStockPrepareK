using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetelStockPrepareK.db
{
    public class DBAnalysis
    {

        private DBConn dbconn = DBConn.getInstance();

        public DataTable getDtUpPriceItems()
        {
            DataTable dt = new DataTable();
            OracleConnection conn = dbconn.connect();
            using(OracleDataAdapter adapter = new OracleDataAdapter())
            {
                adapter.SelectCommand = new OracleCommand(@"SELECT 
	                                                        A.ITEM_CD 
	                                                        , B.ITEM_NM
	                                                        , A.YMD
	                                                        , A.EPRICE
	                                                        , A.PRE_PRICE
	                                                        , A.UP_RT
                                                        FROM MET_ANAL_UP A, MET_ITEM_K B
                                                        WHERE A.ITEM_CD = B.ITEM_CD
                                                        ORDER BY A.UP_RT", conn);
                adapter.Fill(dt);
            }
            conn.Close();
            return dt;
        }

        public DataTable getChartUpPriceBetweenDay(string itemCd, string ymd, string preDayChar, string followDayChar)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = dbconn.connect();
            using (OracleDataAdapter adapter = new OracleDataAdapter())
            {
                adapter.SelectCommand = new OracleCommand($@"SELECT 
	                                                A.ITEM_CD
	                                                , A.YMD
	                                                , A.LPRICE
	                                                , A.SPRICE
	                                                , A.EPRICE
	                                                , A.HPRICE
	                                                , A.VOLUMN
	                                                , A.VAMT
                                                FROM MET_ITEM_DAY_K A, MET_ANAL_UP B
                                                WHERE A.ITEM_CD = B.ITEM_CD
                                                AND B.ITEM_CD ='{itemCd}'
                                                AND A.YMD BETWEEN TO_DATE({ymd})-{preDayChar} AND  TO_DATE({ymd})+{followDayChar}", conn);
                adapter.Fill(dt);
            }
            conn.Close();
            return dt;
        }


    }
}
