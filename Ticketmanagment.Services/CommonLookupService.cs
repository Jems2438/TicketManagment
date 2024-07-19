using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagment.Core.Contracts;
using TicketManagment.Core.Models;

namespace Ticketmanagment.Services
{
    public class CommonLookupService : ICommonLookup
    {
        IRepository<CommonLookup> lookupRepository;
        IRepository<Users> userContext;
        public CommonLookupService(IRepository<CommonLookup> lookupRepository, IRepository<Users> userContext)
        {
            this.lookupRepository = lookupRepository;
            this.userContext = userContext;
        }

        public List<CommonLookup> GetCommonLookups()
        {
            var model = lookupRepository.Collection().ToList();
            var result = (from p in model
                         select new CommonLookup()
                         {
                                Id = p.Id, 
                                CreatedAt = p.CreatedAt.Date,
                                CreatedBy = userContext.Collection().Where(x => x.Id == p.CreatedBy )
                                                    .Select(x => x.UserName).FirstOrDefault(),
                                UpdatedAt = p.UpdatedAt,
                                UpdatedId = userContext.Collection().Where(x => x.Id == p.UpdatedId)
                                                    .Select(x => x.UserName).FirstOrDefault(),
                                LookupKey = p.LookupKey,
                                LookupName = p.LookupName,
                                LookupValue = p.LookupValue,
                                OrderNumber = p.OrderNumber,
                                Description = p.Description

                         }).ToList();
            return result;
        }

        public void Create(CommonLookup model, string UserId)
        {
            var users = userContext.Collection().FirstOrDefault(x => x.Email == UserId);

            model.UpdatedAt = DateTime.Now;
            model.CreatedBy = users.Id;
            lookupRepository.Insert(model);
            lookupRepository.Commit();
        }

        public void Editlookup(CommonLookup lookup, string emailid, string Id)
        {
            CommonLookup lookupEdit = lookupRepository.Find(Id);
            var users = userContext.Collection().FirstOrDefault(x => x.Email == emailid);

            lookupEdit.LookupValue = lookup.LookupValue;
            lookupEdit.OrderNumber = lookup.OrderNumber;
            lookupEdit.Description = lookup.Description;
            lookupEdit.UpdatedId = users.Id;
            lookupEdit.UpdatedAt = DateTime.Now;

            lookupRepository.Commit();
        }
        public void FinalDelete(string Id)
        {
            lookupRepository.Delete(Id);
            lookupRepository.Commit();
        }
    }
}
