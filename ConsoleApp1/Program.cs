using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CSharpConnetPy
{
    class Program
    {
        static void StartClient()
        {
            Console.WriteLine("Start Client");
            string serverIP = "127.0.0.1";
            int port = 9999;
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(new IPEndPoint(IPAddress.Parse(serverIP), port));

            // 發送訊息
            var message = "{date:20220101, test:2233}";
            byte[] data_send = Encoding.UTF8.GetBytes(message);
            clientSocket.Send(data_send);
            Console.WriteLine($"發送給伺服器的訊息: {message}");

            //recieve msg
            byte[] data = new byte[1024];
            int count = clientSocket.Receive(data);
            string msg = Encoding.UTF8.GetString(data, 0, count);
            Console.WriteLine(msg);
            clientSocket.Close();
        }
        static void Main(string[] args)
        {
            StartClient();
        }
    }
}