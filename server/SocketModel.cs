using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace server {
    class SocketModel {
        static int BUFFER_SIZE = 100;
        private Socket socket;
        private byte[] receiveDataArr;
        private string remoteEndPoint;

        public SocketModel(Socket s) {
            socket = s;
            this.receiveDataArr = new byte[BUFFER_SIZE];
        }
        public SocketModel(Socket s, int length) {
            socket = s;
            this.receiveDataArr = new byte[length];
        }

        public String GetRemoteEndpoint() {
            string str = "";
            try {
                str = Convert.ToString(socket.RemoteEndPoint);
                remoteEndPoint = str;
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                str = "Error: Socket is closed with " + remoteEndPoint;
            }
            return str;
        }

        public String ReceiveData() {

            String str = "";
            try {
                int k = socket.Receive(this.receiveDataArr);
                Console.Write("Client sent: ");

                char[] c = new char[k];
                for (int i = 0; i < k; i++) {
                    Console.Write(Convert.ToChar(this.receiveDataArr[i]));
                    c[i] = Convert.ToChar(this.receiveDataArr[i]);
                }
                str = new String(c);

                Console.Write("\n");
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                //str = "Socket is closed with " + remoteEndPoint;
                return null;
            }
            return str;
        }

        public void SendData(string str) {
            try {
                ASCIIEncoding encoding = new ASCIIEncoding();
                socket.Send(encoding.GetBytes(str));

                Console.WriteLine("Server sent: " + str);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        public void CloseSocket() {
            socket.Close();
        }
    }
}
