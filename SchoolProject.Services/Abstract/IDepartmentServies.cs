using SchoolProject.Data.Entites;

namespace SchoolProject.Services.Abstract
{
    public interface IDepartmentServies
    {
        public Task<Department> GetDepartmentById(int id);
    }
}
