using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformPoject0527.EFModels;

namespace WinformPoject0527
{
    public partial class BuyerRegisterEdit : Form
    {
        public int _userIdBuyerRegisterEdit;



        public BuyerRegisterEdit()
        {
            InitializeComponent();
            this.Load += BuyerRegisterEdit_Load;
        }

        private void BuyerRegisterEdit_Load(object sender, EventArgs e)
        {
            var db = new AppDbContext();
            //給comboBox值
            var query1 = db.ShippingMethods.Select(x => x.ShippingMethodName).ToList();
            foreach (var item in query1)
            {
                comboBoxShippingMethod.Items.Add(item);
            }           

            var query2 = db.PaymentMethods.Select(x => x.PaymentMethodName).ToList();
            foreach (var item in query2)
            {
                comboBoxPaymenyMethodId.Items.Add(item);
            }

            //ShippingMethods取的combobox其id的name
            var query12 = db.Users.Where(x => x.UserID == _userIdBuyerRegisterEdit)
                                    .Join(db.ShippingMethods
                                            .AsNoTracking(), x => x.ShippingMethodId, y => y.ShippingMethodId, (x, y) => new
                                            {
                                                _shippingMethodName=y.ShippingMethodName
                                            });
            
            List<string> _shippingMethodNamelist = query12.Select(x => x._shippingMethodName).ToList();
            string _shippingMethodName = _shippingMethodNamelist[0];

            //PaymenyMethods取的combobox其id的name
            var query22 = db.Users.Where(x => x.UserID == _userIdBuyerRegisterEdit)
                                    .Join(db.PaymentMethods
                                            .AsNoTracking(), x => x.PaymenyMethodId, y => y.PaymentMethodId, (x, y) => new
                                            {
                                                _paymenyMethodName = y.PaymentMethodName
                                            });

            List<string> _paymenyMethodNamelist = query22.Select(x =>x._paymenyMethodName).ToList();
            string _paymenyMethodName = _paymenyMethodNamelist[0];




            //帶入相對應userId的資料
            var query = db.Users.Where(x=>x.UserID == _userIdBuyerRegisterEdit).FirstOrDefault();

            textBoxUserAccount.Text = query.UserAccount;
            textBoxUserPassword.Text = query.UserPassword;
            textBoxUserName.Text = query.UserName;
            if(query.Gender== "Male")
            {
                radioButtonMale.Checked = true;
            }
            if(query.Gender== "Female")
            {
                radioButtonFemale.Checked = true;
            }
            dateTimePicker1.Value = (DateTime)query.Birthday;
            textBoxPhone.Text = query.Phone;
            textBoxCellPhone.Text = query.CellPhone;
            textBoxAddress.Text = query.Address;
            comboBoxShippingMethod.Text= _shippingMethodName;
            comboBoxPaymenyMethodId.Text= _paymenyMethodName;


            
        }
    }
}
