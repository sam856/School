using SchoolProject.Data.Entites;
using SchoolProject.Data.Entites.StoredProcudure;
using SchoolProject.Data.Entites.Veiws;

namespace SchoolProject.Services.Abstract
{
    public interface IDepartmentServies
    {
        public Task<Department> GetDepartmentById(int id);

        public Task<bool> DepartmentIsExist(int id);

        public Task<List<VeiwDepartment>> GetVeiwDepartmentStudentCount();
        public Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProcsAsync(DepartmentStudentCountProcParams prams);
    }
}
