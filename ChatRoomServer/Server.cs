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
        TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8000);
        TcpClient client = new TcpClient("127.0.0.1", 8000);
        

        public void StartServer()
        {
            listener.Start();
        }

        public void Listen()
        {
            client = listener.AcceptTcpClient();           
        }

        public void ProcessMessage()
        {
            StreamReader reader = new StreamReader(client.GetStream());
            StreamWriter writer = new StreamWriter(client.GetStream());
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
