using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Infrastruture.Context;
using SchoolProject.Services.Abstract;


namespace SchoolProject.Services.Implementatios
{
    public class UserServices : IUserServices
    {
        #region Fields
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IEmailServices emailServices;
        private readonly UserManager<User> userManager;
        private readonly ApplicationDbContext applicationDbContext;


        #endregion
        #region Constractor
        public UserServices(IHttpContextAccessor httpContextAccessor, IEmailServices emailServices,
            UserManager<User> userManager,
            ApplicationDbContext applicationDbContext)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.emailServices = emailServices;
            this.userManager = userManager;
            this.applicationDbContext = applicationDbContext;
        }
        #endregion
        #region Handle Function
        public async Task<string> AddUserAsync(User user, string password)
        {
            var transt = await applicationDbContext.Database.BeginTransactionAsync();
            try
            {

                var Existuser = await userManager.FindByEmailAsync(user.Email);
                if (Existuser != null)
                {
                    return "EmailIsExist";
                }

                var UserName = await userManager.FindByNameAsync(user.UserName);


                if (UserName != null)
                {
                    return "UserNameIsExist";

                }


                var result = await userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                {
                    return string.Join(",", result.Errors.Select(x => x.Description).ToList());

                }
                await userManager.AddToRoleAsync(user, "User");

                var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                var resultAccessor = httpContextAccessor.HttpContext.Request;
                var LinkUrl = resultAccessor.Scheme + "://" + resultAccessor.Host + $"/api/Authentication/Api/V1/Authentication/ConfirmEmail?userId={user.Id}&code={code}";
                var message = $"To Cofirm Email Click : <a href='{LinkUrl}'></a>";
                await emailServices.SendEmailAsync(user.Email, message, "Confirm Email");




                await transt.CommitAsync();
                return "Success";


            }
            catch (Exception ex)
            {
                transt.Rollback();
                return "Failed";
            }
        }
        #endregion
    }
}
