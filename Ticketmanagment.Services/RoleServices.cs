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
        public RoleServices(IRepository<Roles> RolesContext)
        {
            this.rolesContext = RolesContext;
        }

        public List<RoleCreateViewModel> GetRolesList()
        {
            RoleCreateViewModel model = new RoleCreateViewModel();
            
            return model;
        }

        public void CreateRole(Roles role,string Id)
        {
            role.UpdatedAt = DateTime.Now;
            role.UpdatedId = Id;
            
            rolesContext.Insert(role);
            rolesContext.Commit();    
        }



    }
}
