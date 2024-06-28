using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagment.Core.Models
{
    public class Comment : BaseEntity
    {
        public string TicketId { get; set; }
        public string Comments { get; set; }
    }
}
