﻿using DonationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.BuisnessLogic.Interfaces
{
   public interface ITokenGenerator
    {
        Task<string> GenerateToken(AppUser appuser);
    }
}
