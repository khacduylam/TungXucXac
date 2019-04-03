using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace server {
    class TcpServerModel {
            private IPAddress IP;
            private int Port;
            private TcpListener tcpServer;

            public TcpServerModel(String ip, int p) {
                this.IP = IPAddress.Parse(ip);
                this.Port = p;
                tcpServer = new TcpListener(this.IP, this.Port);
            }

            public void Listen() {
                try {
                    tcpServer.Start();
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }

            public Socket SetUpANewConnection() {
                Socket socket = tcpServer.AcceptSocket();
                return socket;
            }

            public void Shutdown() {
                this.tcpServer.Stop();
            }
        }
}
