using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class frm_Connect : Form
    {
        public frm_Connect()
        {
            InitializeComponent();
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            int p = Int32.Parse(txt_Port.Text);
            TcpClientModel tcp = new TcpClientModel(txt_IP.Text, p);
            tcp.connectToServer();
            this.Hide();
            frm_Board frm = new frm_Board(tcp);
            frm.ShowDialog();
            this.Show();
        }
    }
}
