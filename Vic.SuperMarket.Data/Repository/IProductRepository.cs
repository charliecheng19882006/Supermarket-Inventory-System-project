using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic.SuperMarket.Data.Models;

namespace Vic.SuperMarket.Data.Repository
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        void AddProduct(Product product);
        Product GetProductById(int productId);
        void DeleteProductById(int productId);
        Product UpdateProduct(int productId, Product newValue);
      
    }
}
