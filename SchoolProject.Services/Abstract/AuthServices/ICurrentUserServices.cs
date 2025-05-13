using SchoolProject.Data.Entites.Identity;

namespace SchoolProject.Services.Abstract.AuthServices
{
    public interface ICurrentUserServices
    {
        public int GetUserId();
        public Task<User> GetUser();
        public Task<List<string>> GetUserRoleAsync();
    }
}
