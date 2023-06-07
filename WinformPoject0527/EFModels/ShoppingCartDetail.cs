namespace WinformPoject0527.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ShoppingCartDetail
    {
        [Key]
        public int CartDetailID { get; set; }

        public int? CartID { get; set; }

        public int? ProductID { get; set; }

        public int? Quantity { get; set; }

        public virtual Product Product { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
