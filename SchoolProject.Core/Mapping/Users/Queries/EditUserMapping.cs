using SchoolProject.Core.Feature.Users.Commands.Models;
using SchoolProject.Data.Entites.Identity;

namespace SchoolProject.Core.Mapping.Users
{
    public partial class ApplicationUserProfile
    {
        public void EditUserMapping()
        {
            CreateMap<EditUsersCommand, User>();

        }
    }
}
