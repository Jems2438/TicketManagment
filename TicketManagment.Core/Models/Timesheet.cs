using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagment.Core.Models
{
    public class Timesheet : BaseEntity
    {
        public string TicketId { get; set; }
        public string Description { get; set; }
        public int Worked_Hours { get; set; }

    }
}
