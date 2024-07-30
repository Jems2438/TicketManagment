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
    public class RoleServices : IRoleService
    {
        IRepository<Roles> rolesContext;
        IRepository<Users> userContext;

        public RoleServices(IRepository<Roles> RolesContext, IRepository<Users> userContext)
        {
            this.rolesContext = RolesContext;
            this.userContext = userContext;
        }

        public List<RoleListViewModel> GetRolesList()
        {

            var userList = userContext.Collection().ToList();
            var roleList = rolesContext.Collection().ToList();
            var result = (from p in roleList
                          select new RoleListViewModel()
                          {
                              Id = p.Id,
                              CreatedBy = userContext.Collection().Where(x => x.Id == p.CreatedBy)
                                                .Select(y => y.UserName).FirstOrDefault(),
                              CreatedAt = p.CreatedAt,
                              Name = p.Name,
                              Code = p.Code,
                              UpdatedBy = userContext.Collection().Where(x => x.Id == p.UpdatedId)
                                                .Select(y => y.UserName).FirstOrDefault(),
                              UpdatedAt = p.UpdatedAt
                          }).ToList();
            return result;
        }

        public void CreateRole(Roles role,string emailId)
        {
           
            var users = userContext.Collection().FirstOrDefault(x => x.Email == emailId);

            Roles newRole = new Roles()
                            {
                                Name = role.Name,
                                Code = role.Code,
                                CreatedBy = users.Id
                                
                            };
            //role.UpdatedAt = DateTime.Now;
            //role.CreatedBy = users.Id;
            rolesContext.Insert(newRole);
            rolesContext.Commit();    
        }

        public void EditRole(Roles role,string Id,string rolesToEdit)
        {
           
            Roles roleEdit = rolesContext.Find(rolesToEdit);
            var users = userContext.Collection().FirstOrDefault(x => x.Email == Id);
            
            roleEdit.Name = role.Name;
            roleEdit.Code = role.Code;
            roleEdit.UpdatedId = users.Id;
            roleEdit.UpdatedAt = DateTime.Now;

            rolesContext.Commit();
        }

        public void FinalDelete(string Id)
        {
            rolesContext.Delete(Id);
            rolesContext.Commit();
        }

    }
}
