using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceCoreMVC.Web.Models
{
    public class LoginViewModel
    {
        [Display(Name ="E-Posta")]
        [Required(ErrorMessage ="{0} Alanı Boş Geçilemez!")]
        [EmailAddress(ErrorMessage ="Lütfen Geçerli Bir E-Posta Adresi Giriniz!")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Display(Name = "Parola")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Oturum Açık Kalsın")]
        public bool IsPersistent { get; set; }
        public string ReturnUrl { get; set; }
    }
}
