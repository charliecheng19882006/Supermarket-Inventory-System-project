using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vic.SuperMarket.Data.Models
{
    public class ShoppingCart
    {
        public List<ShoppingItem> ShoppingItems { get; set; } = new List<ShoppingItem>();
        public decimal TotalSum
        {
            get
            {
                return ShoppingItems.Sum(x => x.Sum);
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in ShoppingItems)
            {
                stringBuilder.AppendLine($"ProductId:{item.ProductId} Name:{item.ProductName} Price:{item.Price} Count:{item.Count} Sum:{item.Sum}");
            };

            stringBuilder.AppendLine($"Total Sum: {TotalSum}");

            return stringBuilder.ToString();
        }
    }
}
