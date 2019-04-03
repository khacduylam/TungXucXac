using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace client
{
    public class TcpClientModel
    {
        private TcpClient tcpclnt;
        private Stream stm;
        //private byte[] byteSend;
        //private byte[] byteReceive;
        private string IPofServer;
        private int port;

        public TcpClientModel(string ip, int p)
        {
            IPofServer = ip;
            port = p;
            tcpclnt = new TcpClient();

            //byteReceive = new byte[100];
        }

        public int connectToServer()
        {
            try
            {
                tcpclnt.Connect(IPofServer, port);
                stm = tcpclnt.GetStream();
                Console.WriteLine("Sent!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Connection Error.." + e.StackTrace);
                return -1;
            }
            return 1;
        }

        public int sendData(string str)
        {
            try
            {
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] byteSend = asen.GetBytes(str);
                stm.Write(byteSend, 0, byteSend.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine("Sending Error.." + e.StackTrace);
                return -1;
            }
            return 1;
        }

        public int receiveData(ref string str)
        {
            try
            {
                byte[] byteReceive = new byte[100];
                int len = stm.Read(byteReceive, 0, 100);

                str = System.Text.Encoding.ASCII.GetString(byteReceive, 0, len);
                Console.WriteLine("Received!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Receiving Error.." + e.StackTrace);
                return -1;
            }
            return 1;
        }

        public void closeConnection()
        {
            tcpclnt.Close();
        }



    }
}
