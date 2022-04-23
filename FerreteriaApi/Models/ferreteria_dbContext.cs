using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FerreteriaApi.Models
{
    public partial class ferreteria_dbContext : DbContext
    {
        public ferreteria_dbContext()
        {
        }

        public ferreteria_dbContext(DbContextOptions<ferreteria_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Buy> Buys { get; set; }
        public virtual DbSet<BuyDet> BuyDets { get; set; }
        public virtual DbSet<Cellar> Cellars { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerCat> CustomerCats { get; set; }
        public virtual DbSet<Measure> Measures { get; set; }
        public virtual DbSet<MinMaxProd> MinMaxProds { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCat> ProductCats { get; set; }
        public virtual DbSet<ProductStum> ProductSta { get; set; }
        public virtual DbSet<RolUser> RolUsers { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SaleDet> SaleDets { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierCat> SupplierCats { get; set; }
        public virtual DbSet<TranStatus> TranStatuses { get; set; }
        public virtual DbSet<UserSy> UserSys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP\\SQLEXPRESS; Database=ferreteria_db; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buy>(entity =>
            {
                entity.ToTable("buy");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.IdSupplier).HasColumnName("id_supplier");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Total)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("total");

                entity.HasOne(d => d.IdSupplierNavigation)
                    .WithMany(p => p.Buys)
                    .HasForeignKey(d => d.IdSupplier)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_buy_supplier");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Buys)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_buy");
            });

            modelBuilder.Entity<BuyDet>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdProduct })
                    .HasName("pk_buy_det");

                entity.ToTable("buy_det");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.Discount)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("discount");

                entity.Property(e => e.Price)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.SubTotal)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("sub_total");

                entity.Property(e => e.Units).HasColumnName("units");
            });

            modelBuilder.Entity<Cellar>(entity =>
            {
                entity.ToTable("cellar");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("nit");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customer_cat");
            });

            modelBuilder.Entity<CustomerCat>(entity =>
            {
                entity.ToTable("customer_cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Measure>(entity =>
            {
                entity.ToTable("measure");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MinMaxProd>(entity =>
            {
                entity.ToTable("min_max_prod");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCellar).HasColumnName("id_cellar");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.Maximum).HasColumnName("maximum");

                entity.Property(e => e.Minimm).HasColumnName("minimm");

                entity.HasOne(d => d.IdCellarNavigation)
                    .WithMany(p => p.MinMaxProds)
                    .HasForeignKey(d => d.IdCellar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_min_max_cellar");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.MinMaxProds)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pk_prod_min_max");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BuyPrice)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("buy_price");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.IdMeasure).HasColumnName("id_measure");

                entity.Property(e => e.IdStatus).HasColumnName("id_status");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Sku)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sku");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("fk_category");

                entity.HasOne(d => d.IdMeasureNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdMeasure)
                    .HasConstraintName("fk_measure");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("fk_status");
            });

            modelBuilder.Entity<ProductCat>(entity =>
            {
                entity.ToTable("product_cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ProductStum>(entity =>
            {
                entity.ToTable("product_sta");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<RolUser>(entity =>
            {
                entity.ToTable("rol_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("sale");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.IdCustomer).HasColumnName("id_customer");

                entity.Property(e => e.IdTranStatus).HasColumnName("id_tran_status");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Total)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("total");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sale_customer");

                entity.HasOne(d => d.IdTranStatusNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.IdTranStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tran_status");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sale_user");
            });

            modelBuilder.Entity<SaleDet>(entity =>
            {
                entity.HasKey(e => new { e.IdSale, e.IdProduct })
                    .HasName("pk_sale_det");

                entity.ToTable("sale_det");

                entity.Property(e => e.IdSale).HasColumnName("id_sale");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.Discount)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("discount");

                entity.Property(e => e.Price)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.SubTotal)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("sub_total");

                entity.Property(e => e.Units).HasColumnName("units");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("supplier");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("nit");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_suppplier_cat");
            });

            modelBuilder.Entity<SupplierCat>(entity =>
            {
                entity.ToTable("supplier_cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TranStatus>(entity =>
            {
                entity.ToTable("tran_status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<UserSy>(entity =>
            {
                entity.ToTable("user_sys");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.UserSies)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("fk_rol_user");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
