using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagment.Core.Models
{
    public class Ticket : BaseEntity
    {
        public string  Title { get; set; }
        public string Decription { get; set; }
        public string AssignId { get; set; }
        public string  Status { get; set; }
        public string CreatedBy { get; set; }
        public string ProjectName { get; set; }
        public string  Priorityid { get; set; }

    }
}
