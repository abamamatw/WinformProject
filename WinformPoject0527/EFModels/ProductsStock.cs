namespace WinformPoject0527.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductsStock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        public int? PurchaseQuantity { get; set; }

        public int? OrderQuantity { get; set; }

        public int? QuantitySold { get; set; }

        public int? StockQuantity { get; set; }

        public virtual Product Product { get; set; }
    }
}
