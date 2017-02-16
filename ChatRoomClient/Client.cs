using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ChatRoomClient
{
    public class Client

    {
        string message = string.Empty;
        TcpClient client;
        StreamReader reader;
        StreamWriter writer;

        public Client()
        {
            client = new TcpClient("127.0.0.1", 1024);
            reader = new StreamReader(client.GetStream());
		    writer = new StreamWriter(client.GetStream());
        }
        public void EndMessage()
        {
           client.Close();
        }

        public void SendMessage()
        {
            Console.WriteLine("Enter a message to the server");
            message = Console.ReadLine();
            writer.WriteLine(message);
            writer.Flush();

            reader = new StreamReader(client.GetStream());
            message = reader.ReadLine(); 
            string serverString = reader.ReadLine();
            Console.WriteLine(serverString);
        }
    }
}
