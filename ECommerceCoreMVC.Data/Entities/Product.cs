using ECommerceCoreMVC.Data.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerceCoreMVC.Data.Entities
{
    public class Product : BaseEntity
    {
        #region Properties

        [Display(Name = "Ürün Adı")]
        [Required(ErrorMessage = "{0} Alanı Boş Bırakılamaz!")]
        [MaxLength(250, ErrorMessage = "{0} Alanı En Fazla {1} Karakter Olmalıdır!")]
        public string Name { get; set; }
        public string Image { get; set; }

        [Display(Name = "Ürün Kodu")]
        [Required(ErrorMessage = "{0} Alanı Boş Bırakılamaz!")]
        public string ProductCode { get; set; }
        
        [Display(Name = "Barkod")]
        [RegularExpression(@"^[0-9]{13}$",ErrorMessage ="Lütfen Geçerli Bir Barkod Numarası Yazınız.")]
        public string Barcode { get; set; }
        public decimal Price { get; set; }

        [Display(Name = "İndirim Oranı")]
        [Required(ErrorMessage = "{0} Alanı Boş Bırakılamaz!")]
        [RegularExpression(@"^[0-9]{0,2}$", ErrorMessage = "Lütfen Geçerli Bir İndirim Oranı Yazınız.")]
        public int Discount { get; set; }

        [Display(Name = "Ürün Açıklaması")]
        [DataType(DataType.MultilineText)]
        public string Descriptions { get; set; }
        public int Reviews { get; set; }
        [Display(Name = "Marka")]
        public int? BrandId { get; set; }
        
        [NotMapped]
        [Display(Name = "Fiyat")]
        [RegularExpression(@"^[0-9]+(\,[0-9]{1,2})?$", ErrorMessage = "Lütfen Geçerli Bir İndirim Oranı Yazınız.")]
        public string PriceText { get; set; }
        [NotMapped]
        [Display(Name = "Görsel")]
        public IFormFile PictureFile { get; set; }
        [NotMapped]
        [Display(Name = "Kategoriler")]
        public int[] SelectedCategories { get; set; }

        [NotMapped]
        [Display(Name = "Görsel Galerisi")]
        public IFormFile[] PictureFiles { get; set; }

        [NotMapped]
        public int[] PictureFilesToDeleted { get; set; }

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
