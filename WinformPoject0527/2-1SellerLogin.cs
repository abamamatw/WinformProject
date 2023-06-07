using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformPoject0527.EFModels;

namespace WinformPoject0527
{
    public partial class SellerLogin : Form
    {
        string account = " ";
        string password = " ";
        public int SellerIdlogin;
        public SellerLogin()
        {
            InitializeComponent();
        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {
             account= textBoxaccount.Text;
            password=textBoxPw.Text  ;
            try
            {
                List<int> SellerID = new List<int>();
                var query1 = new AppDbContext().Sellers
                                            .Where(x => x.SellerAccount == account && x.SellerPassword == password)
                                            .Select(x => x.SellerID)/*.FirstOrDefault()*/;
                foreach (var item in query1)
                {
                    SellerID.Add(item);
                }
                SellerIdlogin = SellerID[0];
               

                if (query1 != null)
                {
                    var frm = new SellerMain(SellerIdlogin);
                    frm.MdiParent = Login.ActiveForm;
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("請輸入正確帳號或密碼");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("請輸入正確帳號或密碼");
            }

        }

        private void buttonexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonDemo_Click(object sender, EventArgs e)
        {
            textBoxaccount.Text= "Apple@123.com";
            textBoxPw.Text = "1234";
        }

        private void buttonregister_Click(object sender, EventArgs e)
        {
            var frm = new SellerRegister();
            frm.MdiParent = Login.ActiveForm;
            frm.Show();
        }
    }
}
