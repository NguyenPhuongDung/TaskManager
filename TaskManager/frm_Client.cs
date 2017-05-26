using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TaskManager
{
    public partial class frm_Client : Form
    {

        TcpClient _tcpClient;
        Thread _thread, _threadRM;

        IPAddress _svrIP;
        int _svrPort;
        int _svrPortRM;
        bool _exit = false;
        Process[] _process;
        List<ProcessClient> list;
        Info[] allInfo = new Info[100];
        Info allProcess;
        public frm_Client()
        {
            InitializeComponent();
        }
        private void loadCfg()
        {
            try
            {
                XmlDocument config = new XmlDocument();
                string path = Application.StartupPath + @"\config.xml";
                config.Load(path);
                _svrIP = IPAddress.Parse(config.SelectSingleNode("//ip").InnerText);
                _svrPort = Int32.Parse(config.SelectSingleNode("//port").InnerText);
                _svrPortRM = Int32.Parse(config.SelectSingleNode("//portRM").InnerText);
            }
            catch
            {
                frm_Setting frmSetting = new frm_Setting();
                frmSetting.ShowDialog();
                frmSetting.Dispose();
            }
        }
        private void connect()
        {
            try
            {
                _tcpClient = new TcpClient();
                _tcpClient.Connect(_svrIP, _svrPort);
                sendInfo();
                _thread = new Thread(doListen);
                _thread.Start();
                lbl_Info.Text = "Đã kết nối đến Server - " + _svrIP;
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến Server!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void sendInfo()
        {
            string msg;
            msg = "NAME|" + Dns.GetHostName();
            sendMsg(msg);
            Thread.Sleep(1000);
            IPEndPoint ipEP = (IPEndPoint)_tcpClient.Client.RemoteEndPoint;
            IPAddress ipAdd = ipEP.Address;
            msg = "IP|" + ipAdd.ToString();
            sendMsg(msg);
        }
        private void sendMsg(string msg)
        {
            NetworkStream netStream = _tcpClient.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(msg + "|");
            netStream.Write(buffer, 0, buffer.Length);
            netStream.Flush();
        }

        private void doListen()
        {
            NetworkStream netStream = _tcpClient.GetStream();
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[_tcpClient.ReceiveBufferSize];
                    netStream.Read(buffer, 0, _tcpClient.ReceiveBufferSize);
                    string receive = Encoding.UTF8.GetString(buffer).Trim();
                    string[] spl = receive.Split('|');
                    switch (spl[0].ToUpper())
                    {

                        case "PROCESS":
                            allProcess = new Info(getCPUCounter(), getMemoryCounter(), getData());
                            byte[] data = SerializeData(allProcess);
                            Info ifo = (Info)DeserializeData(data);
                            try
                            {
                                netStream.Write(data, 0, data.Length);
                            }
                            catch (Exception e) { MessageBox.Show(e.Message); }
                            netStream.Flush();
                            netStream.Close();
                            _tcpClient.Close();
                            break;

                        case "EXIT":
                            lbl_Info.Text = "Server đã tắt!";
                            _thread.Abort();
                            _tcpClient.Close();
                            break;
                        case "SENDALL":
                            MessageBox.Show(spl[1], "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case "ENDPROCESS":
                            sendMsg(spl[1] + "|" + spl[2]);
                            break;
                    }
                }
                catch
                {
                    _thread.Abort();
                }
            }
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Setting frmSetting = new frm_Setting();
            frmSetting.ShowDialog();
            frmSetting.Dispose();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Client_Load(sender, e);
        }

        private void frm_Client_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            loadCfg();
            connect();
        }

        //process
        // nen data thanh 1 mang byte
        // nen data thanh 1 mang byte
        public byte[] SerializeData(Object o)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, o);
            return ms.ToArray();
        }

        // giai nen 1 mang byte thanh 1 doi tuong (bject)
        public object DeserializeData(byte[] theByteArray)
        {
            MemoryStream ms = new MemoryStream(theByteArray);
            BinaryFormatter bf1 = new BinaryFormatter();
            ms.Position = 0;
            return bf1.Deserialize(ms);
        }
        public ProcessClient[] getData()
        {
            _process = Process.GetProcesses();
            // tao va lay du lieu tu form
            list = new List<ProcessClient>();
            foreach (Process item in _process)
            {
                PerformanceCounter ramCounter = new PerformanceCounter("Process", "Working Set - Private", item.ProcessName);
                PerformanceCounter cpuCounter = new PerformanceCounter("Process", "% Processor Time", item.ProcessName);
                ProcessClient prc = new ProcessClient();
                prc.nameProcess = item.ProcessName;
                prc.idProcess = item.Id;
                prc.ram = ramCounter.NextValue() / 1024 / 1024;
                prc.cpu = cpuCounter.NextValue();
                list.Add(prc);
            }
            GetProcess(list.ToArray());

            ProcessClient[] listProcess = list.ToArray();
            return listProcess;
        }
        void GetProcess(ProcessClient[] listProcess)
        {


            dgvlistProcess.Items.Clear();
            foreach (var item in listProcess)
            {
                ListViewItem newItem = new ListViewItem() { Text = item.nameProcess };
                newItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.idProcess.ToString() });
                newItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = (item.cpu + " %") });
                newItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = (Math.Round(item.ram, 2) + " MB") });
                dgvlistProcess.Items.Add(newItem);
            }

        }
        public double getCPUCounter()
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
        public double getMemoryCounter()
        {

            PerformanceCounter ramCounter = new PerformanceCounter();
            ramCounter.CategoryName = "Memory";
            ramCounter.CounterName = "% Committed Bytes In Use";
            // will always start at 0
            dynamic firstValue = ramCounter.NextValue();
            System.Threading.Thread.Sleep(1000);
            // now matches task manager reading
            dynamic secondValue = ramCounter.NextValue();
            return secondValue;

        }




    }
}
