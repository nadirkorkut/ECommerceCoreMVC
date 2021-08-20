using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceCoreMVC.Data.Entities
{
    public enum Genders
    {
        Male,Female
    }
    public class User : IdentityUser<int>
    {
        #region Properties
        public string Name { get; set; }
        public Genders? Gender { get; set; }

        #endregion

        #region Navigation

        public virtual ICollection<Banner> Banners { get; set; } = new HashSet<Banner>();
        public virtual ICollection<Brand> Brands { get; set; } = new HashSet<Brand>();
        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public virtual ICollection<ProductImage> ProductImages { get; set; } = new HashSet<ProductImage>();
        public virtual ICollection<Rayon> Rayons { get; set; } = new HashSet<Rayon>();

        #endregion
    }
}
