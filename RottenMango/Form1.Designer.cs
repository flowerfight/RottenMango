namespace RottenMango
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.프로세스 = new MetroFramework.Controls.MetroTabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.metroProgressSpinnerCPU = new MetroFramework.Controls.MetroProgressSpinner();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UseableRAMPer = new System.Windows.Forms.Label();
            this.metroProgressBarRAM = new MetroFramework.Controls.MetroProgressBar();
            this.metroProgressBarCPU = new MetroFramework.Controls.MetroProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UseableCPU = new System.Windows.Forms.Label();
            this.UseableRAM = new System.Windows.Forms.Label();
            this.processChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CheckUseable = new System.Windows.Forms.Button();
            this.설정 = new MetroFramework.Controls.MetroTabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.프로세스.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.processChart)).BeginInit();
            this.설정.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.프로세스);
            this.metroTabControl1.Controls.Add(this.설정);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(20, 60);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(1184, 645);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.button1);
            this.metroTabPage1.Controls.Add(this.groupBox3);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(1176, 603);
            this.metroTabPage1.TabIndex = 2;
            this.metroTabPage1.Text = "리스트 통계";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox3.Controls.Add(this.dataGridView);
            this.groupBox3.Location = new System.Drawing.Point(4, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(700, 518);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "프로그램 리스트";
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 21);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 27;
            this.dataGridView.Size = new System.Drawing.Size(694, 494);
            this.dataGridView.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Process";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "실제 할당된 메모리";
            this.Column2.Name = "Column2";
            this.Column2.Width = 170;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Process PID";
            this.Column3.Name = "Column3";
            this.Column3.Width = 130;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "메모리";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "백분율";
            this.Column5.Name = "Column5";
            // 
            // 프로세스
            // 
            this.프로세스.Controls.Add(this.groupBox2);
            this.프로세스.Controls.Add(this.groupBox1);
            this.프로세스.Controls.Add(this.processChart);
            this.프로세스.Controls.Add(this.CheckUseable);
            this.프로세스.HorizontalScrollbarBarColor = true;
            this.프로세스.HorizontalScrollbarHighlightOnWheel = false;
            this.프로세스.HorizontalScrollbarSize = 10;
            this.프로세스.Location = new System.Drawing.Point(4, 38);
            this.프로세스.Name = "프로세스";
            this.프로세스.Padding = new System.Windows.Forms.Padding(5);
            this.프로세스.Size = new System.Drawing.Size(738, 541);
            this.프로세스.TabIndex = 0;
            this.프로세스.Text = "프로세스";
            this.프로세스.VerticalScrollbarBarColor = true;
            this.프로세스.VerticalScrollbarHighlightOnWheel = false;
            this.프로세스.VerticalScrollbarSize = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Controls.Add(this.metroProgressSpinnerCPU);
            this.groupBox2.Location = new System.Drawing.Point(3, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 237);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "useable CPU";
            // 
            // metroProgressSpinnerCPU
            // 
            this.metroProgressSpinnerCPU.BackColor = System.Drawing.SystemColors.ControlDark;
            this.metroProgressSpinnerCPU.Location = new System.Drawing.Point(17, 35);
            this.metroProgressSpinnerCPU.Maximum = 100;
            this.metroProgressSpinnerCPU.Name = "metroProgressSpinnerCPU";
            this.metroProgressSpinnerCPU.Size = new System.Drawing.Size(180, 180);
            this.metroProgressSpinnerCPU.Spinning = false;
            this.metroProgressSpinnerCPU.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroProgressSpinnerCPU.TabIndex = 13;
            this.metroProgressSpinnerCPU.UseSelectable = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.UseableRAMPer);
            this.groupBox1.Controls.Add(this.metroProgressBarRAM);
            this.groupBox1.Controls.Add(this.metroProgressBarCPU);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.UseableCPU);
            this.groupBox1.Controls.Add(this.UseableRAM);
            this.groupBox1.Location = new System.Drawing.Point(3, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(555, 134);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "실시간 프로세스 사용량";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "RAM 사용 가능량 : ";
            // 
            // UseableRAMPer
            // 
            this.UseableRAMPer.AutoSize = true;
            this.UseableRAMPer.Location = new System.Drawing.Point(130, 69);
            this.UseableRAMPer.Name = "UseableRAMPer";
            this.UseableRAMPer.Size = new System.Drawing.Size(26, 15);
            this.UseableRAMPer.TabIndex = 13;
            this.UseableRAMPer.Text = "0%";
            // 
            // metroProgressBarRAM
            // 
            this.metroProgressBarRAM.Location = new System.Drawing.Point(214, 65);
            this.metroProgressBarRAM.Name = "metroProgressBarRAM";
            this.metroProgressBarRAM.Size = new System.Drawing.Size(313, 23);
            this.metroProgressBarRAM.TabIndex = 11;
            // 
            // metroProgressBarCPU
            // 
            this.metroProgressBarCPU.Location = new System.Drawing.Point(214, 28);
            this.metroProgressBarCPU.Name = "metroProgressBarCPU";
            this.metroProgressBarCPU.Size = new System.Drawing.Size(313, 23);
            this.metroProgressBarCPU.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroProgressBarCPU.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "RAM 사용량 : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "CPU 사용량 : ";
            // 
            // UseableCPU
            // 
            this.UseableCPU.AutoSize = true;
            this.UseableCPU.Location = new System.Drawing.Point(129, 32);
            this.UseableCPU.Name = "UseableCPU";
            this.UseableCPU.Size = new System.Drawing.Size(26, 15);
            this.UseableCPU.TabIndex = 2;
            this.UseableCPU.Text = "0%";
            // 
            // UseableRAM
            // 
            this.UseableRAM.AutoSize = true;
            this.UseableRAM.Location = new System.Drawing.Point(167, 102);
            this.UseableRAM.Name = "UseableRAM";
            this.UseableRAM.Size = new System.Drawing.Size(29, 15);
            this.UseableRAM.TabIndex = 3;
            this.UseableRAM.Text = "MB";
            // 
            // processChart
            // 
            this.processChart.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.processChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.processChart.Legends.Add(legend2);
            this.processChart.Location = new System.Drawing.Point(227, 230);
            this.processChart.Name = "processChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "RAM";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Legend = "Legend1";
            series4.Name = "CPU";
            this.processChart.Series.Add(series3);
            this.processChart.Series.Add(series4);
            this.processChart.Size = new System.Drawing.Size(379, 251);
            this.processChart.TabIndex = 11;
            this.processChart.Text = "chart1";
            // 
            // CheckUseable
            // 
            this.CheckUseable.Location = new System.Drawing.Point(3, 187);
            this.CheckUseable.Name = "CheckUseable";
            this.CheckUseable.Size = new System.Drawing.Size(112, 30);
            this.CheckUseable.TabIndex = 10;
            this.CheckUseable.Text = "사용량 멈춤";
            this.CheckUseable.UseVisualStyleBackColor = true;
            this.CheckUseable.Click += new System.EventHandler(this.CheckUseable_Click_1);
            // 
            // 설정
            // 
            this.설정.Controls.Add(this.label4);
            this.설정.Controls.Add(this.trackBar1);
            this.설정.HorizontalScrollbarBarColor = true;
            this.설정.HorizontalScrollbarHighlightOnWheel = false;
            this.설정.HorizontalScrollbarSize = 10;
            this.설정.Location = new System.Drawing.Point(4, 38);
            this.설정.Name = "설정";
            this.설정.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.설정.Size = new System.Drawing.Size(738, 541);
            this.설정.TabIndex = 1;
            this.설정.Text = "설정";
            this.설정.VerticalScrollbarBarColor = true;
            this.설정.VerticalScrollbarHighlightOnWheel = false;
            this.설정.VerticalScrollbarSize = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "투명도 조절";
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBar1.Location = new System.Drawing.Point(19, 68);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(192, 56);
            this.trackBar1.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(740, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "CPU 통계";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 725);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "Form1";
            this.Text = "Rotten Mango";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.프로세스.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.processChart)).EndInit();
            this.설정.ResumeLayout(false);
            this.설정.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage 프로세스;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroProgressBar metroProgressBarRAM;
        private MetroFramework.Controls.MetroProgressBar metroProgressBarCPU;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label UseableCPU;
        private System.Windows.Forms.Label UseableRAM;
        private System.Windows.Forms.DataVisualization.Charting.Chart processChart;
        private System.Windows.Forms.Button CheckUseable;
        private MetroFramework.Controls.MetroTabPage 설정;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBar1;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinnerCPU;
        private System.Windows.Forms.Label UseableRAMPer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button button1;
    }
}

