using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagment.Core.Models;

namespace TicketManagment.Core.ViewModels
{
    public class UserManagerViewModel 
    {
        public IEnumerable<Users> Users { get; set; }


    }
}
