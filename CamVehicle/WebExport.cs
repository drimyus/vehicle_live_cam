using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CamVehicle
{
    class WebExport
    {
        string hostNameOrAddress;
        int destPort;
        public WebExport()
        {
            hostNameOrAddress = "127.0.0.1";
            destPort = 5000;
        }

        public void SendUDP(string hostNameOrAddress, int destPort, string data)
        {
            IPAddress destIPAddress = Dns.GetHostAddresses(hostNameOrAddress)[0];
            IPEndPoint endPoint = new IPEndPoint(destIPAddress, destPort);
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            socket.SendTo(buffer, endPoint);

            socket.Close();
            System.Console.WriteLine("Send: " + data);
        }

    }
}
