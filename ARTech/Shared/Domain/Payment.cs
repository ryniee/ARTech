using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTech.Shared.Domain
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string PayMeth { get; set; }
        public DateTime DateTime { get; set; }
        public int OrderSummaryId { get; set; }
        public virtual OrderSummary OrderSummary { get; set; }
    }
}
