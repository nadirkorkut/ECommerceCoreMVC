using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceCoreMVC.Data.Entities
{
    public class Role : IdentityRole<int>
    {
        #region Properties
        public string DisplayName { get; set; }

        #endregion
    }
}
