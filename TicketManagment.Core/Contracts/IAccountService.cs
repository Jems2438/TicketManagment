using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagment.Core.ViewModels;

namespace TicketManagment.Core.Contracts
{
    public interface IAccountService
    {
        void Registration(UserRegisterViewModel model, string UserId);
    }
}
