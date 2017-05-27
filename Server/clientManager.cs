using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class clientManager
    {
        public int _id;
        public TcpClient _tcpClient;
        public Thread _thread;

        public clientManager(int id, TcpClient tcpClient)
        {
            this._id = id;
            this._tcpClient = tcpClient;
        }
    }
}
