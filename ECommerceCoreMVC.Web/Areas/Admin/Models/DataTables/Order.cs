using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceCoreMVC.Web.Areas.Admin.Models.DataTables
{
    public enum OrderDir
    {
        ASC,
        DESC
    }
    public class Order
    {
        public int Column { get; set; }
        public OrderDir Dir { get; set; }
    }
}
