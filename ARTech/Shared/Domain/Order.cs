using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTech.Shared.Domain
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public DateTime DateTime { get; set; }
        public int LogisticId { get; set; }
        public virtual Logistic Logistic { get; set; }
        public string ShippingAddress { get; set; }
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
