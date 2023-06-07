using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformPoject0527
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void toolStripButtonuser_Click(object sender, EventArgs e)
        {
            var frm = new BuyerLogin();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void toolStripButtonseller_Click(object sender, EventArgs e)
        {
            var frm=new SellerLogin();
            frm.MdiParent = this;
            frm.WindowState= FormWindowState.Maximized;
            frm.Show();
        }
    }

}
