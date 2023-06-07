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
    public partial class SellerProductMain : Form
    {
        private int _SellerID;
        public SellerProductMain(int sellerid)
        {
            InitializeComponent();
            _SellerID = sellerid;
            this.Load += SellerProductMain_Load;
        }

        private void SellerProductMain_Load(object sender, EventArgs e)
        {
            Display();
        }

        public void Display()
        {
            //基本的呼叫
            //IQueryable<Product> query = new Model1().Products.AsNoTracking();
            //this.dataGridView1.DataSource = query.Where(c=>c.SellerID== _SellerID).ToList();

            //結合兩個資料表叫出數量內容
            var db = new AppDbContext();
            var data2 = from p in db.Products
                        join q in db.ProductInventories
                        on p.ProductID equals q.ProductID into joinedData
                        from j in joinedData.DefaultIfEmpty()
                        group j by new { p.ProductID, p.ProductName, p.ProductPrice, p.SellerID } into g
                        select new
                        {
                            g.Key.ProductID,
                            g.Key.ProductName,
                            g.Key.ProductPrice,
                            g.Key.SellerID,
                            TotalQuantity = g.Sum(x => x.Quantity)
                        };

            this.dataGridView1.DataSource = data2.Where(c => c.SellerID == _SellerID).ToList();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            var db = new AppDbContext();
            var Product = new Product()
            {
                SellerID = _SellerID,
            };
            db.Products.Add(Product);
            db.SaveChanges();

            var frm = new SellerProductAdd(Product.ProductID, _SellerID);
            frm.ProductAddNew();
            frm.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            int _productid = (int)row.Cells[0].Value;

            var frm2 = new SellerProductAdd(_productid, _SellerID);
            frm2.ProductEdit(_productid, _SellerID);
            frm2.ShowDialog();
        }

        private void btnrenew_Click(object sender, EventArgs e)
        {
            Display();
        }
    }
}
