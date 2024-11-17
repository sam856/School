using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using SchoolProject.Infrastruture.Abstract;
using SchoolProject.Services.Abstract;

namespace SchoolProject.Services.Implementatios
{
    public class DepartmentServices : IDepartmentServies
    {

        #region Fields
        private readonly IDepartmentRepositiry departmentRepositiry;
        #endregion


        #region Constractor
        public DepartmentServices(IDepartmentRepositiry departmentRepositiry)
        {
            this.departmentRepositiry = departmentRepositiry;

        }
        public DepartmentServices()
        {

        }

        #endregion


        #region Handle Function

        public async Task<Department> GetDepartmentById(int id)
        {
            var Departmentstudent = await departmentRepositiry.GetTableNoTracking().Where(x => x.DID == id)
                  .Include(x => x.Instructors)
                  .Include(x => x.DepartmentSubjects).ThenInclude(x => x.Subjects)
                .Include(x => x.Instructor).FirstOrDefaultAsync();


            return Departmentstudent;

        }
        #endregion

    }
}
