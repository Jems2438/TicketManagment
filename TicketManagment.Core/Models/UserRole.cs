using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagment.Core.Models
{
    public class UserRole : BaseEntity
    {
        public string UserId { get; set; }
        public string UpdatedRole { get; set; }
        public string  RoleId { get; set; }

    }
}
