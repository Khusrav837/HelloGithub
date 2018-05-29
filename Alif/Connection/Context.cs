using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Alif.Connection
{
    public class Context : IContext
    {
        public string _ipadress { get ; set; }
        public int _port { get; set; }

        public String SendMessage(XmlDocument message)
        {
            byte[] otvet = new byte[100000];
            _ipadress = "127.0.0.1";
            //_ipadress = "79.170.189.217";
            _port = 5010;
            Socket soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            soc.Connect(_ipadress, _port);
            byte[] buffer = Encoding.UTF8.GetBytes(message.OuterXml);
            soc.Send(buffer);
            soc.Receive(otvet);
            soc.Close();
            return Encoding.UTF8.GetString(otvet);

        }
    }
}
