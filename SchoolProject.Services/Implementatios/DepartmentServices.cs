using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using SchoolProject.Data.Entites.StoredProcudure;
using SchoolProject.Data.Entites.Veiws;
using SchoolProject.Infrastruture.Abstract;
using SchoolProject.Infrastruture.Abstract.IViews;
using SchoolProject.Infrastruture.Abstract.Procudure;
using SchoolProject.Services.Abstract;

namespace SchoolProject.Services.Implementatios
{
    public class DepartmentServices : IDepartmentServies
    {

        #region Fields
        private readonly IDepartmentRepositiry departmentRepositiry;
        private readonly IViewsRepositiry<VeiwDepartment> viewsRepositiry;
        private readonly IDepartmentStudentCountProcRepositiry procRepositiry;
        #endregion


        #region Constractor
        public DepartmentServices(IDepartmentRepositiry departmentRepositiry, IViewsRepositiry<VeiwDepartment> viewsRepositiry, IDepartmentStudentCountProcRepositiry procRepositiry)
        {
            this.departmentRepositiry = departmentRepositiry;
            this.viewsRepositiry = viewsRepositiry;
            this.procRepositiry = procRepositiry;

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

        public async Task<bool> DepartmentIsExist(int id)
        {
            var Departmentstudent = await departmentRepositiry
                .GetTableNoTracking().Where(x => x.DID.Equals(id)).FirstOrDefaultAsync();

            if (Departmentstudent == null)
                return false;
            return true;
        }

        public Task<List<VeiwDepartment>> GetVeiwDepartmentStudentCount()
        {
            var VeiwDepartment = viewsRepositiry.GetTableNoTracking().ToListAsync();
            return VeiwDepartment;
        }

        public async Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProcsAsync(DepartmentStudentCountProcParams prams)
        {
            return await procRepositiry.GetDepartmentStudentCountProcsAsync(prams);
        }
        #endregion

    }
}
