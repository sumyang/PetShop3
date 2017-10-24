namespace Shop.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PestShow : DbContext
    {
        public PestShow()
            : base("name=PestShow")
        {
        }

        public virtual DbSet<AdminUser> AdminUser { get; set; }
        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<Favorite> Favorite { get; set; }
        public virtual DbSet<feedBack> feedBack { get; set; }
        public virtual DbSet<Notice> Notice { get; set; }
        public virtual DbSet<OAuthInfo> OAuthInfo { get; set; }
        public virtual DbSet<OrderInfoChi> OrderInfoChi { get; set; }
        public virtual DbSet<OrderInfoFat> OrderInfoFat { get; set; }
        public virtual DbSet<ProductInfo> ProductInfo { get; set; }
        public virtual DbSet<ProductReview> ProductReview { get; set; }
        public virtual DbSet<ProductSort> ProductSort { get; set; }
        public virtual DbSet<SearchHistory> SearchHistory { get; set; }
        public virtual DbSet<ShopCart> ShopCart { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<SystemConfig> SystemConfig { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminUser>()
                .HasMany(e => e.Banner)
                .WithOptional(e => e.AdminUser)
                .HasForeignKey(e => e.uid);

            modelBuilder.Entity<AdminUser>()
                .HasMany(e => e.Notice)
                .WithOptional(e => e.AdminUser)
                .HasForeignKey(e => e.uid);

            modelBuilder.Entity<Favorite>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OAuthInfo>()
                .HasMany(e => e.OrderInfoFat)
                .WithRequired(e => e.OAuthInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OAuthInfo>()
                .HasMany(e => e.ProductReview)
                .WithRequired(e => e.OAuthInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OAuthInfo>()
                .HasMany(e => e.ShopCart)
                .WithRequired(e => e.OAuthInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderInfoChi>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderInfoChi>()
                .Property(e => e.sumprice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderInfoChi>()
                .Property(e => e.isReview)
                .IsFixedLength();

            modelBuilder.Entity<OrderInfoFat>()
                .Property(e => e.TotalPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderInfoFat>()
                .Property(e => e.carriage)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderInfoFat>()
                .Property(e => e.SumPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ProductInfo>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ProductInfo>()
                .HasMany(e => e.Favorite)
                .WithOptional(e => e.ProductInfo)
                .HasForeignKey(e => e.Pid);

            modelBuilder.Entity<ProductInfo>()
                .HasMany(e => e.OrderInfoChi)
                .WithRequired(e => e.ProductInfo)
                .HasForeignKey(e => e.Pid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductInfo>()
                .HasMany(e => e.ProductReview)
                .WithRequired(e => e.ProductInfo)
                .HasForeignKey(e => e.Pid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductInfo>()
                .HasMany(e => e.ShopCart)
                .WithRequired(e => e.ProductInfo)
                .HasForeignKey(e => e.Pid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductSort>()
                .HasMany(e => e.ProductInfo)
                .WithOptional(e => e.ProductSort)
                .HasForeignKey(e => e.psid);

            modelBuilder.Entity<ShopCart>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ShopCart>()
                .Property(e => e.TotalPrice)
                .HasPrecision(19, 4);
        }
    }
}
