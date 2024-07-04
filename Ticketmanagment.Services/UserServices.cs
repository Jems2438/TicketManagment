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

        public List<Users> GetUserList()
        {
            var model = userContext.Collection().ToList();
            var result = (from p in model
                          select new Users()
                          {
                              Id = p.Id,
                              CreatedAt = p.CreatedAt,
                              UserName = p.UserName,
                              Password = p.Password,
                              CreatedBy = userContext.Collection().Where(x => x.Id == p.Id)
                                                .Select(y => y.UserName).FirstOrDefault(),
                              Email = p.Email,
                              UpdatedAt = p.UpdatedAt,
                              UpdatedId = userContext.Collection().Where(x => x.Id == p.Id)
                                                .Select(y => y.UserName).FirstOrDefault(),
                          });
            return result.ToList();
        }

        public void EditUser(Users users, string Id, string userToEdit)
        {
            Users userEdit = userContext.Find(userToEdit);
            var usersId = userContext.Collection().FirstOrDefault(x => x.Email == Id);
      
            userEdit.Role = users.Role;
            userEdit.IsActive = users.IsActive;
            userEdit.UserName = users.UserName;
            userEdit.Email = users.Email;
            userEdit.UpdatedAt = DateTime.Now;
            userEdit.UpdatedId = usersId.Id;
           
            userContext.Commit();
        }


    }
}
