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
    class C_Program
    {
        static void Main(string[] args)
        {

            IRunChatRoom room = new Client();
            room.StartClient();
            room.SendMessage();
            room.ReadMessage();
            room.EndMessage();
        }        
    }
}
