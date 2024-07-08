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
        IRepository<UserRole> userRoleContext;
        IRepository<Roles> roleContext;

        public UserServices(IRepository<Roles> roleContext,IRepository<Users> UserContext,IRepository<UserRole> userRoleConetext)
        {
            this.roleContext = roleContext;
            this.userContext = UserContext;
            this.userRoleContext = userRoleConetext;
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
                              CreatedBy = userContext.Collection().Where(x => x.Id == p.CreatedBy)
                                                .Select(y => y.UserName).FirstOrDefault(),
                              Email = p.Email,
                              UpdatedAt = p.UpdatedAt,
                              UpdatedId = userContext.Collection().Where(x => x.Id == p.UpdatedId)
                                                .Select(y => y.UserName).FirstOrDefault(),
                              Role = p.Role
                          });
            return result.ToList();
        }

        public void EditUser(Users users, string emailId, string userToEdit)
        {
            Users userEdit = userContext.Find(userToEdit);
            var usersId = userContext.Collection().FirstOrDefault(x => x.Email == emailId);
            var InitialUserRole = usersId.Role;

            userEdit.Role = users.Role;
            userEdit.IsActive = users.IsActive;
            userEdit.UserName = users.UserName;
            userEdit.Email = users.Email;
            userEdit.UpdatedAt = DateTime.Now;
            userEdit.UpdatedId = usersId.Id;
           
            var userRoleEdited = userRoleContext.Collection().Where(x => x.UserId == userEdit.Id)
                                        .Select(x => x.Id).FirstOrDefault();
            UserRole editRole = userRoleContext.Find(userRoleEdited);
            if(InitialUserRole != users.Role)
            {
                editRole.RoleId = roleContext.Collection().Where(x => x.Code == users.Role)
                                        .Select(x => x.Id).FirstOrDefault();
                editRole.UpdatedAt = DateTime.Now;
                editRole.UpdatedId = usersId.Id;
                userRoleContext.Commit();
            }  
            
            userContext.Commit();
        }

    }
}
