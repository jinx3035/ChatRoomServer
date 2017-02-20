using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ChatRoomServer
{
    public class Server
    {

        TcpListener listener;
        TcpClient client;

        public void RunServer()
        {
            StartServer();
            Listen();
            ProcessMessage();
            End();
        }

        public void StartServer()
        {
            listener = new TcpListener(IPAddress.Any, 45000);
            listener.Start();
            Console.WriteLine("The server has been started.");
        }

        public void Listen()
        {
            while(true)
            {
                Console.WriteLine("Waiting for incoming client connections...");
                client = listener.AcceptTcpClient();
                Console.WriteLine("New client connection established...");
            }

        }

        public void ProcessMessage()
        {
            byte[] bytesFrom = new byte[256];
            NetworkStream networkStream = client.GetStream();
            networkStream.Read(bytesFrom, 0, bytesFrom.Length);
            string clientData = Encoding.ASCII.GetString(bytesFrom);

            byte[] data = null;
            data = Encoding.ASCII.GetBytes(clientData);
            networkStream.Write(data, 0, data.Length);
            networkStream.Flush();
        }
        
        public void End()
        {
            listener.Stop();
        }
    }        
}







//IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 8080);
//Socket newSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//newSocket.Bind(endpoint);
//newSocket.Listen(10);
//Socket client = newSocket.Accept();
