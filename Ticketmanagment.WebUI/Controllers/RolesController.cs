using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketManagment.Core.Contracts;
using TicketManagment.Core.Models;
using TicketManagment.Core.ViewModels;
using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

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
            //var result = roleService.GetRolesList();
            return View();
        }

        public JsonResult GetListOfRole([DataSourceRequest] DataSourceRequest request)
        {
            var result = roleService.GetRolesList();
            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        //public ActionResult CreateRole()
        //{
        //    //Roles roles = new Roles();
        //    return View();
        //}
         
        [HttpPost]
        public ActionResult CreateRole([DataSourceRequest] DataSourceRequest request,Roles roles)
        {
            //if(!ModelState.IsValid)
            //{
            //    //return View(roles);
            //    return Json(new[] { roles }.ToDataSourceResult(request, ModelState));
            //}
            //else
            //{
            //    roleService.CreateRole(roles, User.Identity.Name);
            //    //return RedirectToAction("Index");
            //   // return Json("GetListOfRole");

            //}
            if (ModelState.IsValid)
            {
                roleService.CreateRole(roles, User.Identity.Name);
            }
                return Json(ModelState.ToDataSourceResult(request));

        }

        //public ActionResult Edit(string Id)
        //{
        //    Roles roles = context.Find(Id);
        //    if (roles == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    else
        //    {
        //        Roles model = new Roles();
        //        model = roles;
        //        return View(model);
        //    }
        //}

        [HttpPost]
        public ActionResult Edit([DataSourceRequest] DataSourceRequest request, Roles roles, string Id)
        {
            Roles rolesToEdit = context.Find(Id);

            if (rolesToEdit == null)
            {
                return Json(null);
            }
            else
            {

                roleService.EditRole(roles, User.Identity.Name, Id);

                //return Json(new[] { roles }.ToDataSourceResult(request, ModelState));

                return Json(ModelState.ToDataSourceResult(request));
                //if (!ModelState.IsValid)
                //{
                //    return View(roles);
                //}
                //
                //return RedirectToAction("Index");
            }

        }

        //public ActionResult Delete(string Id)
        //{
        //    Roles rolesToDelete = context.Find(Id);
        //    if (rolesToDelete == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    else
        //    {
        //        return View(rolesToDelete);
        //    }
        //}

        [HttpPost]
        //[ActionName("Delete")]
        public JsonResult ConfirmDelete([DataSourceRequest] DataSourceRequest request,Roles roles, string Id)
        {
            Roles rolesToDelete = context.Find(Id);
            if (rolesToDelete == null)
            {
                return Json(null);
            }
            else
            {
                roleService.FinalDelete(Id);
                //return RedirectToAction("Index");
                return Json(ModelState.ToDataSourceResult(request));

            }

            //if (rolesToDelete != null)
            //{
            //    roleService.FinalDelete(Id);
            //}

            //return Json(new[] { roles }.ToDataSourceResult(request, ModelState));
        }

    }
}