using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceCoreMVC.Web.Areas.Admin.Models.DataTables
{
    public class Search
    {
        public string Value { get; set; }
        public bool Regex { get; set; }
    }
}
