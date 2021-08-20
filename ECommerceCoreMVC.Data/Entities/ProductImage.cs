using ECommerceCoreMVC.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceCoreMVC.Data.Entities
{
    public class ProductImage : BaseEntity
    {
        #region Properties
        public string Image { get; set; }
        public int ProductId { get; set; }

        #endregion

        #region Navigation
        public virtual Product Product { get; set; }

        #endregion

        public override void Build(ModelBuilder builder)
        {
            builder.Entity<ProductImage>(entity =>
            {
                entity
                .Property(p => p.Image)
                .IsRequired()
                .IsUnicode(false);
            });
        }
    }
}
