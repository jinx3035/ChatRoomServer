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
    public class Client : IRunChatRoom

    {
        TcpClient client;
        NetworkStream writer;
        NetworkStream reader;

        void IRunChatRoom.StartClient()
        {
            client = new TcpClient("192.168.0.127", 45000);
            reader = client.GetStream();
            writer = client.GetStream();
        }

        void IRunChatRoom.SendMessage()
        {
            if (!(writer.CanWrite)) { throw new Exception(); }
            else
            {
                while(true)
                {
                    try
                    {
                        Console.WriteLine("Enter a message to the server");
                        string message = Console.ReadLine();
                        byte[] data = Encoding.ASCII.GetBytes(message);
                        writer.Write(data, 0, data.Length);
                    }
                    catch { Console.WriteLine("There was a problem sending your message."); }
                }                              
            }
        }

        void IRunChatRoom.ReadMessage()
        {
            if (!(reader.CanRead)) { throw new Exception(); }
            else
            {
                while (true)
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
                        Console.WriteLine("You've got mail: \n\n" + completeMessage);

                    }
                    catch { Console.WriteLine("There was a problem receiving your message."); }
                }               
            }                            
        }

        void IRunChatRoom.EndMessage()
        {
            client.Close();
        }
    }
}
