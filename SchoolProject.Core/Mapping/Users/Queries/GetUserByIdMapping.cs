using SchoolProject.Core.Results;
using SchoolProject.Data.Entites.Identity;

namespace SchoolProject.Core.Mapping.Users
{
    public partial class ApplicationUserProfile
    {

        public void GetUserByIdMapping()
        {
            CreateMap<User, GetUserByIdDto>();
        }
    }
}