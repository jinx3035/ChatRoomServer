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
        NetworkStream networkStream;

        public void StartServer()
        {
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 1024);
            listener.Start();
            Console.WriteLine("The server has been started.");
        }

        public void Listen()
        {
            Console.WriteLine("Waiting for incoming client connections...");
            client = listener.AcceptTcpClient();
            Console.WriteLine("New client connection established...");
        }

        public void ProcessMessage()
        {
            byte[] incommingBytes = new byte[256];
            string dataFromClient = null;

            networkStream = client.GetStream();
            networkStream.Read(incommingBytes, 0, (int)client.ReceiveBufferSize);
            dataFromClient = Encoding.ASCII.GetString(incommingBytes);
            ReturnMessage(dataFromClient);

            //dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));


        }

        public static void ReturnMessage(string msg)
        {
            Byte[] broadcastBytes = null;
            broadcastBytes = Encoding.ASCII.GetBytes(msg);
        }

        public void End()
        {
            listener.Stop();
        }

        //reader = new StreamReader(client.GetStream());
        //    message = reader.ReadLine();
        //    Console.WriteLine("From client -> " + message);
        //    Console.WriteLine("From server -> " + message);
        //    writer = new StreamWriter(client.GetStream());
        //    this.message = this.reader.ReadLine();
        //    string clientString = this.reader.ReadLine();
        //writer.WriteLine(clientString);
        //    writer.Flush();        
    }

}







//IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 8080);
//Socket newSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//newSocket.Bind(endpoint);
//newSocket.Listen(10);
//Socket client = newSocket.Accept();
