using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace client
{
    public partial class frm_Board : Form
    {
        string[] queue = new string[10];
        int l = 0;
        int r = 0;
        TcpClientModel tcp = null;
        public frm_Board(TcpClientModel tcp)
        {
            this.tcp = tcp;
            InitializeComponent();
            Thread t = new Thread(this.receiveStream);
            t.Start(tcp);
        }

        private void btn_Continue_Click(object sender, EventArgs e)
        {
            tcp.sendData("Ready");
        }

        private void receiveStream(Object obj)
        {

            TcpClientModel tcp = (TcpClientModel)obj;
            while (true)
            {
                //neu flag tat luon thi break
                //neu flag hide thi continue
                tcp.receiveData(ref queue[r++]);
                r = r % 10;
            }
        }

        private void solveStream(Object obj)
        {
            frm_Board tmp = (frm_Board)obj;
            while(true)
            {
                if (l == r)
                    continue;
                string st = queue[l++];
                string[] formatdata = st.Split(':');
                switch (formatdata[0])
                {
                    case "RivalPoint":
                        tmp.txt_EnemyPoint.Text =
                            formatdata[1];
                        break;
                    case "YourPoint":
                        tmp.txt_PlayerPoint.Text =
                            formatdata[1];
                        break;
                    case "Winner":
                        if (formatdata[1] == "1")
                            MessageBox.Show("You win!");
                        if (formatdata[1] == "0")
                            MessageBox.Show("You lose!");
                        if (formatdata[1] == "2") 
                            MessageBox.Show("Tied");
                        break;
                    default:
                        MessageBox.Show(st);
                        break;
                }
            }
        }

        private void btn_Play_Click(object sender, EventArgs e)
        {
            tcp.sendData("Play");
        }

        private void frm_Board_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }
    }
}
