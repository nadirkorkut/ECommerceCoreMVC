using ECommerceCoreMVC.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerceCoreMVC.Data.Entities
{
    public class Category : BaseEntity
    {
        #region Properties
        [Display(Name = "Kategori Adı")]
        [Required(ErrorMessage = "{0} Alanı Boş Bırakılamaz!")]
        [MaxLength(50, ErrorMessage = "{0} Alanı En Fazla {1} Karakter Olmalıdır!")]
        public string Name { get; set; }
        public int SortOrder { get; set; }
        [Display(Name = "Reyon Adı")]
        [Required(ErrorMessage = "{0} Alanı Boş Bırakılamaz!")]
        public int RayonId { get; set; }

        #endregion

        #region Navigation
        public virtual ICollection<Banner> Banners { get; set; } = new HashSet<Banner>();
        public virtual ICollection<CategoryProduct> CategoryProducts { get; set; } = new HashSet<CategoryProduct>();
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

            });
        }

    }
}
