using ECommerceCoreMVC.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceCoreMVC.Web.Components
{
    public class RayonMenuViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public RayonMenuViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var model = _context.Rayons.Where(p => p.Enabled).OrderBy(p => p.SortOrder).ToList();
            return View(model);
        }
    }
}
