using Planet.Common;
using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;
using Planet.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planet.Services.Persistence
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public string CartId
        {
            get { return GetCartId(); }
        }

        public CartService(ICartRepository cartRepository, IOrderDetailRepository orderDetailRepository)
        {
            _cartRepository = cartRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public void AddToCart(int productId)
        {
            var cartItem = GetCartItem(CartId, productId);

            if (cartItem == null)
            {
                cartItem = new Cart
                {
                    CartId = CartId,
                    ProductId = productId,
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };
                _cartRepository.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
        }

        public void RemoveFromCart(int id)
        {
            var cartItem = GetCartItem(CartId, id);

            if (cartItem == null) return;

            if (cartItem.Quantity > 1)
            {
                cartItem.Quantity--;
            }
            else
            {
                _cartRepository.Delete(cartItem);
            }
        }

        public void RemoveAllFromCart(int id)
        {
            var cartItem = GetCartItem(CartId, id);

            if (cartItem != null)
                _cartRepository.Delete(cartItem);
        }

        public void EmptyCart()
        {
            var cartItems = GetCartItems();

            foreach (var cartItem in cartItems)
            {
                _cartRepository.Delete(cartItem);
            }
        }

        public IEnumerable<Cart> GetCartItems()
        {
            return _cartRepository.Filter(c => c.CartId == CartId, "Product");
        }

        public void CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();
            foreach (var cartItem in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = order.Id,
                    ProductId = cartItem.ProductId,
                    UnitPrice = cartItem.Product.UnitPrice,
                    Quantity = cartItem.Quantity
                };

                orderTotal += cartItem.Quantity * cartItem.Product.UnitPrice;

                _orderDetailRepository.Add(orderDetail);
            }

            order.TotalAmount = orderTotal;

            EmptyCart();
        }

        public void MigrateCart(string email)
        {
            var cartItems = _cartRepository.Filter(c => c.CartId == CartId, "Product");


            //TODO:  Kiểm tra nếu user đó có tồn tại sản phẩm rồi thì update lại theo quantity mới
            foreach (var item in cartItems)
            {
                var userItem = _cartRepository.Find(c => c.CartId == email && c.ProductId == item.ProductId);
                if (userItem == null)
                {
                    item.CartId = email;
                }
                else
                {
                    userItem.Quantity = item.Quantity; // nếu có rồi thì chỉ update số lượng, ko migatte tránh trùng
                }

            }
        }

        public decimal GetTotalAmount()
        {
            return _cartRepository.Filter(c => c.CartId == CartId, "Product")
                .Select(c => c.Quantity * c.Product.UnitPrice).Sum();
        }

        public int GetQuantity()
        {
            return _cartRepository.Filter(c => c.CartId == CartId).Select(c => c.Quantity).Sum();
        }

        public Cart UpdateItem(int productId, int change)
        {
            var cartItem = GetCartItem(CartId, productId);
            if (cartItem == null) return null;

            if (change > 0)
            {
                cartItem.Quantity = change;
            }
            else
            {
                _cartRepository.Delete(cartItem);
            }


            return cartItem;
        }

        private Cart GetCartItem(string cartId, int productId)
        {
            return _cartRepository.Find(c => c.CartId == cartId && c.ProductId == productId, "Product");
        }

        private string GetCartId()
        {
            var context = HttpContext.Current;
            if (context.Session[Constant.CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[Constant.CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[Constant.CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[Constant.CartSessionKey].ToString();
        }
    }
}
