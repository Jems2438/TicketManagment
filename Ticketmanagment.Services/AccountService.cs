using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagment.Core.Contracts;
using TicketManagment.Core.Models;
using TicketManagment.Core.ViewModels;

namespace Ticketmanagment.Services
{
    public class AccountService : IAccountService
    {
            IRepository<Users> userContext;
            IRepository<Roles> roleContext;
        IRepository<UserRole> userRoleContext;
        

            public AccountService(IRepository<UserRole> userRoleContext,IRepository<Roles> roleContext, IRepository<Users> UserContext)
            {
            this.userRoleContext = userRoleContext;
                this.userContext = UserContext;
                this.roleContext = roleContext;
            }
        public void Registration(UserRegisterViewModel model, string UserId)
        {
            Users users = new Users()
            {
                UserName = model.UserName,
                Email = model.Email,
                Role = model.Role,
                Password = model.Password,
                CreatedBy = userContext.Collection().Where(x => x.Email == UserId)
                                          .Select(x => x.Id).FirstOrDefault()
            };
            userContext.Insert(users);

            UserRole userRole = new UserRole()
            {
                UserId = users.Id,
                RoleId = roleContext.Collection().Where(x => x.Code == model.Role)
                                            .Select(x => x.Id).FirstOrDefault(),
                CreatedBy = users.CreatedBy
            };

            userRoleContext.Insert(userRole);
            userRoleContext.Commit();
            userContext.Commit();
        }
           
        
    }
}
