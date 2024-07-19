using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketManagment.Core.Contracts;
using TicketManagment.Core.Models;

namespace Ticketmanagment.WebUI.Controllers
{
    public class UserListsController : Controller
    {
        IRepository<Users> context;
        IUserService userService;
        IRepository<Roles> roleContext;

        public UserListsController(IRepository<Users> context, IUserService UserService, IRepository<Roles> roleContext)
        {
            this.context = context;
            this.userService = UserService;
            this.roleContext = roleContext;
        }
        // GET: UserList
        public ActionResult UserList()
        {
            var model = userService.GetUserList();
            return View(model);
        }

        public ActionResult Edit(string Id)
        {
            Users users = context.Find(Id);
            if (users == null)
            {
                return HttpNotFound();
            }
            else
            {
                Users model = new Users();
                var roledata = roleContext.Collection().Select(x => x.Code).ToList();
                ViewBag.ListOfRole = roledata;
                model.ListOfRole = roledata;
                model = users; 
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(Users users , string Id)
        {
            Users usersToEdit = context.Find(Id);
            
            if (usersToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(users);
                }
                userService.EditUser(users, User.Identity.Name, Id);
                return RedirectToAction("UserList");
            }
        }

        public ActionResult Delete(string Id)
        {
            Users usersToDelete = context.Find(Id);
            if (usersToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(usersToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Users usersToDelete = context.Find(Id);
            if (usersToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("UserList");
            }
        }
    }
}