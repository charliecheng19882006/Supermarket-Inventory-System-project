using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vic.SuperMarket.Data.Models
{
    public class Receipt
    {
        public int ReceiptId { get; set; }
        public DateTimeOffset TimeStamp { get; set; } = DateTimeOffset.Now;

        public List<ReceiptItem> ReceiptItems { get; set; } = new List<ReceiptItem>();
        public decimal TotalSum
        {
            get
            {
                return ReceiptItems.Sum(x => x.ProductPrice);
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"ReceiptId: {ReceiptId}");

            stringBuilder.AppendLine($"TimeStamp: {TimeStamp}");

            foreach (var item in ReceiptItems)
            {
                stringBuilder.AppendLine($"ProductId:{item.ProductId} Name:{item.ProductName} Price:{item.ProductPrice}");
            }

            stringBuilder.AppendLine($"Total Price: {TotalSum}");

            return stringBuilder.ToString();
        }

    }
}
