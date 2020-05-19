using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace Sensor
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Hello World press enter to start prepare sending environment!");
            Console.ReadLine();
            Random rvalue = new Random();
            Measurement measure;

            UdpClient udpSender = new UdpClient(2222);
            udpSender.EnableBroadcast = true;
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, 1111);

            Console.WriteLine("ready to start press enter again");
            Console.ReadLine();

            int grassLength = 0;

            while (true)
            {
                if(grassLength < 200)
                { grassLength = grassLength + rvalue.Next(0, 2);}


                measure = new Measurement(DateTime.Now, grassLength);

                byte[] sendBytes = Encoding.ASCII.GetBytes(s: measure.ToString());

                try
                {
                    Console.WriteLine("sending:" + measure.ToString());
                    udpSender.Send(sendBytes, sendBytes.Length, endPoint);
                    //Thread.Sleep(10000);
                    Thread.Sleep(100);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
