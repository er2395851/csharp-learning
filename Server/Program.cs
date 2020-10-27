using System;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace Server
{
    class Program
    {           //https://youtu.be/g5yEWLJxNmI?t=619
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(System.Net.IPAddress.Any, 1309);
            listener.Start();
            while(true)
            {
                Console.WriteLine("waiting for connections");
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("client accepted.");
                NetworkStream stream = client.GetStream();
                StreamReader reader = new StreamReader(client.GetStream());
                StreamWriter writer = new StreamWriter(client.GetStream());
            try
            {
                    byte[] buffer = new byte[1024];
                    stream.Read(buffer, 0, buffer.Length);
                    int recv = 0;
                    foreach (byte b in buffer)
                    {
                        if(b!=0)
                        {
                            recv++;
                        }
                    }
                    string request = Encoding.UTF8.GetString(buffer, 0, recv);
                    Console.WriteLine("request receive: " + request);
                    writer.WriteLine("done");
                    writer.Flush();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            }
           
        }
    }
}
