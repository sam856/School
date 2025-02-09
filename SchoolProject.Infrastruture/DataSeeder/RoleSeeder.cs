using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites.Identity;

namespace SchoolProject.Infrastruture.DataSeeder
{

    public static class RoleSeeder
    {
        public static async Task SeedingUser(RoleManager<Role> userManager)
        {
            var userCount = await userManager.Roles.CountAsync();
            if (userCount <= 0)
            {
                var defualtuser = new Role
                {
                    Name = "Admin"



                };

                var defualtuserRole = new Role
                {
                    Name = "User"



                };
                await userManager.CreateAsync(defualtuser);
                await userManager.CreateAsync(defualtuserRole);

            }
        }
    }
}
