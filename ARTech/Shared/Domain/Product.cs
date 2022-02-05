using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTech.Shared.Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public char Price { get; set; }
        public int Warranty { get; set; }
        public int Qty { get; set; }
        public string Specs { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Condition { get; set; }

    }
}
