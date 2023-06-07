using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformPoject0527.EFModels;

namespace WinformPoject0527
{
    public partial class SellerProductAdd : Form
    {
        private int _ProductID;
        private int _SellerID;


        public SellerProductAdd(int productid, int sellerid)
        {
            InitializeComponent();
            _ProductID = productid;
            _SellerID = sellerid;
            this.Load += SellerProductAdd_Load;
        }

        private void SellerProductAdd_Load(object sender, EventArgs e)
        {
            //IQueryable<Product> query = new Model1().Products.AsNoTracking();

            //_ProductID = query.OrderByDescending(c => c.ProductID).Select(c => c.ProductID).FirstOrDefault();
            //_SellerID= (int)query.OrderByDescending(c => c.ProductID).Select(c => c.SellerID).FirstOrDefault();
            //txtProductId.Text = _ProductID.ToString();
            ////MessageBox.Show($"{_SellerID}");

            txtProductId.Text = _ProductID.ToString();
            var product = new AppDbContext()
                            .Products
                            .AsNoTracking()
                            .Where(c => c.ProductID == _ProductID)
                            .SingleOrDefault();
            txtProductName.Text = product.ProductName;
            txtCategoryId.Text = product.CategoryID;
            txtProductPrice.Text = product.ProductPrice.ToString();
            txtProductDescription.Text = product.ProductDescription;

            var db = new AppDbContext();
            var result = from p in db.Products//商品表
                         join o in db.ProductInventories
                         on p.ProductID equals o.ProductID  //進貨單表
                         where p.ProductID == _ProductID
                         group o by o.ProductID into g
                         select new
                         {
                             ProductID = g.Key,
                             TotalQuantity = g.Sum(x => x.Quantity)
                         };

            var item = result.FirstOrDefault();
            if (item != null)
            {
                txtTotal.Text = item.TotalQuantity.ToString();
            }
            else
            {
                txtTotal.Text = "0";
            }
        }


        public void ProductAddNew()
        {
            IQueryable<Product> query = new AppDbContext().Products.AsNoTracking();
            _ProductID = query.OrderByDescending(c => c.ProductID).Select(c => c.ProductID).FirstOrDefault();
            _SellerID = (int)query.OrderByDescending(c => c.ProductID).Select(c => c.SellerID).FirstOrDefault();

        }

        public void ProductEdit(int x, int y)
        {
            IQueryable<Product> query = new AppDbContext().Products.AsNoTracking();
            _ProductID = x;
            _SellerID = y;

        }

        private void btnproductsetting_Click(object sender, EventArgs e)
        {
            var db = new AppDbContext();
            int ProductId = Convert.ToInt32(txtProductId.Text);
            string name = txtProductName.Text;
            string categoryId = txtCategoryId.Text;
            string description = txtProductDescription.Text;
            bool isInt = int.TryParse(txtProductPrice.Text, out int price);

            // 更新記錄
            var product = db.Products.Find(_ProductID);
            product.ProductName = name;
            product.CategoryID = categoryId;
            product.ProductDescription = description;
            product.ProductPrice = price;

            db.SaveChanges();

            //新增進貨
            if (txtProductQuantity.Text != string.Empty)
            {
                var productinventory = new ProductInventory()
                {
                    ProductID = Convert.ToInt32(txtProductId.Text),
                    SellerID = _SellerID,
                    Quantity = Convert.ToInt32(txtProductQuantity.Text),
                };

                db.ProductInventories.Add(productinventory);
                db.SaveChanges();
            }

            MessageBox.Show("已更新完成!");
            Close();
        }

        private void btnQuantity_Click(object sender, EventArgs e)
        {
            label7.Visible = !label7.Visible;
            txtProductQuantity.Visible = !txtProductQuantity.Visible;
            txtProductName.Enabled = !txtProductName.Enabled;
            txtCategoryId.Enabled = !txtCategoryId.Enabled;
            txtProductPrice.Enabled = !txtProductPrice.Enabled;
            txtProductDescription.Enabled = !txtProductDescription.Enabled;

            if (label7.Visible)
            {
                txtProductQuantity.Focus();
            }
            else
            {
                txtProductName.Focus();
            }
        }
    }
}
