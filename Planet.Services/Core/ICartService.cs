using Planet.Data.Core.Domain;
using System.Collections.Generic;

namespace Planet.Services.Core
{
    public interface ICartService
    {
        void AddToCart(int id);

        void RemoveFromCart(int id);

        void RemoveAllFromCart(int id);

        void EmptyCart();

        IEnumerable<Cart> GetCartItems();

        void CreateOrder(Order order);

        void MigrateCart(string email);

        decimal GetTotalAmount();

        int GetQuantity();

        Cart UpdateItem(int id, int change);
    }
}
