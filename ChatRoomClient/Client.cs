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
        string message;
        public Client()
        {
            TcpClient client = new TcpClient("127.0.0.1", 8000);
            StreamReader reader = new StreamReader(client.GetStream());
			StreamWriter writer = new StreamWriter(client.GetStream());
        }
        public void CloseMessage()
        {
           // Close();

        }

        public string DisplayMessage()
        {
            Console.WriteLine("Enter a message to the server");
            message = Console.ReadLine();
            return message;
        }
    }
}
