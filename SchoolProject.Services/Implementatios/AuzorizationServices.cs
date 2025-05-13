using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Data.Helper;
using SchoolProject.Infrastruture.Context;
using SchoolProject.Service;
using SchoolProject.Services.Abstract;
using SchoolProject.Services.Dtos;
using System.Data;
using System.Security.Claims;

namespace SchoolProject.Services.Implementatios
{

    public class AuzorizationServices : IAuthorizationServices
    {
        #region Fields
        private readonly RoleManager<Role> roleManager;
        private readonly UserManager<User> userManager;
        private readonly ApplicationDbContext _dbContext;

        #endregion


        #region Constractor
        public AuzorizationServices(RoleManager<Role> roleManager, UserManager<User> userManager, ApplicationDbContext _dbContext)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this._dbContext = _dbContext;
        }


        #endregion


        #region Handle Function
        public async Task<string> CreateAsyc(string RoleName)
        {
            var identityRole = new Role();
            identityRole.Name = RoleName;
            var result = await roleManager.CreateAsync(identityRole);
            if (result.Succeeded)
            {
                return "Success";

            }
            return "Failed";


        }

        public async Task<string> DeleteRole(int roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId.ToString());
            if (role == null) return "NotFound";
            var users = await userManager.GetUsersInRoleAsync(role.Name);
            if (users != null && users.Count() > 0) return "Used";
            var result = await roleManager.DeleteAsync(role);
            if (result.Succeeded) return "Success";
            var errors = string.Join("-", result.Errors);
            return errors;
        }

        public async Task<string> EditRole(EditRoleRequest request)
        {
            var role = await roleManager.FindByIdAsync(request.Id.ToString());
            if (role == null)
                return "NotFound";
            role.Name = request.Name;
            var result = await roleManager.UpdateAsync(role);
            if (result.Succeeded)
                return "Success";
            var error = string.Join("-", result.Errors);
            return error;
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await roleManager.Roles.ToListAsync();
        }

        public async Task<ManageUserRoleDto> GetManageUserRoleData(User user)
        {
            var reponse = new ManageUserRoleDto();
            var userRoles = await userManager.GetRolesAsync(user);
            var roles = await roleManager.Roles.ToListAsync();

            var roleData = new List<UserRoles>();
            reponse.UserId = user.Id;
            foreach (var role in roles)
            {
                var userrole = new UserRoles();
                userrole.Name = role.Name;
                userrole.Id = role.Id;
                if (await userManager.IsInRoleAsync(user, role.Name))
                    userrole.HasRole = true;
                else
                    userrole.HasRole = false;


                roleData.Add(userrole);

            }
            reponse.UserRole = roleData;
            return reponse;
        }

        public async Task<Role> GetRoleById(int Id)
        {
            return await roleManager.FindByIdAsync(Id.ToString());
        }

        public async Task<bool> IsRoleExsist(string RoleName)
        {
            return await roleManager.RoleExistsAsync(RoleName);
        }

        public async Task<ManageUserCliamsDto> ManageUserCliamsData(User user)
        {
            var reponse = new ManageUserCliamsDto();
            var UserCliamsList = await userManager.GetClaimsAsync(user);
            reponse.UserId = user.Id;
            var usercliams = new List<UserCliams>();
            reponse.UserId = user.Id;
            foreach (var claim in ClaimsStore.claims)
            {
                var usercliam = new UserCliams();
                usercliam.Type = claim.Type;
                if (UserCliamsList.Any(x => x.Type == claim.Type))
                    usercliam.Value = true;
                else
                    usercliam.Value = false;


                usercliams.Add(usercliam);

            }
            reponse.userCliam = usercliams;
            return reponse;
        }

        public async Task<string> UpdateUserCliams(UpdateUserClaimsDto updateUserClaimsDto)
        {
            var transact = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var user = await userManager.FindByIdAsync(updateUserClaimsDto.UserId.ToString());
                if (user == null)
                    return "UserIsNull";
                var UserCliams = await userManager.GetClaimsAsync(user);
                var removeClaims = await userManager.RemoveClaimsAsync(user, UserCliams);
                if (!removeClaims.Succeeded)
                    return "FailedToRemoveOldClaims";

                var cliams = updateUserClaimsDto.userCliam.Where(x => x.Value == true).Select(x => new Claim(x.Type, x.Value.ToString()));
                var result = await userManager.AddClaimsAsync(user, cliams);
                if (!result.Succeeded)
                    return "FailedToAddNewClaims";
                return "Success";

                await transact.CommitAsync();

            }
            catch (Exception ex)
            {

                await transact.RollbackAsync();
                return "FailedToUpdateClaims";

            }
        }

        public async Task<string> UpdateUserRoleData(UpdateUserRole request)
        {
            var transact = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                //Get User
                var user = await userManager.FindByIdAsync(request.UserId.ToString());
                if (user == null)
                {
                    return "UserIsNull";
                }
                //get user Old Roles
                var userRoles = await userManager.GetRolesAsync(user);
                //Delete OldRoles
                var removeResult = await userManager.RemoveFromRolesAsync(user, userRoles);
                if (!removeResult.Succeeded)
                    return "FailedToRemoveOldRoles";
                var selectedRoles = request.UserRole.Where(x => x.HasRole == true).Select(x => x.Name);

                //Add the Roles HasRole=True
                var addRolesresult = await userManager.AddToRolesAsync(user, selectedRoles);
                if (!addRolesresult.Succeeded)
                    return "FailedToAddNewRoles";
                await transact.CommitAsync();
                //return Result
                return "Success";
            }
            catch (Exception ex)
            {
                await transact.RollbackAsync();
                return "FailedToUpdateUserRoles";
            }

        }
        #endregion
    }
}
