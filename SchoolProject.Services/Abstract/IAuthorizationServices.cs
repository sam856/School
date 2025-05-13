using SchoolProject.Data.Entites.Identity;
using SchoolProject.Data.Helper;
using SchoolProject.Service;
using SchoolProject.Services.Dtos;

namespace SchoolProject.Services.Abstract
{
    public interface IAuthorizationServices
    {
        public Task<string> CreateAsyc(string RoleName);
        public Task<bool> IsRoleExsist(string RoleName);
        public Task<string> EditRole(EditRoleRequest request);

        public Task<string> DeleteRole(int Id);

        public Task<List<Role>> GetAllRoles();

        public Task<Role> GetRoleById(int Id);

        public Task<ManageUserRoleDto> GetManageUserRoleData(User user);

        public Task<ManageUserCliamsDto> ManageUserCliamsData(User user);


        public Task<string> UpdateUserRoleData(UpdateUserRole user);
        public Task<string> UpdateUserCliams(UpdateUserClaimsDto updateUserClaimsDto);






    }
}