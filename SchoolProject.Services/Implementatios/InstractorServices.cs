using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using SchoolProject.Infrastruture.Abstract.Functions;
using SchoolProject.Infrastruture.Context;
using SchoolProject.Infrastruture.Repositiries;
using SchoolProject.Services.Abstract;

namespace SchoolProject.Services.Implementatios
{
    public class InstractorServices : IInstractorServices
    {
        #region Fields 
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IInsttactorFunctionRepositiry insttactorFunctionRepositiry;
        private readonly InstractorRepositiry _instractorRepositiry;
        private readonly IFileServices fileServices;
        private IHttpContextAccessor httpContextAccessor;
        #endregion
        #region Constractor
        public InstractorServices(ApplicationDbContext applicationDbContext,
            IInsttactorFunctionRepositiry insttactorFunctionRepositiry,
            InstractorRepositiry instractorRepositiry, IFileServices fileServices, IHttpContextAccessor httpContextAccessor)
        {
            this.applicationDbContext = applicationDbContext;
            this.insttactorFunctionRepositiry = insttactorFunctionRepositiry;
            _instractorRepositiry = instractorRepositiry;
            this.fileServices = fileServices;
            this.httpContextAccessor = httpContextAccessor;
        }


        #endregion


        #region Handle Function
        public async Task<decimal> GetInstractorSalary()
        {
            decimal reslt = 0;

            using (var cmd = applicationDbContext.Database.GetDbConnection().CreateCommand())
            {

                if (cmd.Connection.State != System.Data.ConnectionState.Open)
                {

                    cmd.Connection.Open();
                }

                reslt = await insttactorFunctionRepositiry.GetSalaryOfInstactor("select * from  dbo.GetInstractor()", cmd);
            }
            return (reslt);

        }




        public async Task<bool> NameIsExist(string name)
        {
            var studentRepositiry = _instractorRepositiry.GetTableNoTracking().Where(x => x.ENameAr.Equals(name)).FirstOrDefault();
            if (studentRepositiry == null) return false;
            return true;
        }

        public async Task<bool> NameIsExistExcludeSelf(string name, int id)
        {
            var studentRepositiry = await _instractorRepositiry.GetTableNoTracking().Where(x => x.ENameAr.Equals(name) && x.DID != id).FirstOrDefaultAsync();
            if (studentRepositiry == null) return false;
            return true;
        }



        public async Task<string> AddInstractor(Instructor instructor, IFormFile image)
        {
            var ImageUrl = await fileServices.UploadFile("Instructors", image);
            switch (ImageUrl)
            {

                case "CaanotUploadFile": return "CaanotUploadFile";
                case "File Not Found": return "NOImage";



            }
            instructor.Image = ImageUrl;
            try
            {


                await _instractorRepositiry.AddAsync(instructor);
                return "Success";
            }
            catch (Exception ex)
            {

                return "FailedToAdd";

            }
        }

        #endregion

    }
}
