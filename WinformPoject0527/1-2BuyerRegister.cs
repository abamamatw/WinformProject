using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformPoject0527.EFModels;

namespace WinformPoject0527
{
    public partial class BuyerRegister : Form
    {

        string gender = "";
        public int _cardIdBuyerRegister;


        public BuyerRegister()
        {
            InitializeComponent();
            this.Load += BuyerRegister_Load;
        }

        private void BuyerRegister_Load(object sender, EventArgs e)
        {
            var query1=new AppDbContext().ShippingMethods.Select(x=>x.ShippingMethodName).ToList();
            foreach (var item in query1)
            {
                comboBoxShippingMethod.Items.Add(item);
            }

            var query2=new AppDbContext().PaymentMethods.Select(x=>x.PaymentMethodName).ToList();
            foreach (var item in query2)
            {
                comboBoxPaymenyMethodId.Items.Add(item);
            }
        }

        private void buttonregister_Click(object sender, EventArgs e)
        {
            string userAccount=textBoxUserAccount.Text;
            string userPassword=textBoxUserPassword.Text;
            string userName=textBoxUserName.Text;
            DateTime birthday = dateTimePicker1.Value;
            string phone=textBoxPhone.Text;
            string cellphone=textBoxCellPhone.Text;
            string address=textBoxAddress.Text;

            //處理comboBox
            string ship =comboBoxShippingMethod.Text;
            string pay = comboBoxPaymenyMethodId.Text;

            var itemship = new AppDbContext().ShippingMethods
                                        .Where(x=>x.ShippingMethodName== ship)
                                        .Select(x=>x.ShippingMethodId).FirstOrDefault();

            var itempay=new AppDbContext().PaymentMethods
                                        .Where(x=>x.PaymentMethodName== pay)
                                        .Select(x=>x.PaymentMethodId).FirstOrDefault();

            
            
            if (!(string.IsNullOrEmpty(userAccount) || 
                string.IsNullOrEmpty(userPassword) ||
                string.IsNullOrEmpty(userName) ||
                string.IsNullOrEmpty(gender) ||
                string.IsNullOrEmpty(phone) ||
                string.IsNullOrEmpty(cellphone) ||
                string.IsNullOrEmpty(address) ||
                string.IsNullOrEmpty(ship) ||
                string.IsNullOrEmpty(pay)
                ))
            {
                //新增至資料庫
                var db = new AppDbContext();

                var user = new User()
                {
                    UserAccount = userAccount,
                    UserPassword = userPassword,
                    UserName = userName,
                    Gender = gender,
                    Birthday = birthday,
                    Phone = phone,
                    CellPhone = cellphone,
                    Address = address,
                    ShippingMethodId = itemship,
                    PaymenyMethodId = itempay

                };
                db.Users.Add(user);
                db.SaveChanges();
                

                //取得剛註冊會員的UserID
                var _userIdre =new AppDbContext().Users
                                            .OrderByDescending(x => x.UserID)
                                            .Select(x=>x.UserID)
                                            .FirstOrDefault();
                //取的新增資料加入table
                var db2 = new AppDbContext();

                //加入table-ShoppingCart,引入登入的UserID         
                var shoppingCart = new ShoppingCart()
                {
                    UserID = _userIdre,
                };
                db.ShoppingCarts.Add(shoppingCart);
                db.SaveChanges();

                //取的ShoppingCart的CartID
                var CartIDre=new AppDbContext().ShoppingCarts
                                            .Where(x=>x.UserID== _userIdre)
                                            .Select (x=>x.CartID)
                                            .FirstOrDefault();
                _cardIdBuyerRegister= CartIDre;


                MessageBox.Show("註冊成功");
                var frm = new BuyerMain();
                frm.MdiParent = Login.ActiveForm;
                frm._cardIdBuyerMain = _cardIdBuyerRegister;
                frm.Show();
            }
            else
            {
                MessageBox.Show("請將所有欄位填寫完成");
            }

        }

        private void radioButtonMale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void radioButtonFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }

        private void buttonDemo_Click(object sender, EventArgs e)
        {
            textBoxUserAccount.Text="Amy@gmail.com";
            textBoxUserPassword.Text="1234";
            textBoxUserName.Text= "Amy";
            textBoxPhone.Text="0225489762";
            textBoxCellPhone.Text="0965789412";
            textBoxAddress.Text="台北市大安區....";
        }
    }
}
