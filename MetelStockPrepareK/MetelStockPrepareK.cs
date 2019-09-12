using AxKHOpenAPILib;
using MetelStockPrepareK.manager;
using MetelStockPrepareK.db;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MetelStockPrepareK
{
    public partial class frmMetelStockPreK : Form
    {
        private static int screenNo = 1000;
        private readonly string MARKET_KOSPI = "0";
        private readonly string MARKET_KOSDAQ = "10";


        RequestTrManager requestTrManager;

        public frmMetelStockPreK()
        {
            InitializeComponent();

            requestTrManager = RequestTrManager.GetInstance();
            requestTrManager.Run();

            axKHOpenAPI1.CommConnect();

            axKHOpenAPI1.OnEventConnect += API_LogonEventConnect;

            axKHOpenAPI1.OnReceiveTrData += API_OnReceiveTrData;

            btnItemYmd.Click += Btn_Click;
            btnBasicItem.Click += Btn_Click;
            btnIlSiBun.Click += Btn_Click;
            btnDayChart.Click += Btn_ToDB_Click;
            btnItemMake.Click += Btn_ToDB_Click;
            btnRemainItemByDay.Click += Btn_ToDB_Click;
            btnUpjong.Click += Btn_ToDB_Click;

            txtSummary.TextChanged += TxtResult_TextChanged;
            txtResult.TextChanged += TxtResult_TextChanged;

            /*** analystics part ***/
            Series chartSeries = chartAnal.Series["Series1"];
            chartAnal.Series["Series1"]["PriceUpColor"] = "Red";
            chartAnal.Series["Series1"]["PriceDownColor"] = "Blue";

            btnAnalPUp.Click += BtnAnalPUp_Click;
            dgvItemList.CellDoubleClick += DgvItemList_CellDoubleClick;

        }

        private DataTable dtChartAnalystic = null;
        private void DgvItemList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DBAnalysis dbAnalystics = new DBAnalysis();
            string itemCd = dgvItemList.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
            string ymd = dgvItemList.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
            string eprice = dgvItemList.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
            string preDayChar = Decimal.ToInt32(numPre.Value).ToString();
            string followDayChar = Decimal.ToInt32(numFollow.Value).ToString();
            dtChartAnalystic = dbAnalystics.getChartUpPriceBetweenDay(itemCd, ymd, preDayChar, followDayChar);
            int len = dtChartAnalystic.Rows.Count;
            chartAnal.Series.Clear();
            Series series = new Series();
            series.ChartType = SeriesChartType.Candlestick;
            series.Name = "Series1";
            chartAnal.Series.Add(series);

            for (int i = 0; i < len; i++)
            {
                DataRow row = dtChartAnalystic.Rows[i];
                string c_ymd = row["YMD"].ToString();
                int c_hprice = Decimal.ToInt32( (decimal) row["HPRICE"]);
                int c_lprice = Decimal.ToInt32( (decimal)row["LPRICE"]);
                int c_sprice = Decimal.ToInt32( (decimal)row["SPRICE"]);
                int c_eprice = Decimal.ToInt32((decimal)row["EPRICE"]);

                chartAnal.Series["Series1"].Points.AddXY(c_ymd, c_hprice);
                chartAnal.Series["Series1"].Points[i].YValues[1] = c_lprice;
                chartAnal.Series["Series1"].Points[i].YValues[2] = c_sprice;
                chartAnal.Series["Series1"].Points[i].YValues[3] = c_eprice;
            }
        }

        private void ChartAnal_AxisViewChanged(object sender, ViewEventArgs e)
        {
            if (sender.Equals(chartAnal))
            {
                int chartRecordCount = dtChartAnalystic.Rows.Count;
                int startPosition = (int)e.Axis.ScaleView.ViewMinimum;
                int endPosition = (int)e.Axis.ScaleView.ViewMaximum;

                int max = (int)e.ChartArea.AxisY.ScaleView.ViewMinimum;
                int min = (int)e.ChartArea.AxisY.ScaleView.ViewMaximum;

                for (int i = startPosition-1; i < endPosition; i++)
                {
                    if (i >= chartRecordCount) break;
                    if (i < 0) i = 0;
                    int hprice = Decimal.ToInt32((decimal)dtChartAnalystic.Rows[i]["HPRICE"]);
                    int lprice = Decimal.ToInt32((decimal)dtChartAnalystic.Rows[i]["LPRICE"]);

                    if (hprice > max)
                        max = hprice;
                    if (lprice < min)
                        min = lprice;
                }
                this.chartAnal.ChartAreas[0].AxisY.Maximum = max;
                this.chartAnal.ChartAreas[0].AxisY.Minimum = min;
            }
        }

        private void BtnAnalPUp_Click(object sender, EventArgs e)
        {
            DBAnalysis dbAnalystics = new DBAnalysis();
            dgvItemList.DataSource =  dbAnalystics.getDtUpPriceItems();
        }

        private void Btn_ToDB_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnRemainItemByDay))
            {
                string ymd = DateTime.Now.ToString("yyyyMMdd");
                DBAction dbAction = new DBAction();
                List<string> list = dbAction.getItemsNotInDays(ymd);
                int count = list.Count;
                for (int kk = 0; kk < count; kk++)
                {
                    string code = list[kk];
                    Task rqDataTask = new Task(() =>
                    {
                        axKHOpenAPI1.SetInputValue("종목코드", code);
                        axKHOpenAPI1.SetInputValue("기준일자", ymd);
                        axKHOpenAPI1.SetInputValue("수정주가구분", "1");

                        int result = axKHOpenAPI1.CommRqData("잔여일봉차트조회", "opt10081", 0, getScreenNo());
                        if (result == 0)
                        {
                            Console.WriteLine("종목조회 요청 성공");
                        }
                        else
                        {
                            Console.WriteLine("종목요청 실패");
                        }
                    });
                    requestTrManager.RequestTrData(rqDataTask);
                }
            }
            if (sender.Equals(btnUpjong))
            {
                DateTime now = DateTime.Now;
                for (int i = -10; i < 1; i++)
                {
                    DateTime dtime = now.AddDays(i);
                    if(dtime.DayOfWeek != DayOfWeek.Saturday && dtime.DayOfWeek != DayOfWeek.Sunday)
                    {
                        string ymd = now.AddDays(i).ToString("yyyyMMdd");
                        for (int kk = 0; kk < 2; kk++)
                        {
                            string sig = kk == 0 ? "001" : "101";
                            DBAction dbAction = new DBAction();
                            List<string> list = dbAction.getItemsNotInDays(ymd);
                            int len = list.Count;
                            if(len > 10)
                            {
                                Task rqDataTask = new Task(() =>
                                {
                                    axKHOpenAPI1.SetInputValue("업종코드", sig);
                                    axKHOpenAPI1.SetInputValue("기준일자", ymd);

                                    int result = axKHOpenAPI1.CommRqData("업종일봉조회요청", "opt20006", 0, getScreenNo());
                                    if (result == 0)
                                    {
                                        Console.WriteLine("업종일봉조회요청 요청 성공");
                                    }
                                    else
                                    {
                                        Console.WriteLine("업종일봉조회요청 실패");
                                    }
                                });
                                requestTrManager.RequestTrData(rqDataTask);
                            }
                        }
                    }
                }
            }
            if (sender.Equals(btnItemMake))
            {
                for (int kk = 0; kk < 2; kk++)
                {
                    string _codes = kk == 0 ? axKHOpenAPI1.GetCodeListByMarket(MARKET_KOSPI) : axKHOpenAPI1.GetCodeListByMarket(MARKET_KOSDAQ);
                    string _market_type = kk == 0 ? "KOSPI" : "KOSDAQ";
                    string[] codes = _codes.Split(';');
                    int lenKospi = codes.Length;
                    for (int i = 0; i < lenKospi; i++)
                    {
                        string code = codes[i];
                        if(code.Length > 0)
                        {
                            DBAction dbAction = new DBAction();

                            string nm = axKHOpenAPI1.GetMasterCodeName(code);
                            string actionResult = dbAction.insertMetItemKCode(code, nm, _market_type);
                            printScreen(actionResult);
                        }
                    }
                }
            }
            if (sender.Equals(btnDayChart))
            {
                DBAction dbAction = new DBAction();
                List<string> list = dbAction.getItemCdNotInDayChart();
                int len = list.Count;
                for (int kk = 0; kk < len; kk++)
                {
                    string code = list[kk];
                    string today = DateTime.Now.ToString("yyyyMMdd");
                    bool isTaskContinue = true;
                    if (isTaskContinue)
                    {
                        Task rqDataTask = new Task(() =>
                        {
                            axKHOpenAPI1.SetInputValue("종목코드", code);
                            axKHOpenAPI1.SetInputValue("기준일자", today);
                            axKHOpenAPI1.SetInputValue("수정주가구분", "1");

                            int result = axKHOpenAPI1.CommRqData("주식일봉차트조회요청", "opt10081", 0, getScreenNo());
                            if (result == 0)
                            {
                                Console.WriteLine("종목조회 요청 성공");
                            }
                            else
                            {
                                Console.WriteLine("종목요청 실패");
                            }
                        });
                        requestTrManager.RequestTrData(rqDataTask);
                    }
                }
            }
        }

        private void TxtResult_TextChanged(object sender, EventArgs e)
        {
            if (sender.Equals(txtResult))
            {
                this.txtResult.SelectionStart = txtResult.Text.Length;
                this.txtResult.ScrollToCaret();
            }
            if (sender.Equals(txtSummary))
            {
                this.txtSummary.SelectionStart = txtSummary.Text.Length;
                this.txtSummary.ScrollToCaret();
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnItemYmd))  //
            {

            }
            if (sender.Equals(btnBasicItem))
            {
                string stockCodes =  axKHOpenAPI1.GetCodeListByMarket(MARKET_KOSPI);
                printScreen(stockCodes + Environment.NewLine);

                string[] strs = new string[] { "002290", "009300", "009620", "014970", "017480", "018310", "023600", "024950", "032280", "032750", "037460", "038500", "046390", "053700", "054090", "054540", "065570", "073640", "082660", "100090", "111870", "122350", "225190", "291230" };
                for (int i = 0; i < strs.Length; i++)
                {
                    string code = strs[i];

                    Task rqDataTask = new Task(() =>
                    {
                        axKHOpenAPI1.SetInputValue("종목코드", code);
                        axKHOpenAPI1.SetInputValue("수정주가구분", "0");

                        int result = axKHOpenAPI1.CommRqData("주식기본정보요청", "opt10001", 0, getScreenNo());
                        if (result == 0)
                        {
                            Console.WriteLine("종목조회 요청 성공");
                        }
                        else
                        {
                            Console.WriteLine("종목요청 실패");
                        }
                    });
                    requestTrManager.RequestTrData(rqDataTask);
                }
            }
            if (sender.Equals(btnIlSiBun))
            {
                Task rqDataTask = new Task(() =>
                {
                    axKHOpenAPI1.SetInputValue("종목코드", "002290");

                    int result = axKHOpenAPI1.CommRqData("주식일주월시분요청", "opt10005", 0, getScreenNo());
                    if (result == 0)
                    {
                        Console.WriteLine("주식일주월시분요청 요청 성공");
                    }
                    else
                    {
                        Console.WriteLine("주식일주월시분요청 실패");
                    }
                });
                requestTrManager.RequestTrData(rqDataTask);
            }
        }

        private void summaryWriteLine(string txt)
        {
            txtSummary.Text += txt + Environment.NewLine;
        }

        private void API_LogonEventConnect(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if(e.nErrCode != 0)
            {
                txtSummary.Text = String.Format("로그인 실패하였습니다. {0}", e.nErrCode);
            } else
            {
                summaryWriteLine(String.Format("로그인을 성공하였습니다. ::: {0}", e.nErrCode));
                summaryWriteLine(String.Format("ACCLIST : {0}", axKHOpenAPI1.GetLoginInfo("ACCLIST")));
            }
        }

        private void API_OnReceiveTrData(object sender, _DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            if (e.sRQName.Equals("잔여일봉차트조회"))
            {
                DataTable dtDayChart = new DataTable();
                dtDayChart.Columns.Add(new DataColumn("ITEM_CD", typeof(string)));
                dtDayChart.Columns.Add(new DataColumn("YMD", typeof(string)));
                dtDayChart.Columns.Add(new DataColumn("LPRICE", typeof(string)));
                dtDayChart.Columns.Add(new DataColumn("EPRICE", typeof(string)));
                dtDayChart.Columns.Add(new DataColumn("HPRICE", typeof(string)));
                dtDayChart.Columns.Add(new DataColumn("SPRICE", typeof(string)));
                dtDayChart.Columns.Add(new DataColumn("VOLUMN", typeof(string)));
                dtDayChart.Columns.Add(new DataColumn("VAMT", typeof(string)));

                DBAction dbAction = new DBAction();

                int nCnt = axKHOpenAPI1.GetRepeatCnt(e.sTrCode, e.sRQName);
                string ITEM_CD = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "종목코드").Trim();
                string strCompare = dbAction.getStringYmdNotInDays(ITEM_CD);
                printScreen($@"STRCOMPARE: {ITEM_CD} : {strCompare}");
                if (!strCompare.Equals(""))
                {
                    for (int idx = 0; idx < nCnt; idx++)
                    {
                        string YMD = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, idx, "일자").Trim();
                        if(strCompare.IndexOf(YMD) > -1)
                        {
                            string SPRICE = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, idx, "시가").Trim();
                            string HPRICE = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, idx, "고가").Trim();
                            string LPRICE = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, idx, "저가").Trim();
                            string EPRICE = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, idx, "현재가").Trim();
                            string VOLUMN = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, idx, "거래량").Trim();
                            string VAMT = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, idx, "거래대금").Trim();
                            DataRow dr = dtDayChart.NewRow();
                            dr["ITEM_CD"] = ITEM_CD;
                            dr["YMD"] = YMD;
                            dr["SPRICE"] = SPRICE;
                            dr["HPRICE"] = HPRICE;
                            dr["LPRICE"] = LPRICE;
                            dr["EPRICE"] = EPRICE;
                            dr["VOLUMN"] = VOLUMN;
                            dr["VAMT"] = VAMT;
                            dtDayChart.Rows.Add(dr);
                        }
                    }
                    if(dtDayChart.Rows.Count > 0)
                    {
                        string actionMsg = dbAction.insertMetItemDayK(dtDayChart);
                        printScreen(actionMsg);
                    }
                }

            }
            if (e.sRQName.Equals("업종일봉조회요청"))
            {
                /* 업종일봉조회 테이블 설계 요망
                DataTable dtDayChart = new DataTable();
                dtDayChart.Columns.Add(new DataColumn("ITEM_CD", typeof(string)));
                dtDayChart.Columns.Add(new DataColumn("YMD", typeof(string)));
                dtDayChart.Columns.Add(new DataColumn("LPRICE", typeof(string)));
                dtDayChart.Columns.Add(new DataColumn("EPRICE", typeof(string)));
                dtDayChart.Columns.Add(new DataColumn("HPRICE", typeof(string)));
                dtDayChart.Columns.Add(new DataColumn("SPRICE", typeof(string)));
                dtDayChart.Columns.Add(new DataColumn("VOLUMN", typeof(string)));
                dtDayChart.Columns.Add(new DataColumn("VAMT", typeof(string)));

                DBAction dbAction = new DBAction();
                int nCnt = axKHOpenAPI1.GetRepeatCnt(e.sTrCode, e.sRQName);
                string ITEM_CD = "";
                for (int idx = 0; idx < nCnt; idx++)
                {
                    if (idx == 0)
                        ITEM_CD = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, idx, "업종코드").Trim();
                    string YMD = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, idx, "일자").Trim();

                    if(!dbAction.isItemsNotInDays(ITEM_CD, YMD)) continue;

                    string SPRICE = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, idx, "시가").Trim();
                    string HPRICE = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, idx, "고가").Trim();
                    string LPRICE = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, idx, "저가").Trim();
                    string EPRICE = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, idx, "현재가").Trim();
                    string VOLUMN = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, idx, "거래량").Trim();
                    string VAMT = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, idx, "거래대금").Trim();
                    DataRow dr = dtDayChart.NewRow();
                    dr["ITEM_CD"] = ITEM_CD;
                    dr["YMD"] = YMD;
                    dr["SPRICE"] = SPRICE;
                    dr["HPRICE"] = HPRICE;
                    dr["LPRICE"] = LPRICE;
                    dr["EPRICE"] = EPRICE;
                    dr["VOLUMN"] = VOLUMN;
                    dr["VAMT"] = VAMT;
                    dtDayChart.Rows.Add(dr);
                }
                string actionMsg = dbAction.insertMetItemDayK(dtDayChart);
                printScreen(actionMsg);
                */
            }

            if (e.sRQName.Equals("주식일봉차트조회요청"))
            {
                DataTable dtDayChart = new DataTable();
                dtDayChart.Columns.Add(new DataColumn("ITEM_CD", typeof(string)));
                dtDayChart.Columns.Add(new DataColumn("YMD", typeof(string)));
                dtDayChart.Columns.Add(new DataColumn("LPRICE", typeof(string)));
                dtDayChart.Columns.Add(new DataColumn("EPRICE", typeof(string)));
                dtDayChart.Columns.Add(new DataColumn("HPRICE", typeof(string)));
                dtDayChart.Columns.Add(new DataColumn("SPRICE", typeof(string)));
                dtDayChart.Columns.Add(new DataColumn("VOLUMN", typeof(string)));
                dtDayChart.Columns.Add(new DataColumn("VAMT", typeof(string)));

                int nCnt = axKHOpenAPI1.GetRepeatCnt(e.sTrCode, e.sRQName);
                string ITEM_CD = "";
                for (int idx = 0; idx < nCnt; idx++)
                {
                    if(idx ==0 )
                        ITEM_CD = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, idx, "종목코드").Trim();
                    string YMD = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, idx, "일자").Trim();
                    string SPRICE = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, idx, "시가").Trim();
                    string HPRICE = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, idx, "고가").Trim();
                    string LPRICE = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, idx, "저가").Trim();
                    string EPRICE = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, idx, "현재가").Trim();
                    string VOLUMN = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, idx, "거래량").Trim();
                    string VAMT = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, idx, "거래대금").Trim();
                    DataRow dr = dtDayChart.NewRow();
                    dr["ITEM_CD"] = ITEM_CD;
                    dr["YMD"] = YMD;
                    dr["SPRICE"] = SPRICE;
                    dr["HPRICE"] = HPRICE;
                    dr["LPRICE"] = LPRICE;
                    dr["EPRICE"] = EPRICE;
                    dr["VOLUMN"] = VOLUMN;
                    dr["VAMT"] = VAMT;
                    dtDayChart.Rows.Add(dr);
                }
                DBAction dbAction = new DBAction();
                string actionMsg = dbAction.insertMetItemDayK(dtDayChart);
                printScreen(actionMsg);
                
            }
            if (e.sRQName.Equals("주식기본정보요청"))
            {
                string itemCode = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "종목코드").Trim();
                string itemName = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "종목명").Trim();
                string price = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "현재가").Trim();
                string volumn = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "거래량").Trim();
                string updownRate = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "등락율").Trim();

                printScreen("itemCode = " + itemCode);
                printScreen("itemName = " + itemName);
                printScreen("price = " + price);
                printScreen("volumn = " + volumn);
                printScreen("updownRate = " + updownRate);

            }
            if (e.sRQName.Equals("주식일주월시분요청"))
            {
                string 날짜 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "날짜").Trim();
                string 시가 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "시가").Trim();
                string 고가 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "고가").Trim();
                string 저가= axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "저가").Trim();
                string 종가= axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "종가").Trim();
                string 대비= axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "대비").Trim();
                string 등락률 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "등락률"     ).Trim();
                string 거래량 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "거래량"     ).Trim();
                string 거래대금 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "거래대금"    ).Trim();
                string 체결강도 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "체결강도"    ).Trim();
                string 외인보유 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "외인보유"    ).Trim();
                string 외인비중 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "외인비중"    ).Trim();
                string 외인순매수 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "외인순매수"   ).Trim();
                string 기관순매수 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "기관순매수"   ).Trim();
                string 개인순매수 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "개인순매수"   ).Trim();
                string 외국계 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "외국계"      ).Trim();
                string 신용잔고율 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "신용잔고율"   ).Trim();
                string 프로그램 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "프로그램"    ).Trim();

                printScreen("날짜 = " + 날짜);
                printScreen("시가 = " + 시가);
                printScreen("고가 = " + 고가);
                printScreen("저가 = " + 저가);
                printScreen("종가 = " + 종가);
                printScreen("대비 = " + 대비);
                printScreen("등락률 = " + 등락률);
                printScreen("거래량 = " + 거래량);
                printScreen("거래대금 = " + 거래대금);
                printScreen("체결강도 = " + 체결강도);
                printScreen("외인보유 = " + 외인보유);
                printScreen("외인비중 = " + 외인비중);
                printScreen("외인순매수 = " + 외인순매수);
                printScreen("기관순매수 = " + 기관순매수);
                printScreen("개인순매수 = " + 개인순매수);
                printScreen("외국계 = " + 외국계);
                printScreen("신용잔고율 = " + 신용잔고율);
                printScreen("프로그램 = " + 프로그램);

            }
        }

        private string getScreenNo()
        {
            if(screenNo > 999)
            {
                screenNo = 1000;
            }
            screenNo++;
            return screenNo.ToString();
        }

        private void printScreen(string msg)
        {
            txtResult.Text += msg + Environment.NewLine;
        }



    }
}
