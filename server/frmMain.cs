using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server {
    public partial class frmMain : Form {
        private TcpServerModel tcp;
        private SocketModel[] socket;
        private int[] clientState; //0: not ready | -1: ready | > 0: played
        public frmMain() {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e) {
            this.socket = new SocketModel[2];
            this.clientState = new int[2];

            for(int i = 0; i < 2; i++) {
                this.socket[i] = null;
            }
        }

        public int GetFreeSocket() {
            for (int i = 0; i < 2; i++) {
                if (this.socket[i] == null) {
                    return i;
                }
            }

            return -1; //Server overloaded
        }

        public void StartServer() {
            this.tcp = new TcpServerModel(txtIP.Text, int.Parse(txtPort.Text));
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            tcp.Listen();
        }

        public void AcceptConnection() {
            Socket s = tcp.SetUpANewConnection();
            int index = this.GetFreeSocket();
            if(index == -1) return;

            socket[index] = new SocketModel(s);
        }

        public void ServeRequests(Object obj) {
            int index = (int)obj;
            while (true) {
                String str = this.socket[index].ReceiveData();

                if(str == "Play") {
                    if(this.clientState[0] * this.clientState[1] == 0) {
                        this.socket[index].SendData("Failure:not ready");
                        continue;
                    }
                    if(this.clientState[index] > 0) {
                        this.socket[index].SendData("Failure:Played");
                        continue;
                    }
                    Random ran = new Random();
                    int num = ran.Next(1, 7);
                    this.clientState[index] = num;

                    this.socket[index].SendData("YourPoint:" + num);
                    this.socket[(index + 1) % 2].SendData("RivalPoint:" + num);

                    if(this.clientState[0] > 0 && this.clientState[1] > 0) {
                        if(this.clientState[0] > this.clientState[1]) {
                            this.socket[0].SendData("Winner:0");
                            this.socket[1].SendData("Winner:1");
                        } else if (this.clientState[0] < this.clientState[1]) {
                            this.socket[0].SendData("Winner:1");
                            this.socket[1].SendData("Winner:0");
                        } else {
                            this.socket[0].SendData("Winner:2");
                            this.socket[1].SendData("Winner:2");
                        }
                    }
                }
            }
        }

        public void ServeMultiClient() {
            while(true) {
                this.AcceptConnection();

                Thread t = new Thread(this.ServeRequests);
                t.Start(this.GetFreeSocket());
            }
        }

        private void btnStart_Click(object sender, EventArgs e) {
            this.tcp = new TcpServerModel(txtIP.Text, int.Parse(txtPort.Text));
            this.tcp.Listen();

            btnStart.Enabled = false;
            btnStop.Enabled = true;

            Thread t = new Thread(this.ServeMultiClient);
            t.Start();
        }

        private void btnStop_Click(object sender, EventArgs e) {
            this.tcp.Shutdown();

            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }
    }
}
