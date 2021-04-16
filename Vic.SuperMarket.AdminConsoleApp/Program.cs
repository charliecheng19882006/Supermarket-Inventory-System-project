using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic.SuperMarket.Data.Models;
using Vic.SuperMarket.Services;

namespace Vic.SuperMarket.AdminConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductServices productServices = new ProductServices();

            bool isContinue = true;
            do
            {
                Console.WriteLine("Please enter your command:");
                Console.WriteLine("quit, exit, q, x to exit.");
                Console.WriteLine("GetAll to get all products.");
                Console.WriteLine("Add to add a product.");
                Console.WriteLine("Delete to delete a product");
                Console.WriteLine("GetById to get a specific product by productId");
                Console.WriteLine("Update to update the data of a product");
                Console.WriteLine("UpdateCount to update the count of a product");
                var command = Console.ReadLine().ToLowerInvariant();

                switch (command)
                {
                    case "quit":
                    case "exit":
                    case "q":
                    case "x":
                        isContinue = false;
                        break;

                    case "getall":
                        var products = productServices.GetProducts();
                        if (products.Count == 0)
                        {
                            Console.WriteLine("No products in the list");
                        }
                        else
                        {
                            foreach (var item in products)
                            {
                                Console.WriteLine(item.ToString());
                            }
                        }
                        break;

                    case "add":
                        Console.WriteLine("ProductId:");
                        int productId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Price:");
                        decimal price = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Count");
                        int count = int.Parse(Console.ReadLine());
                        Console.WriteLine("Description");
                        string description = Console.ReadLine();

                        Product product = new Product()
                        {
                            ProductId = productId,
                            Name = name,
                            Price = price,
                            Count = count,
                            Description = description
                        };

                        productServices.AddProduct(product);
                        Console.WriteLine("Product added successfully!");
                        break;

                    case "delete":
                        Console.WriteLine("ProductId:");
                        int productD_Id = int.Parse(Console.ReadLine());

                        productServices.DeleteProductById(productD_Id);
                        Console.WriteLine("Product deleted successfully!");
                        break;

                    case "getbyid":
                        Console.WriteLine("ProductId:");
                        int productG_Id = int.Parse(Console.ReadLine());
                        var productG = productServices.GetProductById(productG_Id);
                        Console.WriteLine(productG);
                        break;

                    case "update":
                        Console.WriteLine("ProductId:");
                        int productU_Id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Name:");
                        string U_name = Console.ReadLine();
                        Console.WriteLine("Price:");
                        decimal U_price = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Count");
                        int U_count = int.Parse(Console.ReadLine());
                        Console.WriteLine("Description");
                        string U_description = Console.ReadLine();

                        Product newValue = new Product()
                        {
                            ProductId = productU_Id,
                            Name = U_name,
                            Price = U_price,
                            Count = U_count,
                            Description = U_description
                        };

                        productServices.UpdateProduct(productU_Id, newValue);
                        Console.WriteLine("Product successfully updated");
                        break;

                    case "updatecount":
                        Console.WriteLine("ProductId:");
                        int productUC_Id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Count:");
                        int UC_count = int.Parse(Console.ReadLine());

                        Product productUC = productServices.UpdateProductCount(productUC_Id, UC_count);
                        Console.WriteLine(productUC);
                        break;

                    default:
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("--------");
                Console.WriteLine();

            } while (isContinue);

            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}
