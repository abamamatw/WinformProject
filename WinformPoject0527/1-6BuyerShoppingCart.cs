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
    public partial class BuyerShoppingCart : Form, IGrid
    {

        public int _cardIdBuyerShoppingCart;
        public int _userIdBuyerShoppingCart;
        List<ShoppingCartDto> datashow;                
        

        public BuyerShoppingCart()
        {
            InitializeComponent();
            this.Load += BuyerShoppingCart_Load;
            
        }
        

        private void BuyerShoppingCart_Load(object sender, EventArgs e)
        {
            displayShoppingCart();
        }

        public void displayShoppingCart()
        {
            var db = new AppDbContext();
            var data = db.ShoppingCartDetails.AsNoTracking()
                            .Where(x => x.CartID == _cardIdBuyerShoppingCart)
                            .OrderBy(x => x.CartDetailID)
                            .Join(db.Products.AsNoTracking(), x => x.ProductID, y => y.ProductID, (x, y) => new

                            {
                                sProductName = y.ProductName,
                                CartID = (int)x.CartID,
                                ProductId = (int)x.ProductID,
                                Quantity = (int)x.Quantity,
                                Price = (int)y.ProductPrice,
                                TotalProductPrice = (int)(((int)x.Quantity) * y.ProductPrice),

                            }).ToList();

            datashow = data
                        .Select(x => new ShoppingCartDto
                        {
                            CartID = x.CartID,
                            ProductId = x.ProductId,
                            ProductName = x.sProductName,
                            Quantity = x.Quantity,
                            ProductPrice = x.Price,
                            TotalProductPrice = x.TotalProductPrice,

                        }).ToList();
            this.dataGridView1.DataSource = datashow;
            

            //計算購物車的總金額在textBox show出來
            var totalProductPriceSum = datashow.Sum(x => x.TotalProductPrice);
            textBoxtotalprice.Text = totalProductPriceSum.ToString();
                       


        }
        
        private void buttonMain_Click(object sender, EventArgs e)
        {
            var frm = new BuyerMain();
            frm.MdiParent = Login.ActiveForm;
            frm._cardIdBuyerMain = _cardIdBuyerShoppingCart;
            frm._userIdMain = _userIdBuyerShoppingCart;
            frm.Show();
        }

        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0) return;

            int reproductID = this.datashow[e.RowIndex].ProductId;

            var frm = new BuyerEdit(reproductID);
            frm.Owner = this;           
            frm._cardIdBuyerEdit= _cardIdBuyerShoppingCart;
            frm.ShowDialog();
        }

        private void buttonorder_Click(object sender, EventArgs e)
        {
            var frm = new BuyerList(datashow);
            frm.MdiParent = Login.ActiveForm;
            frm._userIdBuyerList = _userIdBuyerShoppingCart;
            frm._cardIdBuyerList = _cardIdBuyerShoppingCart;
            frm.Show();
        }

       

    }
}
