namespace WinformPoject0527.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductInventory
    {
        [Key]
        public int InventoryID { get; set; }

        public int? ProductID { get; set; }

        public int? SellerID { get; set; }

        public int? Quantity { get; set; }

        public virtual Product Product { get; set; }

        public virtual Seller Seller { get; set; }
    }
}
