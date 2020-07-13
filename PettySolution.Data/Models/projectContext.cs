using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PettySolution.Data.Models
{
    public partial class projectContext : DbContext
    {
        public projectContext()
        {
        }

        public projectContext(DbContextOptions<projectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Histories> Histories { get; set; }
        public virtual DbSet<OrderProductDetails> OrderProductDetails { get; set; }
        public virtual DbSet<OrderProductStores> OrderProductStores { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Responses> Responses { get; set; }
        public virtual DbSet<Returns> Returns { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Stores> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:nhunnhun.database.windows.net,1433;Initial Catalog=project;Persist Security Info=False;User ID=nhunnhun;Password=zaQ@1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.Property(e => e.CustomerId).HasMaxLength(255);

                entity.Property(e => e.Detail).HasMaxLength(255);

                entity.Property(e => e.District).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(255);

                entity.Property(e => e.Province).HasMaxLength(255);

                entity.Property(e => e.StoreId).HasMaxLength(255);

                entity.Property(e => e.Ward).HasMaxLength(255);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Address_Customer");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Img).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK_Customer");

                entity.Property(e => e.Username).HasMaxLength(255);

                entity.Property(e => e.DayOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Histories>(entity =>
            {
                entity.Property(e => e.CustomerId).HasMaxLength(255);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_History_Customer");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_History_Product");
            });

            modelBuilder.Entity<OrderProductDetails>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.OrderStatus).HasMaxLength(255);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.OrderProductDetails)
                    .HasPrincipalKey<Responses>(p => p.OrderProductDetailId)
                    .HasForeignKey<OrderProductDetails>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderProductDetail_Response");

                entity.HasOne(d => d.OrderProductStore)
                    .WithMany(p => p.OrderProductDetails)
                    .HasForeignKey(d => d.OrderProductStoreId)
                    .HasConstraintName("FK_OrderProductDetails_OrderProductStores");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderProductDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_OrderProductDetail_Product");
            });

            modelBuilder.Entity<OrderProductStores>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(255);

                entity.Property(e => e.OrderId).HasMaxLength(255);

                entity.Property(e => e.OrderStatus).HasMaxLength(255);

                entity.Property(e => e.StoreId).HasMaxLength(255);

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderProductStores)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderProductStore_Order");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.OrderProductStores)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_OrderProductStore_Store");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(255);

                entity.Property(e => e.CustomerId).HasMaxLength(255);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.OrderStatus).HasMaxLength(255);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Order_Address");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Order_Customer");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Brand).HasMaxLength(255);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Expiration).HasColumnType("date");

                entity.Property(e => e.Img).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.NetWeight).HasMaxLength(255);

                entity.Property(e => e.Origin).HasMaxLength(255);

                entity.Property(e => e.Price).HasMaxLength(255);

                entity.Property(e => e.Size).HasMaxLength(255);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.StoreId).HasMaxLength(255);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Product_Category");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_Product_Store");
            });

            modelBuilder.Entity<Responses>(entity =>
            {
                entity.HasIndex(e => e.OrderProductDetailId)
                    .HasName("unique_id_response")
                    .IsUnique();

                entity.Property(e => e.Contents).HasMaxLength(255);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Img).HasMaxLength(255);

                entity.Property(e => e.OrderProductDetailId).IsRequired();

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Responses)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Response_Product");
            });

            modelBuilder.Entity<Returns>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.Id)
                    .HasName("PK_Return");

                entity.HasIndex(e => e.OrderProductDetailId)
                    .HasName("Unique_id")
                    .IsUnique();

                entity.Property(e => e.Confirms).HasMaxLength(255);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Img).HasMaxLength(255);

                entity.Property(e => e.Reasion).HasMaxLength(255);

                entity.HasOne(d => d.OrderProductDetail)
                    .WithOne()
                    .HasForeignKey<Returns>(d => d.OrderProductDetailId)
                    .HasConstraintName("FK_Return_OrderProductDetail");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Stores>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK_Store");

                entity.Property(e => e.Username).HasMaxLength(255);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Detail).HasMaxLength(255);

                entity.Property(e => e.District).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.LogoImg).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(255);

                entity.Property(e => e.PostalCode).HasMaxLength(255);

                entity.Property(e => e.Province).HasMaxLength(255);

                entity.Property(e => e.Ward).HasMaxLength(255);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Store_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
