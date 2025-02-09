using SchoolProject.Core.Results;
using SchoolProject.Data.Entites.Identity;

namespace SchoolProject.Core.Mapping.Roles
{
    public partial class RoleProfile
    {
        public void RoleMapping()
        {
            CreateMap<Role, GetRolesListDto>();
        }

    }
}
