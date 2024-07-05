using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketManagment.Core.Contracts;
using TicketManagment.Core.Models;
using TicketManagment.Core.ViewModels;

namespace Ticketmanagment.WebUI.Controllers
{
    public class RolesController : Controller
    {
        IRepository<Roles> context;
        IRoleService roleService;

        public RolesController(IRepository<Roles> Context, IRoleService RoleService)
        {
            this.context = Context;
            this.roleService = RoleService;          
        }
    
        public ActionResult Index()
        { 
            var result = roleService.GetRolesList();
            return View(result);
        }

        public ActionResult CreateRole()
        {
            Roles roles = new Roles();
            return View(roles);
        }
         
        [HttpPost]
        public ActionResult CreateRole(Roles roles)
        {
            if(!ModelState.IsValid)
            {
                return View(roles);
            }
            else
            {
                roleService.CreateRole(roles, User.Identity.Name);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Roles roles = context.Find(Id);
            if (roles == null)
            {
                return HttpNotFound();
            }
            else
            {
                Roles model = new Roles();
                model = roles;
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(Roles roles, string Id)
        {
            Roles rolesToEdit = context.Find(Id);

            if (rolesToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(roles);
                }
                roleService.EditRole(roles, User.Identity.Name, Id);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            Roles rolesToDelete = context.Find(Id);
            if (rolesToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(rolesToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Roles rolesToDelete = context.Find(Id);
            if (rolesToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                roleService.FinalDelete(Id);
                return RedirectToAction("Index");
            }
        }

    }
}