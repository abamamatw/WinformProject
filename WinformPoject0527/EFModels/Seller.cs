namespace WinformPoject0527.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Seller
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Seller()
        {
            ProductInventories = new HashSet<ProductInventory>();
            Products = new HashSet<Product>();
            Shipments = new HashSet<Shipment>();
        }

        public int SellerID { get; set; }

        [StringLength(50)]
        public string SellerName { get; set; }

        [StringLength(50)]
        public string SellerAccount { get; set; }

        [StringLength(50)]
        public string SellerPassword { get; set; }

        [StringLength(50)]
        public string SellerContact { get; set; }

        [StringLength(50)]
        public string SellerAddress { get; set; }

        [StringLength(50)]
        public string SellerPhone { get; set; }

        [StringLength(50)]
        public string ShipID { get; set; }

        [StringLength(50)]
        public string PayID { get; set; }

        public virtual PaymentMethod PaymentMethod { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductInventory> ProductInventories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }

        public virtual ShippingMethod ShippingMethod { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
