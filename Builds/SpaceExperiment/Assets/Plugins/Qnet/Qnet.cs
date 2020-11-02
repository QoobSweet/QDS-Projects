using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

namespace Qnet
{
    //Interfaces for Qnet
    public class ConnectionInfo
    {
        //fields
        private bool _isInitialized;
        private IPAddress _localIPAddress, _remoteAddress;
        private int _listenPort = 11011, _remotePort = 11010;
        private IPEndPoint _remoteEndPoint;


        //accesors
        public IPAddress LocalIPAddress { get { return _localIPAddress; } set { _localIPAddress = value; } }
        public IPAddress RemoteAddress { get { return _remoteAddress; } set { _remoteAddress = value; } }
        public int ListenPort { get { return _listenPort; } }
        public int RemotePort { get { return _remotePort; } }


        //constructor
        public ConnectionInfo(IPAddress RemoteIP, int ListenPort, int RemotePort)
        {
            RemoteAddress = RemoteIP;
            _listenPort = ListenPort;
            _remotePort = RemotePort;
        }

        public IPEndPoint RemoteEndPoint
        {
            get
            {
                if (_remoteEndPoint != null)
                    { _remoteEndPoint = new IPEndPoint(RemoteAddress, RemotePort); }
                
                return _remoteEndPoint;
            }
        }




        public IPAddress GetExternalIP()
        {
            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }
            return IPAddress.Parse(localIP);
        }
    }



}
