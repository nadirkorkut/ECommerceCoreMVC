using ECommerceCoreMVC.Data.Entities;
using ECommerceCoreMVC.Web.Models;
using ECommerceCoreMVC.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceCoreMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private readonly IShoppingCartService _shoppingCartService;

        public HomeController(ILogger<HomeController> logger,AppDbContext context,IShoppingCartService shoppingCartService)
        {
            _logger = logger;
            _context = context;
            _shoppingCartService = shoppingCartService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.FeaturedProducts = await _context.Products.Where(p => p.Enabled).OrderBy(p => Guid.NewGuid()).Take(4).ToListAsync();
            return View();
        }

        public async Task<IActionResult> Category(int id)
        {
            var model = await _context.Categories.FindAsync(id);
            return View(model);
        }
        public async Task<IActionResult> Brand(int id)
        {
            var model = await _context.Brands.FindAsync(id);
            return View(model);
        }
        public async Task<IActionResult> Product(int id)
        {
            var model = await _context.Products.FindAsync(id);
            return View(model);
        }
        public async Task<IActionResult> AddToCart(int id)
        {
            await _shoppingCartService.AddToCart(id, 1);
            return Redirect("/");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/home/error/{code:int}")]
        public IActionResult Error(int code)
        {
            switch (code)
            {
                case 404:
                default:
                    return View("~/Views/Shared/Error404.cshtml");
            }
        }
    }
}
