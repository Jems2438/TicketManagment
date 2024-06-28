using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagment.Core.Contracts;
using TicketManagment.Core.Models;

namespace Ticketmanagment.Services
{
    public class UserService : IUserService
    {
        IRepository<Users> userContext;

        public UserService(IRepository<Users> UserContext)
        {
            this.userContext = UserContext;
        }
        public void CreateUser(Users userdata)
        {
            Users data = new Users()
            {
                UserName = userdata.UserName,
                Email = userdata.Email,
                Role = userdata.Role,
                Password = userdata.Password

            };
            userContext.Insert(data);
            userContext.Commit();

        }
    }
}
