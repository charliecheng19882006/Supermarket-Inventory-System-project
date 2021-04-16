using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic.SuperMarket.Services;

namespace Vic.SuperMarket.CustomerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductServices productServices = new ProductServices();
            ShoppingService shoppingService = new ShoppingService();
            var cart = shoppingService.GetNewShoppingCart();

            bool isContinue = true;
            do
            {
                Console.WriteLine("Please enter your command:");
                Console.WriteLine("quit, exit, q, x to exit.");
                Console.WriteLine("GetAll to get all products.");
                Console.WriteLine("Add to add a product to shopping cart.");
                Console.WriteLine("Remove to remove a product from shopping cart.");
                Console.WriteLine("View to view current shopping cart.");
                Console.WriteLine("CheckOut to checkout current shopping cart and exist.");

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

                        Console.WriteLine("Count");
                        int count = int.Parse(Console.ReadLine());

                        shoppingService.AddToCart(cart, productId, count);

                        Console.WriteLine(cart);
                        break;

                    case "remove":
                        Console.WriteLine("ProductId:");
                        int productR_Id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Count");
                        int countR = int.Parse(Console.ReadLine());

                        shoppingService.RemoveFromCart(cart, productR_Id, countR);

                        Console.WriteLine(cart);
                        break;

                    case "view":
                        Console.WriteLine(cart);
                        break;

                    case "checkout":
                        var receipt = shoppingService.CheckOut(cart);
                        Console.WriteLine(cart);
                        isContinue = false;
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
