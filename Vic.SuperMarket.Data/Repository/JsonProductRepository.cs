using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic.SuperMarket.Data.Models;

namespace Vic.SuperMarket.Data.Repository
{
    public class JsonProductRepository : IProductRepository
    {
        private readonly object Synclock = new object();

        private const string ProductDbJsonFile = @"d:\products.json";
        public void AddProduct(Product product)
        {
            lock (Synclock)
            {
                var products = GetProducts();
                var oldProduct = products.FirstOrDefault(x => x.ProductId == product.ProductId);
                if (oldProduct == null)
                {
                    products.Add(product);
                }
                else
                {
                    oldProduct.Count += product.Count;
                }
                File.WriteAllText(ProductDbJsonFile, JsonConvert.SerializeObject(products));
            }
        }

        public void DeleteProductById(int productId)
        {
            lock (Synclock)
            {
                var products = GetProducts();
                var targetProduct = products.FirstOrDefault(x => x.ProductId == productId);
                if (targetProduct != null)
                {
                    products.Remove(targetProduct);
                }
                File.WriteAllText(ProductDbJsonFile, JsonConvert.SerializeObject(products));
            }
        }

        public Product GetProductById(int productId)
        {
            lock (Synclock)
            {
                var products = GetProducts();
                var result = products.FirstOrDefault(x => x.ProductId == productId);
                return result;
            }
        }

        public List<Product> GetProducts()
        {
            lock (Synclock)
            {
                try
                {
                    List<Product> result = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(ProductDbJsonFile));
                    return result;
                }
                catch
                {
                    return new List<Product>();
                }
            }
        }

        public Product UpdateProduct(int productId, Product newValue)
        {
            lock (Synclock)
            {
                var products = GetProducts();

                var product = products.FirstOrDefault(x => x.ProductId == productId);
                if (product != null)
                {
                    product.Name = newValue.Name;
                    product.Price = newValue.Price;
                    product.Count = newValue.Count;
                    product.Description = newValue.Description;
                }

                File.WriteAllText(ProductDbJsonFile, JsonConvert.SerializeObject(products));
                return product;
            }

        }
    }
}
