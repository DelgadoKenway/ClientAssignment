using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//
//
//  CLIENT SIDE
//
//
namespace Client
{
    class Program
    {
        private static readonly int PORT = 12;
        static void Main()
        {
            string localAdress = "127.0.0.1";
            try
            {
                TcpClient clientsocket = new TcpClient(localAdress, PORT);
                Stream stream = clientsocket.GetStream();
                StreamWriter swriter = new StreamWriter(stream);
                StreamReader sreader = new StreamReader(stream);
                swriter.AutoFlush = true;
                while (true)
                {
                    Console.WriteLine("Possible commands: TOGRAM/TOOUNCES + value");
                    string msg = Console.ReadLine();
                    swriter.WriteLine(msg);
                    Thread.Sleep(1000);
                    Console.WriteLine(sreader.ReadLine());

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Client was not able to establish connection");
                Thread.Sleep(4000);
                Console.WriteLine("Trying to get back...");
                Main();
            }
        }
    }
}
