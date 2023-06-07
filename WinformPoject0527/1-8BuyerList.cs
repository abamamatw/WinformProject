using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformPoject0527.EFModels;

namespace WinformPoject0527
{
    public partial class BuyerList : Form
    {
        public int _userIdBuyerList;
        public int _cardIdBuyerList;
        List<ShoppingCartDto> _datashowlist;


        public BuyerList(List<ShoppingCartDto> data)
        {
            InitializeComponent();
            this.Load += BuyerList_Load;
            _datashowlist = data;
        }

        private void BuyerList_Load(object sender, EventArgs e)
        {
            var db = new AppDbContext();

            var item = db.Users.AsNoTracking()
                                        .Where(x => x.UserID == _userIdBuyerList).FirstOrDefault();

            //ShippingMethods取的combobox其id的name
            var query12 = db.Users.Where(x => x.UserID == _userIdBuyerList)
                                    .Join(db.ShippingMethods
                                            .AsNoTracking(), x => x.ShippingMethodId, y => y.ShippingMethodId, (x, y) => new
                                            {
                                                _shippingMethodName = y.ShippingMethodName
                                            });

            List<string> _shippingMethodNamelist = query12.Select(x => x._shippingMethodName).ToList();
            string _shippingMethodName = _shippingMethodNamelist[0];

            //PaymenyMethods取的combobox其id的name
            var query22 = db.Users.Where(x => x.UserID == _userIdBuyerList)
                                    .Join(db.PaymentMethods
                                            .AsNoTracking(), x => x.PaymenyMethodId, y => y.PaymentMethodId, (x, y) => new
                                            {
                                                _paymenyMethodName = y.PaymentMethodName
                                            });

            List<string> _paymenyMethodNamelist = query22.Select(x => x._paymenyMethodName).ToList();
            string _paymenyMethodName = _paymenyMethodNamelist[0];

            if (item == null)
            {
                MessageBox.Show("record not found");
                return;
            }

            textBoxaccount.Text = item.UserAccount;
            textBoxship.Text = _shippingMethodName;
            textBoxpay.Text = _paymenyMethodName;


            //將購物車頁面的list套用在此
            this.dataGridView1.DataSource = _datashowlist;

        }

        private void buttonbaclshoppingcart_Click(object sender, EventArgs e)
        {
            var frm = new BuyerShoppingCart();
            frm.MdiParent = Login.ActiveForm;
            frm._cardIdBuyerShoppingCart = _cardIdBuyerList;
            frm._userIdBuyerShoppingCart = _userIdBuyerList;
            frm.Show();
        }

        private void buttonsubmit_Click(object sender, EventArgs e)
        {
            //取得下訂時間
            DateTime _orderdate = DateTime.Now;

            //送出訂單
            //在Orders的table新增訂單資料
            var db = new AppDbContext();
            var query = new Order()
            {
                UserID = _userIdBuyerList,
                OrderDate = _orderdate
            };
            db.Orders.Add(query);
            db.SaveChanges();

            //在OrderDetails的table新增訂單資料
            var querydetail = db.ShoppingCartDetails
                                .Where(x => x.CartID == _cardIdBuyerList)
                                .ToList();

            var _orderid = db.Orders.Where(x => x.UserID == _userIdBuyerList)
                                    .Select(x => x.OrderID)
                                    .FirstOrDefault();

            foreach (var cartDetail in querydetail)
            {
                var orderDetail = new OrderDetail
                {
                    OrderID = _orderid,
                    ProductID = (int)cartDetail.ProductID,
                    Quantity= (int)cartDetail.Quantity
                };
                db.OrderDetails.Add(orderDetail);
            }
            db.SaveChanges();

            //在Shipments的table新增訂單資料
            var _queryshipment = db.OrderDetails
                                .Where(x => x.OrderID == _orderid)
                                .Join(db.Products
                                        .AsNoTracking(), x => x.ProductID, y => y.ProductID, (x, y) => new
                                        {
                                            _sellerid=y.SellerID

                                        })
                                .Distinct()
                                .ToList();
            foreach (var _shipment in _queryshipment)
            {
                var queryship = new Shipment()
                {
                   OrderID= _orderid,
                   SellerID= _shipment._sellerid,
                   ShipmentDate= _orderdate
                };
                db.Shipments.Add(queryship);
            }
            
            db.SaveChanges();

            //新增一台購物車cartid
            var shoppingCart = new ShoppingCart()
            {
                UserID = _userIdBuyerList,
            };
            db.ShoppingCarts.Add(shoppingCart);
            db.SaveChanges();

            MessageBox.Show("訂購完成");

            //顯示最終訂單form
            var frm = new BuyerListEnd();
            frm.MdiParent= Login.ActiveForm;
            frm._cardIdBuyerListEnd = _cardIdBuyerList;
            frm._userIdBuyerListEnd = _userIdBuyerList;
            frm.Show();
        }
    }
}
