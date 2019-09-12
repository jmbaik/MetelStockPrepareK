namespace MetelStockPrepareK
{
    partial class frmMetelStockPreK
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMetelStockPreK));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabMetStock = new System.Windows.Forms.TabControl();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnUpjong = new System.Windows.Forms.Button();
            this.btnRemainItemByDay = new System.Windows.Forms.Button();
            this.btnItemMake = new System.Windows.Forms.Button();
            this.btnDayChart = new System.Windows.Forms.Button();
            this.btnIlSiBun = new System.Windows.Forms.Button();
            this.btnBasicItem = new System.Windows.Forms.Button();
            this.axKHOpenAPI1 = new AxKHOpenAPILib.AxKHOpenAPI();
            this.btnItemYmd = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.tabAnalystic = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tlAnalLeft = new System.Windows.Forms.TableLayoutPanel();
            this.dgvItemList = new System.Windows.Forms.DataGridView();
            this.gbAnalBtnArea = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numPre = new System.Windows.Forms.NumericUpDown();
            this.numFollow = new System.Windows.Forms.NumericUpDown();
            this.txtItemNm = new System.Windows.Forms.TextBox();
            this.btnAFilter = new System.Windows.Forms.Button();
            this.btnAnalPUp = new System.Windows.Forms.Button();
            this.spAnalChart = new System.Windows.Forms.SplitContainer();
            this.chartAnal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPageRealTime = new System.Windows.Forms.TabPage();
            this.tabMetStock.SuspendLayout();
            this.tabPageData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabAnalystic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tlAnalLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).BeginInit();
            this.gbAnalBtnArea.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFollow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spAnalChart)).BeginInit();
            this.spAnalChart.Panel2.SuspendLayout();
            this.spAnalChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnal)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMetStock
            // 
            this.tabMetStock.Controls.Add(this.tabPageData);
            this.tabMetStock.Controls.Add(this.tabAnalystic);
            this.tabMetStock.Controls.Add(this.tabPageRealTime);
            this.tabMetStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMetStock.Location = new System.Drawing.Point(0, 0);
            this.tabMetStock.Name = "tabMetStock";
            this.tabMetStock.SelectedIndex = 0;
            this.tabMetStock.Size = new System.Drawing.Size(1349, 815);
            this.tabMetStock.TabIndex = 0;
            // 
            // tabPageData
            // 
            this.tabPageData.Controls.Add(this.splitContainer1);
            this.tabPageData.Location = new System.Drawing.Point(4, 22);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageData.Size = new System.Drawing.Size(1341, 789);
            this.tabPageData.TabIndex = 0;
            this.tabPageData.Text = "데이터관리";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnUpjong);
            this.splitContainer1.Panel1.Controls.Add(this.btnRemainItemByDay);
            this.splitContainer1.Panel1.Controls.Add(this.btnItemMake);
            this.splitContainer1.Panel1.Controls.Add(this.btnDayChart);
            this.splitContainer1.Panel1.Controls.Add(this.btnIlSiBun);
            this.splitContainer1.Panel1.Controls.Add(this.btnBasicItem);
            this.splitContainer1.Panel1.Controls.Add(this.axKHOpenAPI1);
            this.splitContainer1.Panel1.Controls.Add(this.btnItemYmd);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1335, 783);
            this.splitContainer1.SplitterDistance = 335;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnUpjong
            // 
            this.btnUpjong.Location = new System.Drawing.Point(12, 355);
            this.btnUpjong.Name = "btnUpjong";
            this.btnUpjong.Size = new System.Drawing.Size(169, 27);
            this.btnUpjong.TabIndex = 7;
            this.btnUpjong.Text = "@업종일봉조회요청";
            this.btnUpjong.UseVisualStyleBackColor = true;
            // 
            // btnRemainItemByDay
            // 
            this.btnRemainItemByDay.Location = new System.Drawing.Point(12, 298);
            this.btnRemainItemByDay.Name = "btnRemainItemByDay";
            this.btnRemainItemByDay.Size = new System.Drawing.Size(169, 27);
            this.btnRemainItemByDay.TabIndex = 6;
            this.btnRemainItemByDay.Text = "@잔여일자별종목데이터넣기";
            this.btnRemainItemByDay.UseVisualStyleBackColor = true;
            // 
            // btnItemMake
            // 
            this.btnItemMake.Location = new System.Drawing.Point(12, 246);
            this.btnItemMake.Name = "btnItemMake";
            this.btnItemMake.Size = new System.Drawing.Size(169, 27);
            this.btnItemMake.TabIndex = 5;
            this.btnItemMake.Text = "@종목데이터만들기";
            this.btnItemMake.UseVisualStyleBackColor = true;
            // 
            // btnDayChart
            // 
            this.btnDayChart.Location = new System.Drawing.Point(12, 190);
            this.btnDayChart.Name = "btnDayChart";
            this.btnDayChart.Size = new System.Drawing.Size(169, 27);
            this.btnDayChart.TabIndex = 4;
            this.btnDayChart.Text = "@일봉차트데이터만들기";
            this.btnDayChart.UseVisualStyleBackColor = true;
            // 
            // btnIlSiBun
            // 
            this.btnIlSiBun.Location = new System.Drawing.Point(12, 135);
            this.btnIlSiBun.Name = "btnIlSiBun";
            this.btnIlSiBun.Size = new System.Drawing.Size(169, 27);
            this.btnIlSiBun.TabIndex = 3;
            this.btnIlSiBun.Text = "주식일주월시분요청";
            this.btnIlSiBun.UseVisualStyleBackColor = true;
            // 
            // btnBasicItem
            // 
            this.btnBasicItem.Location = new System.Drawing.Point(12, 29);
            this.btnBasicItem.Name = "btnBasicItem";
            this.btnBasicItem.Size = new System.Drawing.Size(169, 27);
            this.btnBasicItem.TabIndex = 2;
            this.btnBasicItem.Text = "주식기본정보요청 넣기";
            this.btnBasicItem.UseVisualStyleBackColor = true;
            // 
            // axKHOpenAPI1
            // 
            this.axKHOpenAPI1.Enabled = true;
            this.axKHOpenAPI1.Location = new System.Drawing.Point(224, 14);
            this.axKHOpenAPI1.Name = "axKHOpenAPI1";
            this.axKHOpenAPI1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axKHOpenAPI1.OcxState")));
            this.axKHOpenAPI1.Size = new System.Drawing.Size(100, 24);
            this.axKHOpenAPI1.TabIndex = 1;
            // 
            // btnItemYmd
            // 
            this.btnItemYmd.Location = new System.Drawing.Point(12, 80);
            this.btnItemYmd.Name = "btnItemYmd";
            this.btnItemYmd.Size = new System.Drawing.Size(169, 27);
            this.btnItemYmd.TabIndex = 0;
            this.btnItemYmd.Text = "종목 일자별 데이터 넣기";
            this.btnItemYmd.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtResult, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSummary, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(996, 783);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.ForeColor = System.Drawing.Color.LimeGreen;
            this.txtResult.Location = new System.Drawing.Point(3, 237);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(990, 543);
            this.txtResult.TabIndex = 0;
            // 
            // txtSummary
            // 
            this.txtSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSummary.Location = new System.Drawing.Point(3, 3);
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSummary.Size = new System.Drawing.Size(990, 228);
            this.txtSummary.TabIndex = 1;
            // 
            // tabAnalystic
            // 
            this.tabAnalystic.Controls.Add(this.splitContainer2);
            this.tabAnalystic.Location = new System.Drawing.Point(4, 22);
            this.tabAnalystic.Name = "tabAnalystic";
            this.tabAnalystic.Padding = new System.Windows.Forms.Padding(3);
            this.tabAnalystic.Size = new System.Drawing.Size(1341, 789);
            this.tabAnalystic.TabIndex = 2;
            this.tabAnalystic.Text = "분석및검증";
            this.tabAnalystic.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tlAnalLeft);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.spAnalChart);
            this.splitContainer2.Size = new System.Drawing.Size(1335, 783);
            this.splitContainer2.SplitterDistance = 351;
            this.splitContainer2.TabIndex = 0;
            // 
            // tlAnalLeft
            // 
            this.tlAnalLeft.ColumnCount = 1;
            this.tlAnalLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlAnalLeft.Controls.Add(this.dgvItemList, 0, 1);
            this.tlAnalLeft.Controls.Add(this.gbAnalBtnArea, 0, 0);
            this.tlAnalLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlAnalLeft.Location = new System.Drawing.Point(0, 0);
            this.tlAnalLeft.Name = "tlAnalLeft";
            this.tlAnalLeft.RowCount = 2;
            this.tlAnalLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 209F));
            this.tlAnalLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlAnalLeft.Size = new System.Drawing.Size(351, 783);
            this.tlAnalLeft.TabIndex = 0;
            // 
            // dgvItemList
            // 
            this.dgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItemList.Location = new System.Drawing.Point(3, 212);
            this.dgvItemList.Name = "dgvItemList";
            this.dgvItemList.RowTemplate.Height = 23;
            this.dgvItemList.Size = new System.Drawing.Size(345, 568);
            this.dgvItemList.TabIndex = 0;
            // 
            // gbAnalBtnArea
            // 
            this.gbAnalBtnArea.Controls.Add(this.tableLayoutPanel2);
            this.gbAnalBtnArea.Controls.Add(this.btnAnalPUp);
            this.gbAnalBtnArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAnalBtnArea.Location = new System.Drawing.Point(3, 3);
            this.gbAnalBtnArea.Name = "gbAnalBtnArea";
            this.gbAnalBtnArea.Size = new System.Drawing.Size(345, 203);
            this.gbAnalBtnArea.TabIndex = 1;
            this.gbAnalBtnArea.TabStop = false;
            this.gbAnalBtnArea.Text = "Retrive Area";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.numPre, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.numFollow, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtItemNm, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAFilter, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 151);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(339, 49);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(172, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "F";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "P";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numPre
            // 
            this.numPre.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.numPre.Location = new System.Drawing.Point(33, 27);
            this.numPre.Name = "numPre";
            this.numPre.Size = new System.Drawing.Size(133, 21);
            this.numPre.TabIndex = 3;
            this.numPre.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // numFollow
            // 
            this.numFollow.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.numFollow.Location = new System.Drawing.Point(202, 27);
            this.numFollow.Name = "numFollow";
            this.numFollow.Size = new System.Drawing.Size(134, 21);
            this.numFollow.TabIndex = 4;
            this.numFollow.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // txtItemNm
            // 
            this.txtItemNm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtItemNm.Location = new System.Drawing.Point(33, 3);
            this.txtItemNm.Name = "txtItemNm";
            this.txtItemNm.Size = new System.Drawing.Size(133, 21);
            this.txtItemNm.TabIndex = 7;
            // 
            // btnAFilter
            // 
            this.btnAFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAFilter.Location = new System.Drawing.Point(202, 3);
            this.btnAFilter.Name = "btnAFilter";
            this.btnAFilter.Size = new System.Drawing.Size(134, 18);
            this.btnAFilter.TabIndex = 8;
            this.btnAFilter.Text = "Filter";
            this.btnAFilter.UseVisualStyleBackColor = true;
            // 
            // btnAnalPUp
            // 
            this.btnAnalPUp.Location = new System.Drawing.Point(6, 20);
            this.btnAnalPUp.Name = "btnAnalPUp";
            this.btnAnalPUp.Size = new System.Drawing.Size(100, 23);
            this.btnAnalPUp.TabIndex = 0;
            this.btnAnalPUp.Text = "상한가 분석";
            this.btnAnalPUp.UseVisualStyleBackColor = true;
            // 
            // spAnalChart
            // 
            this.spAnalChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spAnalChart.Location = new System.Drawing.Point(0, 0);
            this.spAnalChart.Name = "spAnalChart";
            this.spAnalChart.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spAnalChart.Panel2
            // 
            this.spAnalChart.Panel2.Controls.Add(this.chartAnal);
            this.spAnalChart.Size = new System.Drawing.Size(980, 783);
            this.spAnalChart.SplitterDistance = 326;
            this.spAnalChart.TabIndex = 0;
            // 
            // chartAnal
            // 
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.Name = "ChartArea1";
            this.chartAnal.ChartAreas.Add(chartArea2);
            this.chartAnal.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartAnal.Legends.Add(legend2);
            this.chartAnal.Location = new System.Drawing.Point(0, 0);
            this.chartAnal.Name = "chartAnal";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.YValuesPerPoint = 4;
            this.chartAnal.Series.Add(series2);
            this.chartAnal.Size = new System.Drawing.Size(980, 453);
            this.chartAnal.TabIndex = 0;
            this.chartAnal.Text = "chart1";
            // 
            // tabPageRealTime
            // 
            this.tabPageRealTime.Location = new System.Drawing.Point(4, 22);
            this.tabPageRealTime.Name = "tabPageRealTime";
            this.tabPageRealTime.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRealTime.Size = new System.Drawing.Size(1341, 789);
            this.tabPageRealTime.TabIndex = 1;
            this.tabPageRealTime.Text = "실시간";
            this.tabPageRealTime.UseVisualStyleBackColor = true;
            // 
            // frmMetelStockPreK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 815);
            this.Controls.Add(this.tabMetStock);
            this.Name = "frmMetelStockPreK";
            this.Text = "Metel Stock Prepare K";
            this.tabMetStock.ResumeLayout(false);
            this.tabPageData.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabAnalystic.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tlAnalLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).EndInit();
            this.gbAnalBtnArea.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFollow)).EndInit();
            this.spAnalChart.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spAnalChart)).EndInit();
            this.spAnalChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartAnal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMetStock;
        private System.Windows.Forms.TabPage tabPageData;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnDayChart;
        private System.Windows.Forms.Button btnIlSiBun;
        private System.Windows.Forms.Button btnBasicItem;
        private AxKHOpenAPILib.AxKHOpenAPI axKHOpenAPI1;
        private System.Windows.Forms.Button btnItemYmd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.TabPage tabPageRealTime;
        private System.Windows.Forms.Button btnItemMake;
        private System.Windows.Forms.Button btnRemainItemByDay;
        private System.Windows.Forms.Button btnUpjong;
        private System.Windows.Forms.TabPage tabAnalystic;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tlAnalLeft;
        private System.Windows.Forms.DataGridView dgvItemList;
        private System.Windows.Forms.SplitContainer spAnalChart;
        private System.Windows.Forms.GroupBox gbAnalBtnArea;
        private System.Windows.Forms.Button btnAnalPUp;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAnal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown numFollow;
        private System.Windows.Forms.NumericUpDown numPre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItemNm;
        private System.Windows.Forms.Button btnAFilter;
    }
}

