using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using static Qnet.Protocols;

namespace Qnet
{
    public partial class Server
    {
        private Dictionary<QnID, System.Object> InstanceLibrary;
        private Dictionary<int, QnID> NetWorkIDLibrary;

        //declare connection variables like ip address and port constants
        //fields
        private IPHostEntry ipHostInfo;
        private IPAddress IPAddress;

        //Inspector settable//maybe make global?
        public int ServerPort = 11010;
        public int ClientPort = 11011;


        //control fields
        private Socket listener;

        public bool _running = false;


        //establish listener on designated tcp port
        //Thread body for listening for client connections



        private void StartListening()
        {
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress, ServerPort);

            using (listener = new Socket
                (IPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
            {
                //catch any exceptions and print them
                try
                {
                    listener.Bind(localEndPoint);
                    listener.Listen(10);

                    while (this._running)
                    {
                        Console.WriteLine("Waiting for a connection..");

                        QnMessage messageBuffer = new QnMessage();
                        Socket handler = listener.Accept();
                        lock (this)
                        {
                            using (handler)
                            {
                                int dataSize = handler.Receive(messageBuffer.Data);
                                object objProtocol = Deserialize(messageBuffer);
                                Console.WriteLine("connection received");
                                //ProcessQnMessage(objProtocol, handler);
                            }
                        } //End Lock
                    }//if still running, loop back to accept another request
                }
                catch (Exception e)
                {
                    UnityEngine.Debug.Log(e.ToString());
                }
            }
        }

    }
}