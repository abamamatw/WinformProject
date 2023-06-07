namespace WinformPoject0527.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Orders = new HashSet<Order>();
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string UserAccount { get; set; }

        [Required]
        [StringLength(50)]
        public string UserPassword { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string CellPhone { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string ShippingMethodId { get; set; }

        [StringLength(50)]
        public string PaymenyMethodId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual PaymentMethod PaymentMethod { get; set; }

        public virtual ShippingMethod ShippingMethod { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
