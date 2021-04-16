using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vic.SuperMarket.Data.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return $"ProductId:{ProductId} Name:{Name} Price:{Price} Count:{Count} Description:{Description}";
        }
    }
}
