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
        public virtual DbSet<CellarTransfer> CellarTransfers { get; set; }
        public virtual DbSet<CellarTransferDet> CellarTransferDets { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerCat> CustomerCats { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
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
        public virtual DbSet<TypeDocument> TypeDocuments { get; set; }
        public virtual DbSet<UserSy> UserSys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP\\SQLEXPRESS; Database=ferreteria_db; Trusted_Connection=True;");
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

                entity.Property(e => e.NoDoc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("no_doc");

                entity.Property(e => e.Serie)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("serie");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.Total)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("total");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Buys)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_buy_supplier");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Buys)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_buy");
            });

            modelBuilder.Entity<BuyDet>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ProductId })
                    .HasName("pk_buy_det");

                entity.ToTable("buy_det");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

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

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.BuyDets)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_product");
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

            modelBuilder.Entity<CellarTransfer>(entity =>
            {
                entity.ToTable("cellar_transfer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CellarDestinationId).HasColumnName("cellar_destination_id");

                entity.Property(e => e.CellarOriginId).HasColumnName("cellar_origin_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.NoTransfer)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("no_transfer");

                entity.HasOne(d => d.CellarDestination)
                    .WithMany(p => p.CellarTransferCellarDestinations)
                    .HasForeignKey(d => d.CellarDestinationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cellar_dest_id");

                entity.HasOne(d => d.CellarOrigin)
                    .WithMany(p => p.CellarTransferCellarOrigins)
                    .HasForeignKey(d => d.CellarOriginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cellar_origin_id");
            });

            modelBuilder.Entity<CellarTransferDet>(entity =>
            {
                entity.ToTable("cellar_transfer_det");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CellarTransId).HasColumnName("cellar_trans_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Units).HasColumnName("units");

                entity.HasOne(d => d.CellarTrans)
                    .WithMany(p => p.CellarTransferDets)
                    .HasForeignKey(d => d.CellarTransId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cellar_trans_id");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

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

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CategoryId)
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

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("inventory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BuyId).HasColumnName("buy_id");

                entity.Property(e => e.CellarId).HasColumnName("cellar_id");

                entity.Property(e => e.CellarTransId).HasColumnName("cellar_trans_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.SaleId).HasColumnName("sale_id");

                entity.Property(e => e.Units).HasColumnName("units");
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

                entity.Property(e => e.CellarId).HasColumnName("cellar_id");

                entity.Property(e => e.Maximum).HasColumnName("maximum");

                entity.Property(e => e.Minimm).HasColumnName("minimm");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Cellar)
                    .WithMany(p => p.MinMaxProds)
                    .HasForeignKey(d => d.CellarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_min_max_cellar");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.MinMaxProds)
                    .HasForeignKey(d => d.ProductId)
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

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.MeasureId).HasColumnName("measure_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Sku)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sku");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("fk_category");

                entity.HasOne(d => d.Measure)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.MeasureId)
                    .HasConstraintName("fk_measure");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.StatusId)
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

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.NoDoc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("no_doc");

                entity.Property(e => e.Serie)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("serie");

                entity.Property(e => e.Total)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("total");

                entity.Property(e => e.TranStatusId).HasColumnName("tran_status_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sale_customer");

                entity.HasOne(d => d.TranStatus)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.TranStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tran_status");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sale_user");
            });

            modelBuilder.Entity<SaleDet>(entity =>
            {
                entity.HasKey(e => new { e.IdSale, e.ProductId })
                    .HasName("pk_sale_det");

                entity.ToTable("sale_det");

                entity.Property(e => e.IdSale).HasColumnName("id_sale");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

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

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

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

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.CategoryId)
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

            modelBuilder.Entity<TypeDocument>(entity =>
            {
                entity.ToTable("type_document");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<UserSy>(entity =>
            {
                entity.ToTable("user_sys");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.RolId).HasColumnName("rol_id");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.UserSies)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("fk_rol_user");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
