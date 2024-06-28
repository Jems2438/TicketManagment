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
    public class HomeController : Controller
    {
        
        IUserService userService;

        public HomeController(IUserService UserService)
        {
            this.userService = UserService;
        }

        public ActionResult Index()
        {
            return View();
        } 
        
        public ActionResult CreateUser()
        {
            Users users = new Users();
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(Users users)
        {
            userService.CreateUser(users);
            return RedirectToAction("Index");
        }

    }
}