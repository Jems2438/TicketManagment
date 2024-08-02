﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagment.Core.Models;

namespace TicketManagment.Core.ViewModels
{
    public class RoleListViewModel
    {
        [ScaffoldColumn(false)]
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime?  CreatedAt { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
