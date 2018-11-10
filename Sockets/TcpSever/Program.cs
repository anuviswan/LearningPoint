using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpSever
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress localhost = IPAddress.Parse("127.0.0.1");
            TcpListener tcpListener = new TcpListener(localhost, 42000);
            tcpListener.Start();

            Socket tcpClient = tcpListener.AcceptSocket();
            int bytesRead = 0;
            StringBuilder messageBuilder = new StringBuilder();
            using (NetworkStream ns = new NetworkStream(tcpClient))
            {
                int messageChunkSize = 10;
                do
                {
                    byte[] chunks = new byte[messageChunkSize];
                    bytesRead = ns.Read(chunks, 0, chunks.Length);
                    messageBuilder.Append(Encoding.UTF8.GetString(chunks));
                }
                while (bytesRead != 0);
            }

            Console.WriteLine(messageBuilder.ToString());

            Console.WriteLine("Main done...");
            Console.ReadKey();


        }
    }

}
