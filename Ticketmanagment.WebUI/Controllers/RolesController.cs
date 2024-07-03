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

        // GET: Roles
        public ActionResult Index()
        {
            List<RoleCreateViewModel> model = roleService.GetRolesList();
            return View(model);
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
                context.Insert(roles);
                context.Commit();
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

                rolesToEdit.Name = roles.Name;
                rolesToEdit.Code = roles.Code;
                context.Commit();

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
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");

            }

        }

    }
}