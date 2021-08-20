using ECommerceCoreMVC.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceCoreMVC.Data.Entities
{
    public class Category : BaseEntity
    {
        #region Properties
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public int RayonId { get; set; }

        #endregion

        #region Navigation
        public virtual ICollection<Banner> Banners { get; set; } = new HashSet<Banner>();
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public virtual Rayon Rayon { get; set; }
        #endregion

        public override void Build(ModelBuilder builder)
        {
            builder.Entity<Category>(entity => {

                entity
               .Property(p => p.Name)
               .HasMaxLength(50)
               .IsRequired();

                entity
                .HasIndex(p => new { p.Name, p.RayonId })
                .IsUnique();

                entity
                .HasMany(p => p.Banners)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

                entity
                .HasMany(p => p.Products)
                .WithMany(p => p.Categories);

            });
        }

    }
}
