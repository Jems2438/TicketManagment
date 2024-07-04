using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagment.Core.Models;

namespace TicketManagment.Core.ViewModels
{
    public class RoleListViewModel
    {
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset  CreatedAt { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

    }
}
