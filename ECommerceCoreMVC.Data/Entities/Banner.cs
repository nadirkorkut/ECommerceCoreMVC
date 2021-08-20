using ECommerceCoreMVC.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceCoreMVC.Data.Entities
{
    public class Banner : BaseEntity
    {
        #region Properties
        public string Image { get; set; }
        public string Url { get; set; }
        public int? CategoryId { get; set; }

        #endregion

        #region Navigation
        public virtual Category Category { get; set; }

        #endregion

        public override void Build(ModelBuilder builder)
        {
            builder.Entity<Banner>(entity => {

                entity
                .Property(p => p.Image)
                .IsRequired()
                .IsUnicode(false);

            });
        }

    }
}
