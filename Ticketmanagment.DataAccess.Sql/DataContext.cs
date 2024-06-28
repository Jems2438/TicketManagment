using TicketManagment.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ticketmanagment.DataAccess.Sql
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection") { 
        
        }

        public DbSet<Users> User { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Roles> Role { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

    }
}
