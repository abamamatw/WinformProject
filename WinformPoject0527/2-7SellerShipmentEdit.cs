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
    public partial class SellerShipmentEdit : Form
    {

        public int _shipmentid;
        public int _orderid;
        public int _sellerid;


        public SellerShipmentEdit()
        {
            InitializeComponent();
            this.Load += SellerShipmentEdit_Load;
         
        }

        private void SellerShipmentEdit_Load(object sender, EventArgs e)
        {
            Display();
            DisplayView();
        }

        public void Display()
        {
            IQueryable<Shipment> query = new AppDbContext().Shipments.AsQueryable();
            txtShipmentID.Text = query.Where(x => x.ShipmentID == _shipmentid).Select(x => x.ShipmentID).FirstOrDefault().ToString();
            txtOrderId.Text = query.Where(x => x.ShipmentID == _shipmentid).Select(x => x.OrderID).FirstOrDefault().ToString();
            txtSellerId.Text = query.Where(x => x.ShipmentID == _shipmentid).Select(x => x.SellerID).FirstOrDefault().ToString();
            txtTime1.Text = query.Where(x => x.ShipmentID == _shipmentid).Select(x => x.ShipmentDate).FirstOrDefault()?.ToString("yyyy-MM-dd");

            if (query.Where(x => x.ShipmentID == _shipmentid).Select(x => x.ShipDate).FirstOrDefault() != null)
            {
                btnShip.Enabled = false;
                btnArrival.Enabled = true;
                txtAction1.Text = query.Where(x => x.ShipmentID == _shipmentid).Select(x => x.ShipmentStatus).FirstOrDefault().ToString();
                txtTime2.Text = query.Where(x => x.ShipmentID == _shipmentid).Select(x => x.ShipDate).FirstOrDefault()?.ToString("yyyy-MM-dd HH:mm");
            }

            if (query.Where(x => x.ShipmentID == _shipmentid).Select(x => x.ArrivalTimeDate).FirstOrDefault() != null)
            {
                btnArrival.Enabled = false;
                btnCompletion.Enabled = true;
                txtAction2.Text = query.Where(x => x.ShipmentID == _shipmentid).Select(x => x.CompletionStatus).FirstOrDefault().ToString();
                txtTime3.Text = query.Where(x => x.ShipmentID == _shipmentid).Select(x => x.ArrivalTimeDate).FirstOrDefault()?.ToString("yyyy-MM-dd HH:mm");
            }

            if (query.Where(x => x.ShipmentID == _shipmentid).Select(x => x.CompletionDate).FirstOrDefault() != null)
            {
                btnCompletion.Enabled = false;
                txtAction3.Text = query.Where(x => x.ShipmentID == _shipmentid).Select(x => x.ReceiveStatus).FirstOrDefault().ToString();
                txtTime4.Text = query.Where(x => x.ShipmentID == _shipmentid).Select(x => x.CompletionDate).FirstOrDefault()?.ToString("yyyy-MM-dd HH:mm");
            }
        }

        public void DisplayView()
        {
            IQueryable<OrderDetail> query = new AppDbContext().OrderDetails.AsNoTracking();
            this.dataGridView1.DataSource = query.ToList();

            var db = new AppDbContext();
            var data = from o in db.OrderDetails
                       join p in db.Products
                       on o.ProductID equals p.ProductID
                       select new
                       {
                           o.ProductID,
                           p.ProductName,
                           p.ProductPrice,
                           o.Quantity,
                           p.SellerID,
                           o.OrderID,
                       };
            this.dataGridView1.DataSource = data.Where(c => c.OrderID == _orderid && c.SellerID == _sellerid).ToList();
        }

        private void btnShip_Click(object sender, EventArgs e)
        {
            //0=準備中
            //1=已出貨
            txtAction1.Text = "已出貨";
            btnShip.Enabled = false;
            txtTime2.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            btnArrival.Enabled = true;

            //// 更新資料
            var db = new AppDbContext();
            var shipment = db.Shipments.Find(_shipmentid);
            shipment.ShipmentStatus = "已出貨";
            shipment.ShipDate = DateTime.Now;
            db.SaveChanges();
        }

        private void btnArrival_Click(object sender, EventArgs e)
        {
            //0=物流中
            //1=已送達
            txtAction2.Text = "已送達";
            btnArrival.Enabled = false;
            txtTime3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            btnCompletion.Enabled = true;
            txtAction3.Text = "等候領取";

            // 更新資料
            var db = new AppDbContext();
            var shipment = db.Shipments.Find(_shipmentid);
            shipment.CompletionStatus = "已送達";
            shipment.ArrivalTimeDate = DateTime.Now;
            db.SaveChanges();
        }

        private void btnCompletion_Click(object sender, EventArgs e)
        {
            //0=等候中 訂單初始狀態
            //1=等候領取 已送達後狀態
            //2=已領取 領取後狀態
            //3=已結單 確認領取完成所有流程狀態

            //原本應該為 等候中 物品送達後轉等候領取 確認領取後才會變為已領取 已領取狀態才會開啟按鈕進行確認
            txtAction3.Text = "已結單";
            btnCompletion.Enabled = false;
            txtTime4.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            // 更新資料
            var db = new AppDbContext();
            var shipment = db.Shipments.Find(_shipmentid);
            shipment.ReceiveStatus = "已結單";
            shipment.CompletionDate = DateTime.Now;
            db.SaveChanges();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var db = new AppDbContext();
            var shipment = db.Shipments.Find(_shipmentid);
            shipment.ShipmentStatus = null;
            shipment.ShipDate = null;
            shipment.CompletionStatus = null;
            shipment.ArrivalTimeDate = null;
            shipment.ReceiveStatus = null;
            shipment.CompletionDate = null;
            db.SaveChanges();

            this.Close();
        }
    }
}
