using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformPoject0527.EFModels;

namespace WinformPoject0527
{
    public partial class SellerRegister : Form
    {
        public SellerRegister()
        {
            InitializeComponent();
            this.Load += SellerRegister_Load;
        }

        private void SellerRegister_Load(object sender, EventArgs e)
        {
            var query1 = new AppDbContext().ShippingMethods.Select(x => x.ShippingMethodName).ToList();
            foreach (var item in query1)
            {
                comboBox1.Items.Add(item);
            }
            var query2 = new AppDbContext().PaymentMethods.Select(x => x.PaymentMethodName).ToList();
            foreach (var item in query2)
            {
                comboBox2.Items.Add(item);
            }
        }

        public static bool IsValidEmail(string email)
        {
            // Email正則表達式
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            // 使用Regex類別進行匹配
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
        public static bool IsValidId(string id)
        {
            // 統編八碼
            string pattern = @"^\d{8}$";
            // 使用Regex類別進行匹配
            Regex regex = new Regex(pattern);
            return regex.IsMatch(id);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string selleraccount = txtAccount.Text;
            string sellerpassword = txtPassword.Text;
            string sellername = txtName.Text;
            int sellerid = 0;
            if (txtId.Text != "")
            {
                sellerid = int.Parse(txtId.Text);
            }
            else
            {
                sellerid = 0;
            }
            string sellerphone = txtPhone.Text;
            string sellercontact = txtContact.Text;
            string selleraddress = txtAddress.Text;
            string shipid = comboBox1.Text;
            string payid = comboBox2.Text;

            var itemship = new AppDbContext().ShippingMethods.Where(x => x.ShippingMethodName == shipid).Select(x => x.ShippingMethodId).FirstOrDefault();
            var itempay = new AppDbContext().PaymentMethods.Where(x => x.PaymentMethodName == payid).Select(x => x.PaymentMethodId).FirstOrDefault();


            if (string.IsNullOrEmpty(sellerid.ToString()))
            {
                MessageBox.Show("請輸入統編", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!IsValidId(sellerid.ToString()))
            {
                MessageBox.Show("請輸入有效的八碼統編", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(selleraccount))
            {
                MessageBox.Show("請輸入帳號", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!IsValidEmail(selleraccount))
            {
                MessageBox.Show("請輸入有效的Email", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(sellerpassword))
            {
                MessageBox.Show("請輸入密碼", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // 新增記錄
            var db = new AppDbContext();
            var seller = new Seller()
            {
                SellerAccount = selleraccount,
                SellerPassword = sellerpassword,
                SellerName = sellername,
                SellerID = sellerid,
                SellerPhone = sellerphone,
                SellerContact = sellercontact,
                SellerAddress = selleraddress,
                ShipID = itemship,
                PayID = itempay,
            };
            db.Sellers.Add(seller);
            db.SaveChanges();
            string register;
            register = $"帳號:{txtAccount.Text}\n公司名稱:{txtName.Text}\n統編:{txtId.Text}\n市話:{txtPhone.Text}\n地址:{txtContact.Text}{txtAddress.Text}\n出貨方式:{comboBox1.Text}\n收款方式:{comboBox2.Text}";
            DialogResult dr = MessageBox.Show(register, "註冊資訊是否正確?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                MessageBox.Show("註冊成功!", "註冊成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
