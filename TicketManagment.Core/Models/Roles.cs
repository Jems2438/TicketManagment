using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagment.Core.Models
{
    public class Roles :BaseEntity
    {
        public string  Name { get; set; }
        public string Code { get; set; }

    }
}
