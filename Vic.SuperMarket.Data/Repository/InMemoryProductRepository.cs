using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic.SuperMarket.Data.Models;

namespace Vic.SuperMarket.Data.Repository
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> _Products = new List<Product>();
        public void AddProduct(Product product)
        {
            var oldProduct = GetProductById(product.ProductId);

            if (oldProduct == null)
            {
                _Products.Add(product);
            }
            else
            {
                oldProduct.Count += product.Count;
            }
        }

        public void DeleteProductById(int productId)
        {
            var targetProduct = GetProductById(productId);
            if (targetProduct != null)
            {
                _Products.Remove(targetProduct);
            }
        }

        public Product GetProductById(int productId)
        {
            var result = _Products.FirstOrDefault(x => x.ProductId == productId);
            return result;
        }

        public List<Product> GetProducts()
        {
            return _Products;
        }

        public Product UpdateProduct(int productId, Product newValue)
        {
            var product = GetProductById(productId);
            if (product != null)
            {
                product.Name = newValue.Name;
                product.Price = newValue.Price;
                product.Count = newValue.Count;
                product.Description = newValue.Description;

            }
            return product;
        }
    }
}
