using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Channels;
using WhatToDo;

namespace UDPreciever
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Creates a UdpClient for reading incoming data.

            UdpClient udpReceiver = new UdpClient(1111);

            //Creates an IPEndPoint to record the IP Address and port number of the sender.
            //This IPEndPoint will allow you to read datagrams sent from a specific ip-source on port 80
            // 192.168.3.224/127.0.0.1 
            // IPAddress ip = IPAddress.Parse("127.0.0.1");
            // IPEndPoint RemoteIpEndPoint = new IPEndPoint(ip, 80);


            //BROADCASTING RECEIVER
            //This IPEndPoint will allow you to read datagrams sent from any ip-source on port 80
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 2222);

            //IPEndPoint object will allow us to read datagrams sent from any source.
            //IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

            // Blocks until a message returns on this socket from a remote host.
            Console.WriteLine("Receiver is blocked");
            try
            {
                while (true)
                {
                    Byte[] receiveBytes = udpReceiver.Receive(ref RemoteIpEndPoint);

                    string receivedData = Encoding.ASCII.GetString(receiveBytes);

                    Console.WriteLine(receivedData);

                    string[] splitreceived = receivedData.Split(" ");


                    SensorData sensordataobject = new SensorData(){GrassLengt = Int32.Parse(splitreceived[2]), Time = DateTime.Parse(splitreceived[0])};

                    //var json = JsonConvert.SerializeObject(sensordataobject);
                    //var data = new StringContent(json, Encoding.UTF8, "application/json");

                    //Console.WriteLine(data);

                    //using HttpClient httpclient = new HttpClient();
                    //httpclient.PostAsync("", data);

                    Thread.Sleep(200);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
    }
}
