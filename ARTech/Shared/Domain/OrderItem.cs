using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTech.Shared.Domain
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderQty { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int? OrderSummaryId { get; set; }
        public virtual OrderSummary OrderSummary { get; set; }
    }
}
