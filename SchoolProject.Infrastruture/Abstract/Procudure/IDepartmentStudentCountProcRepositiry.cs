using SchoolProject.Data.Entites.StoredProcudure;

namespace SchoolProject.Infrastruture.Abstract.Procudure
{
    public interface IDepartmentStudentCountProcRepositiry
    {
        Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProcsAsync(DepartmentStudentCountProcParams prams);
    }
}
