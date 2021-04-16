using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic.SuperMarket.Data.Models;
using Vic.SuperMarket.Data.Repository;

namespace Vic.SuperMarket.Services
{
    public class ProductServices
    {
        private readonly IProductRepository _productRepository=  new JsonProductRepository();
        public List<Product> GetProducts()
        {
           return _productRepository.GetProducts();
        }

        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }

        public Product GetProductById (int productId)
        {
            return _productRepository.GetProductById(productId);
        }

        public void DeleteProductById (int productId)
        {
            _productRepository.DeleteProductById(productId);
        }

        public Product UpdateProduct (int productId, Product newValue)
        {
            return _productRepository.UpdateProduct(productId, newValue);
        }

        public Product UpdateProductCount (int productId, int count)
        {
            var product = GetProductById(productId);
            if (product != null)
            {
                product.Count = count;
                _productRepository.UpdateProduct(productId, product);
            }

            return product;
        }
    }
}
