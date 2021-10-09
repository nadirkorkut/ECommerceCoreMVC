using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceCoreMVC.Web.Services
{
    public interface IShoppingCartService
    {
        Task AddToCart(int productId, int quantity = 1);
        Task RemoveFromCart(int productId);
        Task ClearCart();

    }
}
