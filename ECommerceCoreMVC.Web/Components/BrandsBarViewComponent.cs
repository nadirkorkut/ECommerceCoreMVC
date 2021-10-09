using ECommerceCoreMVC.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceCoreMVC.Web.Components
{
    public class BrandsBarViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public BrandsBarViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var model = _context.Brands.Where(p => p.Enabled).OrderBy(p => p.SortOrder).Take(3).ToList();
            return View(model);
        }
    }
}
