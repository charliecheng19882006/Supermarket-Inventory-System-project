using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic.SuperMarket.Data.Models;

namespace Vic.SuperMarket.Services
{
    public class ShoppingService
    {
        private readonly ProductServices _productServices = new ProductServices();

        public ShoppingCart GetNewShoppingCart()
        {
            return new ShoppingCart();
        }

        public ShoppingCart AddToCart(ShoppingCart shoppingCart, int productId, int count = 1)
        {
            Product product = _productServices.GetProductById(productId);

            if (product == null)
            {
                return shoppingCart;
            }

            if (product.Count < count)
            {
                return shoppingCart;
            }

            var shoppingItem = shoppingCart.ShoppingItems.FirstOrDefault(x => x.ProductId == productId);

            if (shoppingItem == null)
            {
                shoppingItem = new ShoppingItem
                {
                    ProductId = productId,
                    Count = count,
                    ProductName = product.Name,
                    Price = product.Price
                };
                shoppingCart.ShoppingItems.Add(shoppingItem);
            }
            else
            {
                shoppingItem.Count += count;
            }

            _productServices.UpdateProductCount(productId, product.Count - count);

            return shoppingCart;
        }

        public ShoppingCart RemoveFromCart(ShoppingCart shoppingCart, int productId, int count = 1)
        {
            var shoppingItem = shoppingCart.ShoppingItems.FirstOrDefault(x => x.ProductId == productId);

            if (shoppingItem == null)
            {
                return shoppingCart;
            }

            if (shoppingItem.Count < count)
            {
                return shoppingCart;
            }

            shoppingItem.Count -= count;

            if (shoppingItem.Count == 0)
            {
                shoppingCart.ShoppingItems.Remove(shoppingItem);
            }

            var product = _productServices.GetProductById(productId);

            _productServices.UpdateProductCount(productId, product.Count + count);

            return shoppingCart;
        }

        public Receipt CheckOut(ShoppingCart shoppingCart)
        {
            var result = new Receipt();

            foreach (var item in shoppingCart.ShoppingItems)
            {
                for (int i = 0; i < item.Count; i++)
                {
                    var receiptItem = new ReceiptItem
                    {
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        ProductPrice = item.Price
                    };

                    result.ReceiptItems.Add(receiptItem);
                }
            }
            return result;
        }
    }
}
