﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagment.Core.Models;

namespace TicketManagment.Core.Contracts
{
    public interface IUserService
    {
        void CreateUser(Users userdata);
    }
}