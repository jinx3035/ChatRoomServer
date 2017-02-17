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
        TcpClient client;
        NetworkStream writer;
        NetworkStream reader;

        public Client()
        {
            client = new TcpClient("127.0.0.1", 1024);
            reader = client.GetStream();
		    writer = client.GetStream();
        }

        public void SendMessage()
        {
            if (!(writer.CanWrite)) { throw new Exception(); }
            else
            {
                try
                {
                    byte[] data = Encoding.ASCII.GetBytes("Enter a message to the server");
                    writer.Write(data, 0, data.Length);
                }
                catch { Console.WriteLine("There was a problem sending your message."); }
            }
        }

        public void ReadMessage()
        {
            if (!(reader.CanRead)) { throw new Exception(); }
            else
            {
                try
                {
                    byte[] data = new byte[256];
                    StringBuilder completeMessage = new StringBuilder();
                    int bytesRead = 0;
                    do
                    {
                        bytesRead = reader.Read(data, 0, data.Length);
                        completeMessage.AppendFormat("{0}", Encoding.ASCII.GetString(data, 0, bytesRead));
                    }
                    while (reader.DataAvailable);
                    Console.WriteLine("You've got mail: " + completeMessage);
                }
                catch { Console.WriteLine("There was a problem sending your message."); }
            }
        }



        public void EndMessage()
        {
            client.Close();
        }
    }
}



//Console.WriteLine("Enter a message to the server");
//message = Console.ReadLine();
//writer.WriteLine(message);
//writer.Flush();
//reader = new StreamReader(client.GetStream());
//message = reader.ReadLine(); 
//string serverString = reader.ReadLine();
//Console.WriteLine(serverString);