using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTech.Shared.Domain
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string FirstName { get; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public string Race { get; set; }
        public string Position { get; set; }

    }
}
