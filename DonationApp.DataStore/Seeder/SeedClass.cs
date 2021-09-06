using DonationApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.DataStore.Seeder
{
    public class SeedClass
    {
        public async static Task Seed(RoleManager<IdentityRole> roleManager, UserManager<Appuser> userManager, DonationAppDBContext donationAppDBContext)
        {
            await donationAppDBContext.Database.EnsureCreatedAsync();

            if (!donationAppDBContext.Roles.Any())
            {
                List<String> roles = new() { "Donor", "Donee", "NGO", "Admin" };

                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = role });
                }
            }
        }
    }
}
