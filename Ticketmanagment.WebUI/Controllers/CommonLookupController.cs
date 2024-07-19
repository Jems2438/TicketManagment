using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketManagment.Core.Contracts;
using TicketManagment.Core.Models;

namespace Ticketmanagment.WebUI.Controllers
{
    public class CommonLookupController : Controller
    {
        IRepository<CommonLookup> lookupRepository;
        ICommonLookup lookupService;


        public CommonLookupController(ICommonLookup lookupService, IRepository<CommonLookup> lookupRepository)
        {
            this.lookupRepository = lookupRepository;
            this.lookupService = lookupService;
        }
        public ActionResult Index()
        {
            var model = lookupService.GetCommonLookups();
            return View(model);
        }

        public ActionResult Create()
        {
            CommonLookup lookup = new CommonLookup();
            return View(lookup);
        }

        [HttpPost]
        public ActionResult Create(CommonLookup lookup)
        {
            if (!ModelState.IsValid)
            {
                return View(lookup);
            }
            else
            {
                lookupService.Create(lookup, User.Identity.Name);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            CommonLookup lookup = lookupRepository.Find(Id);
            if (lookup == null)
            {
                return HttpNotFound();
            }
            else
            {
                CommonLookup model = new CommonLookup();
                model = lookup;
                return PartialView("_EditCommon",model);
            }
        }

        [HttpPost]
        public ActionResult Edit(CommonLookup lookup, string Id)
        {
            CommonLookup lookupToEdit = lookupRepository.Find(Id);

            if (lookupToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(lookup);
                }
                lookupService.Editlookup(lookup, User.Identity.Name, Id);
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string Id)
        {
            CommonLookup lookupToDelete = lookupRepository.Find(Id);
            if (lookupToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(lookupToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            CommonLookup lookupToDelete = lookupRepository.Find(Id);
            if (lookupToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                lookupService.FinalDelete(Id);
                return RedirectToAction("Index");
            }
        }
    }
}