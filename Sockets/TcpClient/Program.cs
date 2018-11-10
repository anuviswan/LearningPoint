using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpClients
{
    class Program
    {
        static void Main(string[] args)
        {

            TcpClient tcpClient = new TcpClient("localHost", 42000);
            using (NetworkStream ns = tcpClient.GetStream())
            {
                using (BufferedStream bs = new BufferedStream(ns))
                {
                    byte[] messageBytesToSend = Encoding.UTF8.GetBytes("This is a very serious message from the client over TCP.");
                    bs.Write(messageBytesToSend, 0, messageBytesToSend.Length);
                }
            }

            Console.WriteLine("Main done...");
            Console.ReadKey();
        }
    }
}
