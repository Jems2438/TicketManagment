using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketManagment.Core.Contracts;
using TicketManagment.Core.Models;

namespace Ticketmanagment.WebUI.Controllers
{
    [Authorize (Roles = "Admin")]
    public class AdminController : Controller
    {
        IRepository<Users> context;

        public AdminController(IRepository<Users> context)
        {
            this.context = context;
        }
        // GET: Admin
        public ActionResult Index()
        {
            List<Users> users = context.Collection().ToList();
            return View(users);
        }
       
    }
}