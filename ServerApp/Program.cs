//#define TcpListenter

using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerSocketApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int port = 6001;
            IPAddress ip = IPAddress.Parse("192.168.2.176");
            IPEndPoint ipe = new IPEndPoint(ip, port);

#if TcpListenter
            TcpListener listener = new TcpListener(ip, port);
            listener.Start();
#else
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenSocket.Bind(ipe);
            listenSocket.Listen(1);
#endif
            Console.WriteLine("服务器端监听已打开");

#if TcpListenter
            Socket serverSocket = listener.AcceptSocket();
#else
            Socket serverSocket = listenSocket.Accept();
#endif
            if (serverSocket.RemoteEndPoint != null)
                Console.WriteLine($"连接已建立, 地址:{((IPEndPoint)serverSocket.RemoteEndPoint).Address}");

            //接收消息
            byte[] recBytes = new byte[1024];
            int bytes = serverSocket.Receive(recBytes, recBytes.Length, SocketFlags.None);
            string recStr = Encoding.ASCII.GetString(recBytes);
            Console.WriteLine($"服务器端接收到信息: {recStr}");

            Console.WriteLine("按任意键发送消息");
            Console.ReadKey();

            //发送消息
            string sendStr = "Hello, Client!";
            byte[] sendBytes = Encoding.ASCII.GetBytes(sendStr);
            serverSocket.Send(sendBytes, sendBytes.Length, SocketFlags.None);
            Console.WriteLine($"服务器端发送消息: {sendStr}");

            Console.ReadKey();

            serverSocket.Close();
#if TcpListenter
            listener.Stop();
#else
            listenSocket.Close();
#endif
        }
    }
}
