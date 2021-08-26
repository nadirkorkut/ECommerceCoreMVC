﻿using ECommerceCoreMVC.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceCoreMVC.Data.Entities
{
    public class Product : BaseEntity
    {
        #region Properties

        public string Name { get; set; }
        public string Image { get; set; }
        public string ProductCode { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public string Descriptions { get; set; }
        public int Reviews { get; set; }
        public int? BrandId { get; set; }

        #endregion

        #region Navigtion
        public virtual Brand Brand { get; set; }
        public virtual ICollection<CategoryProduct> CategoryProducts { get; set; } = new HashSet<CategoryProduct>();
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
        public virtual ICollection<ProductImage> ProductImages { get; set; } = new HashSet<ProductImage>();
        #endregion

        public override void Build(ModelBuilder builder)
        {
            builder.Entity<Product>(entity =>
            {
                entity
                .Property(p => p.Name)
                .HasMaxLength(250)
                .IsRequired();

                entity
                .HasIndex(p => new { p.Name })
                .IsUnique();

                entity
               .HasIndex(p => new { p.Price })
               .IsUnique(false);

                entity
                .Property(p => p.Price)
                .HasPrecision(18, 4);

                entity
               .Property(p => p.Image)
               .IsUnicode(false);

                entity
                .Property(p => p.ProductCode)
                .IsRequired();

                entity
                .Property(p => p.Barcode)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength();

                entity
                .HasMany(p => p.OrderItems)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasMany(p => p.ProductImages)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
