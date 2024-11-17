using SchoolProject.Data.Entites;
using SchoolProject.Data.Helper;

namespace SchoolProject.Services.Abstract
{
    public interface IStudentServies
    {
        public Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentByIDWithIncludeAsync(int id);
        public Task<string> AddStudent(Student student);
        public Task<bool> NameIsExist(string name);
        public Task<bool> NameIsExistExcludeSelf(string name, int id);
        public Task<string> EditAsync(Student student);
        public Task<string> DeleteAsync(Student student);
        public IQueryable<Student> GetAllStudents();

        public IQueryable<Student> GetStudentByDepartment(int id);


        public IQueryable<Student> FilterStudentIqurable(OrderingStudentEnum studentEnum, string search);
    }
}
