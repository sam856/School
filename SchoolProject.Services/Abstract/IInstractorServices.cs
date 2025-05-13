using Microsoft.AspNetCore.Http;
using SchoolProject.Data.Entites;

namespace SchoolProject.Services.Abstract
{
    public interface IInstractorServices
    {
        public Task<decimal> GetInstractorSalary();
        public Task<bool> NameIsExist(string name);
        public Task<bool> NameIsExistExcludeSelf(string name, int id);
        public Task<string> AddInstractor(Instructor instructor, IFormFile image);
    }
}
