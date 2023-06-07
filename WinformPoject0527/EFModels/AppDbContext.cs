using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WinformPoject0527.EFModels
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext11")
        {
        }

        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductInventory> ProductInventories { get; set; }
        public virtual DbSet<ProductMainCategory> ProductMainCategories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }
        public virtual DbSet<ShippingMethod> ShippingMethods { get; set; }
        public virtual DbSet<ShoppingCartDetail> ShoppingCartDetails { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ProductsStock> ProductsStocks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PaymentMethod>()
                .HasMany(e => e.Sellers)
                .WithOptional(e => e.PaymentMethod)
                .HasForeignKey(e => e.PayID);

            modelBuilder.Entity<PaymentMethod>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.PaymentMethod)
                .HasForeignKey(e => e.PaymenyMethodId);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasOptional(e => e.ProductsStock)
                .WithRequired(e => e.Product);

            modelBuilder.Entity<ShippingMethod>()
                .HasMany(e => e.Sellers)
                .WithOptional(e => e.ShippingMethod)
                .HasForeignKey(e => e.ShipID);
        }
    }
}
