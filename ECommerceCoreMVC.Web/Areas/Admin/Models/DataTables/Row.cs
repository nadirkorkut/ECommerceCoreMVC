using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceCoreMVC.Web.Areas.Admin.Models.DataTables
{
    public abstract class Row
    {
        public virtual string RowId => null;
        public virtual string RowClass => null;
        public virtual object RowData => null;
    }
}
