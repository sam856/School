using SchoolProject.Data.Entites.Identity;

namespace SchoolProject.Services.Abstract
{
    public interface IUserServices
    {
        public Task<string> AddUserAsync(User user, string password);
    }
}
