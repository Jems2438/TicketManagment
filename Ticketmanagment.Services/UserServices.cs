using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagment.Core.Contracts;
using TicketManagment.Core.Models;

namespace Ticketmanagment.Services
{
    public class UserServices : IUserService
    {
        IRepository<Users> userContext;

        public UserServices(IRepository<Users> UserContext)
        {
            this.userContext = UserContext;
        }

        
        

    }
}
