﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DonationApp.DataStore
{
   public class DonationAppDBContext : IdentityDbContext<AppUser> 
    {
        public DonationAppDBContext(DbContextOptions<DonationAppDBContext> options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Donee> Donees { get; set; }
        public DbSet<NGO> NGOs { get; set; }
        public DbSet<Donor> Donors { get; set; }
    }
}