using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Shop.DataAccess.Entities;

namespace TP_Shop.DataAccess.EF
{
    public partial class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<PromoСode> PromoСodes { get; set; }

        public virtual DbSet<Purchase> Purchases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("product-pkey");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(1024)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("purchase-pkey");

                entity.HasIndex(e => e.ProductId);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Person).HasColumnName("person");
                entity.Property(e => e.Address).HasColumnName("address");
                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Product).WithMany(e => e.Purchases)
                    .HasForeignKey(e => e.ProductId);
            });

            modelBuilder.Entity<PromoСode>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("promo-code-pkey");

                entity.ToTable("promo_code");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<PromoСode>()
                .HasMany(d => d.Products)
                .WithMany(e => e.PromoСode)
                .UsingEntity(p => p.ToTable("promo_code_to_product"));

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
