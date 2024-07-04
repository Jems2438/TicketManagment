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
        List<RoleListViewModel> GetRolesList();
        void CreateRole(Roles role,string emailId);
        void EditRole(Roles role, string Id,string roleToEdit);
        void FinalDelete(string Id);
    }
}
