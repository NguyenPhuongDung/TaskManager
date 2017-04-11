using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Management;
namespace TaskManager
{
    public partial class Form1 : Form
    {
        private static PerformanceCounter TotalCpuUsage = new PerformanceCounter("Process", "% Processor Time", "Idle");
        public Form1()
        {
            InitializeComponent();
            //GetFileDescription();
            GetProcess();
            //GetThreds();

        }
        Process[] process;
        void GetFileDescription()
        {
            var searcher = new ManagementObjectSearcher("Select * From Win32_Process");
            var processList = searcher.Get();

            foreach (var process in processList)
            {
                var processName = process["Name"];
                var processPath = process["ExecutablePath"];

                if (processPath != null)
                {
                    FileVersionInfo fileVersionInfo = null;
                    var processDescription = "";
                    try
                    {
                        fileVersionInfo = FileVersionInfo.GetVersionInfo(processPath.ToString());
                        processDescription = fileVersionInfo.FileDescription;
                    }
                    catch (Exception e)
                    {
                        processDescription = "";
                    }
                    string text = "";
                    
                        
                    if (processDescription == "")
                    {
                      text = processName.ToString();   
                    }
                    else
                    {
                        text = processDescription;
                    }
                    ListViewItem newItem = new ListViewItem() { Text=text };
                    newItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text ="" });
                    listProcess.Items.Add(newItem);
                }
            }
        }
        void GetProcess()
        {
            process = Process.GetProcesses();
            listProcess.Items.Clear();
            label1.Text = process.Count().ToString();
            foreach (var item in process)
            {
                    ListViewItem newItem = new ListViewItem() { Text = item.ProcessName };
                    //newItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.MainWindowTitle });
                    newItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text =item.Id.ToString() });
                    listProcess.Items.Add(newItem);
            }
            
        }
        void GetThreds()
        {
            Process thisProc = Process.GetCurrentProcess();
            ProcessThreadCollection myThreads = thisProc.Threads;
            foreach (ProcessThread pt in myThreads)
            {
                DateTime statTime = pt.StartTime;
                TimeSpan cpuTime = pt.TotalProcessorTime;
                int priority = pt.BasePriority;
                ThreadState ts = pt.ThreadState;
                MessageBox.Show(pt.Id.ToString());
                MessageBox.Show(statTime.ToString());
                MessageBox.Show(cpuTime.ToString());
                MessageBox.Show(priority.ToString());
            }
           
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (process.Length != Process.GetProcesses().Length)
            {
                GetProcess();
            }
            float cpuPercent = getCPUCounter();
            if (cpuPercent >= 90)
            {
                totalHits = totalHits + 1;
                //if (totalHits == 60)
                ////{
                ////    Interaction.MsgBox("ALERT 90% usage for 1 minute");
                ////    totalHits = 0;
                ////}
            }
            else
            {
                totalHits = 0;
            }
            label2.Text = cpuPercent + " % CPU";
            //Label2.Text = getRAMCounter() + " RAM Free";
            //Label3.Text = totalHits + " seconds over 20% usage";
        }

        private void endTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                process = Process.GetProcesses();
                if (listProcess.SelectedItems.Count > 0)
                {
                    int index = 0;
                    foreach (var item in process)
                    {
                        if (item.ProcessName == listProcess.SelectedItems[0].Text)
                        {
                            index = process.ToList().IndexOf(item);
                            break;
                        }
                    }
                    process[index].Kill();
                }
            }
            catch
            {
                MessageBox.Show("Bạn cần truy cập với quyền Admistrator");
            }
        }

        private void listProcess_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        int totalHits = 0;

        public float getCPUCounter()
        {

            PerformanceCounter cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";

            // will always start at 0
            dynamic firstValue = cpuCounter.NextValue();
            System.Threading.Thread.Sleep(1000);
            // now matches task manager reading
            dynamic secondValue = cpuCounter.NextValue();

            return secondValue;

        }


        private void Timer1_Tick(Object sender, EventArgs e)
        {
            
        }
       
    }
}
