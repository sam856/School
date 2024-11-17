using SchoolProject.Data.Entites;
using SchoolProject.Infrastruture.InfrastrutureBases;

namespace SchoolProject.Infrastruture.Abstract
{
    public interface IStudentRepositiers : IGenericRepositoryAsync<Student>
    {
        public Task<List<Student>> GetStudentsAsync();


    }
}
