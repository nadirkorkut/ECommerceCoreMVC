using ECommerceCoreMVC.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceCoreMVC.Data.Entities
{
    public class Rayon : BaseEntity
    {
        #region Properties
        public string Name { get; set; }
        public int SortOrder { get; set; }

        #endregion

        #region Navigation
        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();


        #endregion


        public override void Build(ModelBuilder builder)
        {
            builder.Entity<Rayon>(entity => {

                entity
               .Property(p => p.Name)
               .HasMaxLength(50)
               .IsRequired();

                entity
                .HasIndex(p => new { p.Name })
                .IsUnique();

                entity
                .HasMany(p => p.Categories)
                .WithOne(p => p.Rayon)
                .HasForeignKey(p => p.RayonId)
                .OnDelete(DeleteBehavior.Restrict);

            });
        }


    }
}
