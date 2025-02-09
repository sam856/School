using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites.Identity;

namespace SchoolProject.Infrastruture.DataSeeder
{
    public static class UserSeeder
    {
        public static async Task SeedingUser(UserManager<User> userManager)
        {
            var userCount = await userManager.Users.CountAsync();
            if (userCount <= 0)
            {
                var defualtuser = new User
                {
                    PhoneNumber = "02020",
                    PhoneNumberConfirmed = true,
                    Email = "Menna@gmail.com",
                    EmailConfirmed = true,
                    UserName = "Menna",
                    FullName = "Menna123@mohammed",
                    Country = "Elmarg",
                    Address = "ESLAS"



                };
                await userManager.CreateAsync(defualtuser, "Menna123@");
                await userManager.AddToRoleAsync(defualtuser, "Admin");
            }
        }
    }
}

