using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WinformPoject0527.EFModels;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinformPoject0527
{
    public partial class SellerRegisterEdit : Form
    {
        private int _SellerID ;
        string shipId;
        string payId;
        public SellerRegisterEdit(int a)
        {
            _SellerID = a;
            InitializeComponent();
            this.Load += SellerRegisterEdit_Load;
        }

        private void SellerRegisterEdit_Load(object sender, EventArgs e)
        {
            
            Display();
            var query1 = new AppDbContext().ShippingMethods.Select(x => x.ShippingMethodName).ToList();
            foreach (var item in query1)
            {
                comboBoxShippingMethod.Items.Add(item);
            }
            var query2 = new AppDbContext().PaymentMethods.Select(x => x.PaymentMethodName).ToList();
            foreach (var item in query2)
            {
                comboBoxPaymentMethod.Items.Add(item);
            }
        }
        public void Display()
        {
            IQueryable<EFModels.Seller> query = new AppDbContext().Sellers.AsNoTracking();
            txtAccount.Text = query.Where(c => c.SellerID == _SellerID).Select(a => a.SellerAccount).FirstOrDefault();
            txtPassword.Text = query.Where(c => c.SellerID == _SellerID).Select(a => a.SellerPassword).FirstOrDefault();
            txtName.Text = query.Where(c => c.SellerID == _SellerID).Select(a => a.SellerName).FirstOrDefault();
            txtId.Text = query.Where(c => c.SellerID == _SellerID).Select(a => a.SellerID).FirstOrDefault().ToString();
            txtPhone.Text = query.Where(c => c.SellerID == _SellerID).Select(a => a.SellerPhone).FirstOrDefault();
            txtAddress.Text = query.Where(c => c.SellerID == _SellerID).Select(a => a.SellerAddress).FirstOrDefault();
            comboBoxShippingMethod.Text= query.Where(c => c.SellerID == _SellerID).Select(a => a.ShipID).FirstOrDefault();
            comboBoxPaymentMethod.Text = query.Where(c => c.SellerID == _SellerID).Select(a => a.PayID).FirstOrDefault();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string sellerpassword =txtPassword.Text;
            string sellerphone =txtPhone.Text;
            string selleraddress = txtAddress.Text;
            string ship =comboBoxShippingMethod.Text;
            string pay = comboBoxPaymentMethod.Text;    

            var itemship = new AppDbContext().ShippingMethods
                .Where(x =>x.ShippingMethodName ==ship)
                .Select(x =>x.ShippingMethodId).FirstOrDefault();
            var itempay = new AppDbContext().PaymentMethods
                .Where(x => x.PaymentMethodName == pay)
                .Select(x => x.PaymentMethodId).FirstOrDefault();
           var db = new AppDbContext();
            var sellers = db.Sellers.Find(_SellerID);
           sellers.SellerPassword = sellerpassword;
           sellers.SellerPhone = sellerphone;
           sellers.SellerAddress = selleraddress;
            sellers.ShipID = itemship;
            sellers.PayID = itempay;
            db.SaveChanges(); 
            MessageBox.Show("修改成功!");
           Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}