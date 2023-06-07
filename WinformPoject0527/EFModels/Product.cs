namespace WinformPoject0527.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ProductInventories = new HashSet<ProductInventory>();
            ShoppingCartDetails = new HashSet<ShoppingCartDetail>();
        }

        public int ProductID { get; set; }

        public int? SellerID { get; set; }

        [StringLength(50)]
        public string CategoryID { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(200)]
        public string ProductDescription { get; set; }

        [Column(TypeName = "money")]
        public decimal? ProductPrice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductInventory> ProductInventories { get; set; }

        public virtual Seller Seller { get; set; }

        public virtual ProductsStock ProductsStock { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoppingCartDetail> ShoppingCartDetails { get; set; }
    }
}
