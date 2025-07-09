using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DairyManagement.Infrastructure;

namespace DairyManagement.Infrastructure.DbContexts
{
    public partial class DairyDbContext : DbContext
    {
        public DairyDbContext()
        {
        }

        public DairyDbContext(DbContextOptions<DairyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<ClientOrder> ClientOrders { get; set; } = null!;
        public virtual DbSet<Inventory> Inventories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Vendor> Vendors { get; set; } = null!;
        public virtual DbSet<VendorSupply> VendorSupplies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client", "dairy");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(20)
                    .HasColumnName("contact_number");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("modified_at");

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ClientOrder>(entity =>
            {
                entity.ToTable("client_order", "dairy");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.TotalAmount)
                    .HasPrecision(10, 2)
                    .HasColumnName("total_amount");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientOrders)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("client_order_client_id_fkey");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ClientOrders)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("client_order_product_id_fkey");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("inventory", "dairy");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("modified_at");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("inventory_product_id_fkey");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product", "dairy");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasColumnName("code");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("modified_at");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasPrecision(10, 2)
                    .HasColumnName("price");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("vendor", "dairy");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(20)
                    .HasColumnName("contact_number");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("modified_at");

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<VendorSupply>(entity =>
            {
                entity.ToTable("vendor_supply", "dairy");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.TotalAmount)
                    .HasPrecision(10, 2)
                    .HasColumnName("total_amount");

                entity.Property(e => e.VendorId).HasColumnName("vendor_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.VendorSupplies)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("vendor_supply_product_id_fkey");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.VendorSupplies)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("vendor_supply_vendor_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
