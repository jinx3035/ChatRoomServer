using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ChatRoomServer
{
    class Program
    {
        Server client;
        static void Main(string[] args)
        {
            Server server = new Server();
            server.StartServer();
            server.Listen();
            
            // instantiate Client class here w DisplayMessage()?
        }
    }
}
