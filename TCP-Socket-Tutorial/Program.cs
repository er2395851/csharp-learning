using System;
using System.Net.Sockets;
using System.Text;
using System.IO;


namespace TCP_Socket_Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://www.youtube.com/watch?v=g5yEWLJxNmI
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 1309);
                string message = "my name is edmar";

                int bytetocount = Encoding.ASCII.GetByteCount(message + 1);
                byte[] sendData = new byte[bytetocount];

                sendData = Encoding.ASCII.GetBytes(message);
                NetworkStream stream = client.GetStream();
                stream.Write(sendData, 0, sendData.Length);
                Console.WriteLine("sending data...");

                StreamReader reader = new StreamReader(stream);
                string response = reader.ReadLine();
                Console.WriteLine(response);

                stream.Close();
                client.Close();






            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
