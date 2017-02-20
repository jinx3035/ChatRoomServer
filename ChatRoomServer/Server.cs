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
        string clientData;
        NetworkStream stream;


        public void RunServer()
        {
            StartServerListen();
            ReadMessage();
            ReturnMessage();
            End();
        }

        public void StartServerListen()
        {
            //bool isRunning = true;
            //while (isRunning)
            //{
                listener = new TcpListener(IPAddress.Any, 9555);
                listener.Start();
                Console.WriteLine("The server has been started. \n");
        
                Console.WriteLine("Waiting for incoming client connections...");
                client = listener.AcceptTcpClient();
                Console.WriteLine("New client connection established...");
           // }

        }

        public void ReadMessage()
        {
            stream = client.GetStream();
            while (stream.CanRead)
            {
                byte[] bytesFrom = new byte[256];
                stream.Read(bytesFrom, 0, bytesFrom.Length);
                clientData = Encoding.ASCII.GetString(bytesFrom);
            }
                
        }
        public void ReturnMessage()
        {
            do
            {
                byte[] data = null;
                data = Encoding.ASCII.GetBytes(clientData);
                stream.Write(data, 0, data.Length);
                stream.Flush();
            }
            while (stream.CanWrite);
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
