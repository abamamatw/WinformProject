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
    public partial class BuyerEdit : Form
    {
        public readonly int editproductID;
        public int _cardIdBuyerEdit;



        public BuyerEdit(int _proid)
        {
            InitializeComponent();
            editproductID= _proid;
            this.Load += BuyerEdit_Load;
        }

        private void BuyerEdit_Load(object sender, EventArgs e)
        {
            var db = new AppDbContext();
            var item = db.Products.AsNoTracking()
                                         .Where(x => x.ProductID == editproductID).FirstOrDefault();

            var item2= db.ShoppingCartDetails.AsNoTracking()
                                        .Where(x=>x.ProductID == editproductID&&x.CartID==_cardIdBuyerEdit)                                        
                                        .FirstOrDefault();

            if (item == null)
            {
                MessageBox.Show("record not found");
                return;
            }

            textBoxxProductNameEdit.Text = item.ProductName;
            textBoxProductPriceEdit.Text = (Math.Round((decimal)item.ProductPrice)).ToString();            
            numericUpDown1.Value = (decimal)item2.Quantity;
        }

        private void buttondelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定要從購物車刪除此商品嗎？", "刪除確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                //刪除該筆ProductID的資料
                var db = new AppDbContext();
                var _cartDetailID=db.ShoppingCartDetails
                                    .Where(x=>x.ProductID== editproductID && x.CartID == _cardIdBuyerEdit)
                                    .Select(x=>x.CartDetailID)
                                    .FirstOrDefault();
                var dbremove = db.ShoppingCartDetails.Find(_cartDetailID);

               if(dbremove == null)
                {
                    MessageBox.Show("record not found");
                    return;
                }
                db.ShoppingCartDetails.Remove(dbremove);
                db.SaveChanges();

                MessageBox.Show("商品已從購物車刪除。");

                displaydatagridview();
            }
        }

        public void displaydatagridview()
        {
            //同步顯示在datagridview上
            IGrid parent = this.Owner as IGrid;
            if (parent == null)
            {
                MessageBox.Show("錯誤訊息");//開啟我的表單,它忘記實作,所以無法通知它
            }
            else
            {
                parent.displayShoppingCart();
            }
            this.Close();
        }

        private void buttonupdate_Click(object sender, EventArgs e)
        {
            int quantityupdate = (int)numericUpDown1.Value;

            
            //新增數量
            var db=new AppDbContext();
            var _cartDetailID=db.ShoppingCartDetails
                                .Where(x=>x.ProductID== editproductID&&x.CartID==_cardIdBuyerEdit)
                                .Select(x=>x.CartDetailID)
                                .FirstOrDefault();
            var dbupdate = db.ShoppingCartDetails.Find(_cartDetailID);

            dbupdate.Quantity = quantityupdate;

            db.SaveChanges();

            MessageBox.Show("商品已加入購物車。");

            displaydatagridview();
        }
    }
}
