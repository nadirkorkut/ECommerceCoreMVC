using ECommerceCoreMVC.Data.Entities;
using ECommerceCoreMVC.Web.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceCoreMVC.Web.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ShoppingCartService(AppDbContext context,IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task AddToCart(int productId, int quantity = 1)
        {
            var product = await _context.Products.FindAsync(productId);
            var cookie = _httpContextAccessor.HttpContext.Request.Cookies["shoppingCart"];
            var shoppingCart = new ShoppingCart();
            if (!string.IsNullOrEmpty(cookie))
                shoppingCart = JsonConvert.DeserializeObject<ShoppingCart>(cookie);
            shoppingCart.Add(product, quantity);

            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Today.AddMonths(1)
            };
            _httpContextAccessor.HttpContext.Response.Cookies.Append("shoppingCart", JsonConvert.SerializeObject(shoppingCart), cookieOptions);
            
        }

        public async Task ClearCart()
        {
            await Task.Run(() =>
            {
                _httpContextAccessor.HttpContext.Response.Cookies.Delete("shoppingCart");
            });     
        }

        public async Task RemoveFromCart(int productId)
        {
            await Task.Run(() =>
            {
                var cookie = _httpContextAccessor.HttpContext.Request.Cookies["shoppingCart"];
                var shoppingCart = JsonConvert.DeserializeObject<ShoppingCart>(cookie);
                shoppingCart.Remove(productId);

                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Today.AddMonths(1)
                };
                _httpContextAccessor.HttpContext.Response.Cookies.Append("shoppingCart", JsonConvert.SerializeObject(shoppingCart), cookieOptions);
            });
        }
    }
}
