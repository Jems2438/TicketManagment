using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagment.Core.Models;
using TicketManagment.Core.ViewModels;

namespace TicketManagment.Core.Contracts
{
    public interface IRoleService  
    {
        List<RoleCreateViewModel> GetRolesList();
        void CreateRole(Roles role,string Id);
    }
}
