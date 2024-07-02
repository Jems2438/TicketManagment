using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticketmanagment.Services;
using TicketManagment.Core.Contracts;
using TicketManagment.Core.Models;
using TicketManagment.Core.ViewModels;

namespace Ticketmanagment.WebUI.Controllers
{
    [Authorize (Roles = "Admin")]
    public class AdminController : Controller
    {
        IRepository<Users> context;
        IUserService userService;

        public AdminController(IRepository<Users> context, IUserService UserService)
        {
            this.context = context;
            this.userService = UserService;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}