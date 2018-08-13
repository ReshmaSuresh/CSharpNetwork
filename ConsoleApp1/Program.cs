using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddr = IPAddress.Any;
            IPEndPoint ipEnd = new IPEndPoint(ipaddr, 23000);
            socket.Bind(ipEnd);
            socket.Listen(5);
            Socket client = socket.Accept();
            if(client != null)
            {
                Console.Write("Connected to " + client.ToString() + " IPEndpoint "  + client.RemoteEndPoint.ToString());
            }
            while (true)
            {
                byte[] buff = new byte[128];
                int receivedData = client.Receive(buff);
                string data = Encoding.ASCII.GetString(buff);
                Console.WriteLine("Data receieved " + data);

                client.Send(buff);
                if(data == "x") 
                {
                    break;
                }

                Array.Clear(buff, 0, buff.Length);


            }

           
           

        }
    }
}
