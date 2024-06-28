using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagment.Core.Models
{
    public class Roles :BaseEntity
    {
        public string  RoleName { get; set; }
        public string RoleCode { get; set; }

    }
}
