using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Qnet
{
    public partial class Client
    {
        private ConnectionInfo CI;


        public Socket ListenSocket, ServerSocket;
        public bool _running = false;


        private Thread _connectionThread;


        //constructors
        public Client(string ServerIP)
        {
            CI = new ConnectionInfo(IPAddress.Parse(ServerIP), 11010, 11011);
        }


        //Properties
        public bool isRunning { get { return this._running; } }

        //Methods
            //gets external IP of local instance


        public void NetworkStart()
        {
            if (!_running)
            {
                this._running = true;
                this._connectionThread = new Thread
                    (new ThreadStart(StartListening));
                ListenSocket = new Socket
                    (CI.RemoteAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                ServerSocket = new Socket
                    (CI.RemoteAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            }
        }
        public void NetworkStop() { if (this._running) { this._running = false; } }


        private void StartListening()
        {
            ServerEndPoint = CI.RemoteEndPoint;


        }

    }
}