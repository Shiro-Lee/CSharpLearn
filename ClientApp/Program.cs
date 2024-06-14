#define TcpClient

using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int port = 6001;
            IPAddress ip = IPAddress.Parse("192.168.2.176");

#if TcpClient
            TcpClient client = new TcpClient();
            client.Connect(ip, port);
#else
            IPEndPoint ipe = new IPEndPoint(ip, port);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(ipe);
#endif

#if TcpClient
            if (client.Client.RemoteEndPoint != null)
                Console.WriteLine($"连接已建立, 地址: {((IPEndPoint)client.Client.RemoteEndPoint).Address}");
#else
            if (clientSocket.RemoteEndPoint != null)
                Console.WriteLine($"连接已建立, 地址: {((IPEndPoint)clientSocket.RemoteEndPoint).Address}");
#endif
            Console.WriteLine("按任意键发送消息");
            Console.ReadKey();

            //发送消息
            string sendStr = "Hello, Server!";
            byte[] sendBytes = Encoding.ASCII.GetBytes(sendStr);
#if TcpClient
            client.Client.Send(sendBytes, sendBytes.Length, SocketFlags.None);
#else
            clientSocket.Send(sendBytes, sendBytes.Length, SocketFlags.None);
#endif
            Console.WriteLine($"客户端发送消息: {sendStr}");

            //接收消息
            byte[] recBytes = new byte[1024];
#if TcpClient
            int bytes = client.Client.Receive(recBytes, recBytes.Length, SocketFlags.None);
#else
            int bytes = clientSocket.Receive(recBytes, recBytes.Length, SocketFlags.None);
#endif
            string recStr = Encoding.ASCII.GetString(recBytes);
            Console.WriteLine($"客户端接收到消息: {recStr}");

            Console.ReadKey();

#if TcpClient
            client.Close();
#else
            clientSocket.Close();
#endif
        }
    }
}
