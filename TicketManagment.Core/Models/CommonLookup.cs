using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagment.Core.Models
{
    public class CommonLookup : BaseEntity
    {
        public string LookupName { get; set; }
        public string LookupKey { get; set; }
        public string LookupValue { get; set; }
        public int OrderNumber { get; set; }
        public string  Description { get; set; }
    }
}
