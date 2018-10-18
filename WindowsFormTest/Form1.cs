using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace WindowsFormTest
{
    public partial class Form1 : Form
    {
        private PerformanceCounter cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private PerformanceCounter process = new PerformanceCounter("Process", "% Processor Time", "chrome");
        private PerformanceCounter ram = new PerformanceCounter("Memory", "Available MBytes");
        string process_name = Process.GetCurrentProcess().ProcessName;

        private PerformanceCounter prcoss_cpu =
            new PerformanceCounter("Process", "% Processor Time", Process.GetCurrentProcess().ProcessName);

        private bool loop_state = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread my_thread = new Thread(check_system);
            my_thread.Start();
        }

        private void check_system()
        {
            do
            {

                //                Debug.WriteLine("cpu 사용 : " + cpu.NextValue().ToString() + " %");
                //                Debug.WriteLine("ram 사용가능량 : " + ram.NextValue().ToString() + " MB");
                //Debug.WriteLine(process_name + " cpu 사용 : " + prcoss_cpu.NextValue().ToString() + " %");
                Debug.WriteLine(process.NextValue());

                Thread.Sleep(1000);
            } while (loop_state);
        }
    }
}
