﻿using System;
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
            Client client = new Client();
            client.SendMessage();
            Console.ReadLine();
            client.ReadMessage();
            Console.ReadLine();
            client.EndMessage();
        }        
    }
}
