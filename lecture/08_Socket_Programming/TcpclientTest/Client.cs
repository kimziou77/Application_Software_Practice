using System;       //Datetime, Console
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;   //IPAdress
using System.Net.Sockets; //TcpListener, TcpClient
using System.Text; //Encoding Class


namespace TcpclientTest
{
    class Client
    {
        static void Main(string[] args)
        {
            TcpClient client = null;
            try
            {
                client = new TcpClient();
                IPAddress localAddr = IPAddress.Parse("127.0.0.1"); int port = 13000;
                client.Connect(localAddr, port);

                NetworkStream stream = client.GetStream();
                byte[] readBuffer = new byte[sizeof(int)];

                stream.Read(readBuffer, 0, readBuffer.Length);
                int bufferSize = BitConverter.ToInt32(readBuffer, 0);
                Console.WriteLine("Received : {0}", bufferSize);

                readBuffer = new byte[bufferSize];
                int bytes = stream.Read(readBuffer, 0, readBuffer.Length);
                string message = Encoding.UTF8.GetString(readBuffer, 0, bytes);
                Console.WriteLine("Received: {0}", message);

                stream.Close();
                client.Close();
            }
            catch(SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                client.Close();
            }
            Console.WriteLine("Client Exit");
        }
    }
}
