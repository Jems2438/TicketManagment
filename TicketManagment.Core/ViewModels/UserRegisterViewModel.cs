using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagment.Core.Models;

namespace TicketManagment.Core.ViewModels
{
    public class UserRegisterViewModel : BaseEntity
    {   
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public List<string> ListOfRole { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }
}
