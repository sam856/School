using Microsoft.AspNetCore.Http;

namespace SchoolProject.Services.Abstract
{
    public interface IFileServices
    {
        public Task<string> UploadFile(string Location, IFormFile image);
    }
}
