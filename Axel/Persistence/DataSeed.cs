using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class DataSeed
    {

        public static async Task Seed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration config)
        {
            
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("superuser") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("superuser"));
            }
            if (await userManager.FindByNameAsync(config["Admin:Email"]) == null)
            {
                var admin = new IdentityUser { Email = config["Admin:Email"], UserName = config["Admin:Email"] };
                var result = await userManager.CreateAsync(admin, config["Admin:Password"]);
                
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }

            if (await userManager.FindByNameAsync(config["Superuser:Email"]) == null)
            {
                var superuser = new IdentityUser { Email = config["Superuser:Email"], UserName = config["Superuser:Email"] };
                var result = await userManager.CreateAsync(superuser, config["Superuser:Password"]);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(superuser, "superuser");
                }
            }

            //modelBuilder.Entity<IdentityUser>().HasData(
            //        new IdentityUser
            //        {

            //        },

            //        new IdentityUser
            //        {

            //        }

            //    );
        }
    }
}
