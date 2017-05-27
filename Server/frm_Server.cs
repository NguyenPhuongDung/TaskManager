using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using TaskManager;

namespace Server
{
    public partial class frm_Server : Form
    {
        public List<clientManager> _lstClient;

        TcpListener _tcpListener;// listnenner
        TcpClient _tcpClient;// tcp was accept
        Thread _thread;
        clientManager _clientMng;// info of client
        IPAddress _svrIP;
        int _svrPort;
        int _id;
        Info InfoFromClient;
        public frm_Server()
        {
            InitializeComponent();
        }
        //load ip and port to connect
        private void loadCfg()
        {
            try
            {
                XmlDocument config = new XmlDocument();
                string path = Application.StartupPath + @"\config.xml";
                config.Load(path);
                _svrIP = IPAddress.Parse(config.SelectSingleNode("//ip").InnerText);
                _svrPort = Int32.Parse(config.SelectSingleNode("//port").InnerText);
            }
            catch
            {
                frm_Setting frmSetting = new frm_Setting();
                frmSetting.ShowDialog();
                frmSetting.Dispose();
            }
        }
        //begin accept connect from client and add to dgv
        private void listener()
        {
            _id = 1;
            try
            {
                _tcpListener = new TcpListener(_svrIP, _svrPort);
                _tcpListener.Start();
                lbl_Info.Text = "SERVER - IP: " + _svrIP + "; PORT: " + _svrPort;
                while (true)
                {
                    _tcpClient = _tcpListener.AcceptTcpClient();
                    _clientMng = new clientManager(_id, _tcpClient);
                    dataGridView.Rows.Add(_id, "", "", "");
                    _clientMng._thread = new Thread(doListen);
                    _clientMng._thread.Start();
                    _lstClient.Add(_clientMng);
                    Thread.Sleep(1000);
                    _id++;
                }
            }
            catch
            {
                int error = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
                if (error != 10004)
                {
                    lbl_Info.Text = "";
                    MessageBox.Show("Lỗi khởi tạo Server!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // begin listenner from messager was send by client
        private void doListen()
        {
            TcpClient tcpClient = _tcpClient;
            clientManager client = _clientMng;
            NetworkStream netStream = tcpClient.GetStream();
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[tcpClient.ReceiveBufferSize];
                    int x = netStream.Read(buffer, 0, tcpClient.ReceiveBufferSize);
                    int ii = buffer.Length - 1;
                    while (buffer[ii] == 0)
                    {
                        --ii;
                    }
                    byte[] data = new byte[ii + 1];
                    Array.Copy(buffer, data, ii + 1);

                    try
                    {

                        InfoFromClient = (Info)DeserializeData(data);
                        if (InfoFromClient != null)
                        {
                            LoadProcess();
                        }
                        else
                        {
                            MessageBox.Show("NA");
                        }
                    }
                    catch
                    {
                        string receive = Encoding.UTF8.GetString(buffer).Trim();
                        string[] spl = receive.Split('|');
                        switch (spl[0].ToUpper())
                        {
                            case "NAME":
                                for (int i = 0; i < dataGridView.Rows.Count; i++)
                                {
                                    if (Equals(dataGridView.Rows[i].Cells[0].Value.ToString(), client._id.ToString()))
                                    {
                                        dataGridView.Rows[i].Cells[1].Value = spl[1];
                                        break;
                                    }
                                }
                                break;
                            case "IP":
                                for (int i = 0; i < dataGridView.Rows.Count; i++)
                                {
                                    if (Equals(dataGridView.Rows[i].Cells[0].Value.ToString(), client._id.ToString()))
                                    {
                                        dataGridView.Rows[i].Cells[2].Value = spl[1];
                                        break;
                                    }
                                }
                                break;
                            case "EXIT":
                                for (int i = 0; i < dataGridView.Rows.Count; i++)
                                {
                                    if (Equals(dataGridView.Rows[i].Cells[0].Value.ToString(), client._id.ToString()))
                                    {
                                        string name = dataGridView.Rows[i].Cells[1].Value.ToString();
                                        string ip = dataGridView.Rows[i].Cells[2].Value.ToString();
                                        MessageBox.Show("Máy: " + name + "; Địa chỉ IP: " + ip + " đã ngắt kết nối do người dùng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        if (String.IsNullOrEmpty(dataGridView.Rows[i].Cells[3].Value.ToString()))
                                            dataGridView.Rows[i].Cells[3].Value = "Đã ngắt kết nối";
                                        else
                                            dataGridView.Rows[i].Cells[3].Value = dataGridView.Rows[i].Cells[3].Value.ToString() + "; Đã ngắt kết nối";
                                        break;
                                    }
                                }
                                break;
                        }
                    }
                }
                catch
                {
                    client._thread.Abort();
                }
            }
        }
        private void sendMsg(string msg, TcpClient tcp)
        {
            TcpClient tcpClient = tcp;
            NetworkStream netStream = tcpClient.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(msg + "|");
            netStream.Write(buffer, 0, buffer.Length);
            netStream.Flush();
        }
        private void frm_Server_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            loadCfg();
            _thread = new Thread(listener);
            _thread.Start();
            _lstClient = new List<clientManager>(); ;
        }
        private void btnLoadProcess_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id != 0)
            {
                clientManager client = searchClient(id);
                if (client != null)
                {
                    sendMsg("PROCESS|", client._tcpClient);
                }
            }
            else
                MessageBox.Show("Chọn máy cần thao tác!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        //EXIT
        private void frm_Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
            else
            {
                try
                {
                    foreach (clientManager client in _lstClient)
                    {
                        try
                        {
                            sendMsg("EXIT|", client._tcpClient);
                            client._thread.Abort();
                        }
                        catch { }
                    }
                    _thread.Abort();
                    _tcpListener.Stop();

                }
                catch { }
                Environment.Exit(1);
            }
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Setting frmSetting = new frm_Setting();
            frmSetting.ShowDialog();
            frmSetting.Dispose();
        }
        //PROCESS
        private void processToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id != 0)
            {
                clientManager client = searchClient(id);
                if (client != null)
                {
                    sendMsg("PROCESS|", client._tcpClient);
                }
            }
            else
                MessageBox.Show("Chọn máy cần thao tác!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        //EXIT
        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (clientManager client in _lstClient)
                {
                    try
                    {
                        sendMsg("EXIT|", client._tcpClient);
                        client._thread.Abort();
                    }
                    catch { }
                }
                _tcpListener.Stop();
                _thread.Abort();
                dataGridView.Rows.Clear();
            }
            catch { }
            frm_Server_Load(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
        //RESTART
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id != 0)
            {
                clientManager client = searchClient(id);
                if (client != null)
                {
                    sendMsg("RESTART|", client._tcpClient);
                }
            }
            else
                MessageBox.Show("Chọn máy cần thao tác!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        //SHUTDOWN
        private void shutdownToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id != 0)
            {
                clientManager client = searchClient(id);
                if (client != null)
                {
                    sendMsg("SHUTDOWN|", client._tcpClient);
                }
            }
            else
                MessageBox.Show("Chọn máy cần thao tác!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        //ENDTASK


        private int getId()
        {
            try
            {
                return int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString());
            }
            catch { }
            return 0;
        }
        private clientManager searchClient(int id)
        {
            foreach (clientManager client in _lstClient)
            {
                if (client._id == id)
                {
                    return client;
                }
            }
            return null;
        }
        void GetProcess(ProcessClient[] listProcess)
        {


            this.listProcess.Items.Clear();
            foreach (var item in listProcess)
            {
                ListViewItem newItem = new ListViewItem() { Text = item.nameProcess };
                newItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.idProcess.ToString() });
                newItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = (item.cpu + " %") });
                newItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = (Math.Round(item.ram, 2) + " MB") });
                this.listProcess.Items.Add(newItem);
            }

        }
        void LoadProcess()
        {
            GetProcess(InfoFromClient.process);
            tstripTotalProcess.Text = "Total Process: " + InfoFromClient.process.Count().ToString();
            colCPU.Text = " CPU " + Math.Round(InfoFromClient.totalCPU, 2) + " %";
            colMemory.Text = " RAM " + Math.Round(InfoFromClient.totalMemory, 2) + "%";
        }
        // giai nen 1 mang byte thanh 1 doi tuong (bject)
        public object DeserializeData(byte[] theByteArray)
        {
            MemoryStream ms = new MemoryStream(theByteArray);
            BinaryFormatter bf1 = new BinaryFormatter();
            ms.Position = 0;
            return bf1.Deserialize(ms);
        }

        private void endTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                int id = getId();
                if (id != 0)
                {
                    if (listProcess.SelectedItems.Count > 0)
                    {
                        clientManager client = searchClient(id);
                        if (client != null)
                        {
                            sendMsg("ENDTASK|" + listProcess.SelectedItems[0].SubItems[1].Text, client._tcpClient);
                        }
                    }
                }
                else
                    MessageBox.Show("Chọn máy cần thao tác!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                int id = getId();
                if (id != 0)
                {

                    clientManager client = searchClient(id);
                    if (client != null)
                    {
                        sendMsg("TEST|", client._tcpClient);
                    }
                }
                else
                    MessageBox.Show("Chọn máy cần thao tác!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNewProcess_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id != 0)
            {
                clientManager client = searchClient(id);
                if (client != null)
                {
                    string msg = "NEWPROCESS|" + txtNewProcess.Text;
                    sendMsg(msg, client._tcpClient);
                    txtNewProcess.Clear();
                }
            }
            else
                MessageBox.Show("Chọn máy cần thao tác!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
