using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SchoolProject.Services.Abstract;

namespace SchoolProject.Services.Implementatios
{
    public class FileServices : IFileServices
    {
        #region Fields 
        private IWebHostEnvironment webHostEnvironment;
        #endregion


        #region Constractor
        public FileServices(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }


        #endregion

        #region Handle Function
        public async Task<string> UploadFile(string Location, IFormFile file)
        {
            var path = webHostEnvironment.WebRootPath + "/" + Location + "/";
            var extenction = Path.GetExtension(file.FileName);
            var filename = Guid.NewGuid().ToString().Replace("-", string.Empty);

            if (file.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(path))
                    {

                        Directory.CreateDirectory(path);
                    }

                    using (FileStream fileStream = File.Create(path + filename))
                    {

                        await file.CopyToAsync(fileStream);
                        await fileStream.FlushAsync();
                        return $"{Location}/{filename}";
                    }
                }

                catch (Exception ex)
                {

                    return "CaanotUploadFile";

                }
            }
            else
            {
                return "File Not Found";
            }

        }
        #endregion

    }
}
