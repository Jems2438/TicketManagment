using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagment.Core.Models;

namespace TicketManagment.Core.Contracts
{
    public interface ICommonLookup
    {
        List<CommonLookup> GetCommonLookups();
        void Create(CommonLookup model, string UserId);
        void Editlookup(CommonLookup lookup, string emailid, string Id);
        void FinalDelete(string Id);
    }
}
