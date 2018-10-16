using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RottenMango
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private readonly PerformanceCounter _cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private readonly PerformanceCounter _ram = new PerformanceCounter("Memory", "Available MBytes");

        private readonly PerformanceCounter _ramPersentage =
            new PerformanceCounter("Memory", "% Committed Bytes In Use");

        readonly Process[] _allProc = Process.GetProcesses();

        private bool _isUseable = true;

        public Form1()
        {
            InitializeComponent();

            GetCurrentCpuUsage(); //실시간 CPU
            GetAvailableRam(); //실시간 RAM

            timer1.Interval = 500; //0.5초 간격
            timer1.Enabled = true;

            ProcessList();
        }

        public void GetCurrentCpuUsage()
        {
            float CpuUse = _cpu.NextValue();
            if (CpuUse >= 90)
                MessageBox.Show("위험!!");
            else if (CpuUse >= 70)
                MessageBox.Show("경고!!");
            UseableCPU.Text = Convert.ToString((int) CpuUse) + "%";
            metroProgressBarCPU.Value = (int) CpuUse;
            processChart.Series["CPU"].Points.AddY(CpuUse);

            metroProgressSpinnerCPU.Value = (int) CpuUse;
        }

        public void GetAvailableRam()
        {
            float RamUse = _ram.NextValue();
            float ramUsePersentage = _ramPersentage.NextValue();
            UseableRAM.Text = Convert.ToString(RamUse) + "MB";
            UseableRAMPer.Text = Convert.ToString((int) ramUsePersentage) + "%";
            metroProgressBarRAM.Value = (int) ramUsePersentage;
            processChart.Series["RAM"].Points.AddY(ramUsePersentage);
        }

        //실시간 처리 (1초마다 변경)
        private void timer1_Tick(object sender, EventArgs e)
        {
            GetCurrentCpuUsage(); //실시간 CPU
            GetAvailableRam(); //실시간 RAM            
        }


        //버튼 클릭시 
        private void CheckUseable_Click_1(object sender, EventArgs e)
        {
            if (_isUseable)
            {
                timer1.Enabled = false;
                _isUseable = false;
                CheckUseable.Text = "사용량 측정";
            }
            else
            {
                timer1.Enabled = true;
                _isUseable = true;
                CheckUseable.Text = "사용량 멈춤";
            }

            GetCurrentCpuUsage(); //실시간 CPU
            GetAvailableRam(); //실시간 RAM
        }

        // 프로그램 관리 리스트
        public void ProcessList()
        {
            try
            {
                foreach (Process ap in _allProc)
                {
                    dataGridView.Rows.Add(
                        ap.ProcessName,
                        ap.WorkingSet64,
                        ap.Id,
                        ap.VirtualMemorySize64
                    );
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e}");
            }
        }

        // 시작프로그램 레지스터리 리스트
        public void StartRegistryList()
        {
            const string runKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
            using (RegistryKey startupKey = Registry.LocalMachine.OpenSubKey(runKey))
            {
                var valueNames = startupKey.GetValueNames();

                // Name => File path
                Dictionary<string, string> appInfos = valueNames
                    .Where(valueName => startupKey.GetValueKind(valueName) == RegistryValueKind.String)
                    .ToDictionary(valueName => valueName, valueName => startupKey.GetValue(valueName).ToString());
            }
        }
    }
}