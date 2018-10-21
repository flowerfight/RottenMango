using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using RottenMango.Data;
using System.Management;

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

        // CPU값 받기
        List<string> processNameList = new List<string>();

        private Dictionary<string, PerformanceCounter> PerformanceCountersCPU =
            new Dictionary<string, PerformanceCounter>();

        private Dictionary<string, Process> PerformanceCountersRAM =
            new Dictionary<string, Process>();

        private int no = 0;

        private Boolean statisticEnable = false;

        // 메인 Form
        public Form1()
        {
            InitializeComponent();

            GetCurrentCpuUsage(); //실시간 CPU
            GetAvailableRam(); //실시간 RAM

            timer1.Interval = 500; //0.5초 간격
            timer1.Enabled = true;

            Thread my_thread = new Thread(new ThreadStart(_check_system));
            my_thread.Start();


//            ProcessList();
        }

        //사용중인 CPU
        public void GetCurrentCpuUsage()
        {
            float CpuUse = _cpu.NextValue();
//            if (CpuUse >= 90)
//                MessageBox.Show("위험!!");
//            else if (CpuUse >= 70)
//                MessageBox.Show("경고!!");
            UseableCPU.Text = Convert.ToString((int) CpuUse) + "%";
            metroProgressBarCPU.Value = (int) CpuUse;
            processChart.Series["CPU"].Points.AddY(CpuUse);

            metroProgressSpinnerCPU.Value = (int) CpuUse;
        }

        //사용가능한 RAM
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

//            ProcessList();
        }


        //CPU 실시간 측정 버튼 클릭시 ( 사용 or 멈춤 )  
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


        // 현재 CPU 값 받아오기
        private bool isFirst = true;
        public PerformanceCounter process_cpu;
        List<string> list = new List<string>();
        private string cpuName = "";

        //        public void ProcessList()
        //        {
        //            try
        //            {
        //                int num = 0;
        //                if (isFirst)
        //                {
        //                    foreach (Process ap in _allProc)
        //                    {
        //                        // 프로그램 관리 리스트
        //                        process_cpu =
        //                            new PerformanceCounter("Process", "% Processor Time", ap.ProcessName);
        //                        cpuName = ap.ProcessName;
        //
        //                        dataGridView.Rows.Add(
        //                            num++,
        //                            ap.ProcessName,
        //                            ap.WorkingSet64,
        //                            ap.Id,
        //                            ap.VirtualMemorySize64,
        //                            process_cpu.NextValue()
        //                        );
        //                        list.Add(cpuName);
        //                    }
        //
        //                    isFirst = false;
        //                }
        //                else
        //                {
        //                    for (int i = 0; i < dataGridView.RowCount - 1; i++)
        //                    {
        //                        try
        //                        {
        //                            string pidname = dataGridView.Rows[i].Cells["pidName"].Value.ToString();
        ////                            Debug.WriteLine(pidname);
        //                            if (pidname == "WmiApSrv") continue;
        //                            process_cpu =
        //                                new PerformanceCounter("Process", "% Processor Time", pidname);
        ////                            Debug.WriteLine(process_cpu.NextValue());
        //                            Debug.WriteLine(list.Count);
        ////                            dataGridView.Rows[i].Cells["row"].Value = list.IndexOf(i);
        //                        }
        //                        catch (Exception e)
        //                        {
        //                            Debug.WriteLine(e);
        //                        }
        //                    }
        //                }
        //            }
        //            catch (Exception e)
        //            {
        //                Debug.WriteLine(e);
        //            }
        //        }


        DailySummaryData dailySummaryData = new DailySummaryData(); // total cpu, memory => DB conn         
        ProcessSnapshotData processSnapshotdata = new ProcessSnapshotData();

        // use `/ 1048576` to get ram in MB
        // and `/ (1048576 * 1024)` or `/ 1048576 / 1024` to get ram in GB
        private double getRAMsize()
        {
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject item in moc)
            {
                return Math.Round(Convert.ToDouble(item.Properties["TotalPhysicalMemory"].Value) / 1048576, 0);
            }

            return 0;
        }

        private void _check_system()
        {
            do
            {
                List<Process> _processes = Process.GetProcesses().ToList();
                //프로세스별 Memory Dictionary
                Dictionary<string, float> usingMemory = new Dictionary<string, float>();
                
                foreach (Process process in _processes)
                {
                    if(process.ProcessName == "Idle") continue;

                    if (usingMemory.ContainsKey(process.ProcessName))
                    {
                        usingMemory[process.ProcessName] = usingMemory[process.ProcessName] +
                            process.WorkingSet64 ;
                    }
                    else
                    {
                        usingMemory.Add(process.ProcessName,process.WorkingSet64);
                    }

                    if (!processNameList.Contains(process.ProcessName))
                    {
                        processNameList.Add(process.ProcessName);

                        PerformanceCountersCPU.Add(process.ProcessName,
                            new PerformanceCounter("Process", "% Processor Time", process.ProcessName));

                        PerformanceCountersRAM.Add(process.ProcessName,
                            process);


                        Invoke(new Action(delegate()
                        {
                            try
                            {
                                cpuGridView.Rows.Add(
                                    no,
                                    process.ProcessName,
                                    PerformanceCountersCPU[process.ProcessName].NextValue()
                                );

                                MemoryGridView.Rows.Add(
                                    no++,
                                    process.ProcessName,
                                    0
                                );
                            }
                            catch (Exception e)
                            {

                            }
                        }));
                    }
                }

                float usingCpu;
                float usingMemoryValue;
                string ProcessName;

                Dictionary<string,float> cpuUsageList
                    = new Dictionary<string, float>();

                Dictionary<string, float> memoryUsageList
                    = new Dictionary<string, float>();

                for (int i = 0; i < cpuGridView.Rows.Count; i++)
                {
                    try
                    {
                        ProcessName = cpuGridView.Rows[i].Cells["procName"].Value.ToString();
                        usingCpu = PerformanceCountersCPU[ProcessName].NextValue()/Environment.ProcessorCount;
//                        usingMemory = Process.GetProcessesByName(ProcessName).

                        cpuGridView.Rows[i].Cells["cpuValue"].Value = usingCpu;

                        if (usingCpu != 0 && ProcessName != "Idle") {
                            cpuUsageList.Add(ProcessName, usingCpu);
                            memoryUsageList.Add(ProcessName, usingMemory[ProcessName]);
                            processSnapshotdata.Insert(
                                ProcessName,
                                usingCpu,
                                usingMemory[ProcessName],
                                DateTime.Now
                            );
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                    }
                }

                for (int i = 0; i < MemoryGridView.Rows.Count; i++)
                {
                    try
                    {
                        ProcessName = MemoryGridView.Rows[i].Cells["memoryProcName"].Value.ToString();
                        usingMemoryValue = usingMemory[ProcessName];
                        //                        usingMemory = Process.GetProcessesByName(ProcessName).

                        double memvalue = (double) usingMemoryValue;

                        if (memvalue > 1024 * 1024)
                        {
                            MemoryGridView.Rows[i].Cells["memoryValue"].Value 
                                = Math.Round(memvalue/1024/1024,2) + " MB";
                        }
                        else if (memvalue > 1024)
                        {
                            MemoryGridView.Rows[i].Cells["memoryValue"].Value
                                = Math.Round(memvalue / 1024, 2) + " KB";
                        }
                        else

                        {
                            MemoryGridView.Rows[i].Cells["memoryValue"].Value
                                = memvalue + " B";
                        }
                        

                        if (usingMemoryValue != 0 && ProcessName != "Idle")
                        {
                            memoryUsageList.Add(ProcessName, usingMemoryValue);
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                    }
                }

                //그리드뷰 정렬
                //                cpuGridView.Sort();

                processSnapshotdata.Getcontext().SaveChanges();


                // cpu 및 memory 점유율 상위10 표시
                var queryOfCPU = from x in cpuUsageList
                            orderby x.Value descending 
                            select x;

                var listOfTop10CPU = queryOfCPU.Take(10).ToList();

                var queryOfRAM = from x in memoryUsageList
                    orderby x.Value descending
                    select x;

                var listOfTop10RAM = queryOfRAM.Take(10).ToList();

                for (int i=0; i<10; i++)
                {
                    Invoke(new Action(delegate ()
                    {
                        if(listOfTop10CPU.Count-1 >= i)
                            top10CPUList.Items[i].Text = (i+1)+ ". " + listOfTop10CPU[i].Key +" ("+ 
                                                         Math.Round(listOfTop10CPU[i].Value,2) + "%)";
                        else
                        {
                            top10CPUList.Items[i].Text = "";
                        }

                        if (listOfTop10RAM.Count - 1 >= i)
                            top10RAMList.Items[i].Text = (i + 1) + ". " + listOfTop10RAM[i].Key + " (" 
                                                         +Math.Round(
                                                         (listOfTop10RAM[i].Value/1024/1024/ getRAMsize())*100,2) + "%)";
                        else
                        {
                            top10RAMList.Items[i].Text = "";
                        }
                        
                    }));
                }
               

            } while (true);
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

        // 탭 별 기능
        private void metroTabPage1_Click(object sender, EventArgs e)
        {
        }


        
        // 기간별 통계확인
        private void statistic_Button_Click(object sender, EventArgs e)
        {
            string start = "2018 - 10 - 19 15:48:22.483";
            string end = "2018-10-19 15:48:27.103";
            processSnapshotdata.SummaryMaker(start, end);

            statisticGridView.Rows.Clear();

            if (!statisticEnable)
            {
                statisticEnable = true;

                foreach (var item in processSnapshotdata.GetSummary(period.SelectedItem.ToString()))
                {
                    Invoke(new Action(delegate() { statisticGridView.Rows.Add(
                        item.name,
                        item.avgCPU,
                        item.avgMemory,
                        item.Date.Year + "-" + item.Date.Month + "-" +   item.Date.Day
                        ); }));
                }

                statisticEnable = false;
            }
            else
            {
                Debug.WriteLine("사용불가");
            }

        }
    }
}