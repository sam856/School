using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Data.Helper;
using SchoolProject.Service;
using SchoolProject.Services.Abstract;

namespace SchoolProject.Services.Implementatios
{

    public class AuzorizationServices : IAuthorizationServices
    {
        #region Fields
        private readonly RoleManager<Role> roleManager;
        private readonly UserManager<User> userManager;

        #endregion


        #region Constractor
        public AuzorizationServices(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
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
                if (userRoles.Contains(role.Name))
                    userrole.HasRole = true;

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
        #endregion
    }
}
