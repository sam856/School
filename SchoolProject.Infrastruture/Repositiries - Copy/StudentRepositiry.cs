using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using SchoolProject.Infrastruture.Abstract;
using SchoolProject.Infrastruture.Context;
using SchoolProject.Infrastruture.InfrastrutureBases;

namespace SchoolProject.Infrastruture.Repositiries
{
    public class StudentRepositiry : GenericRepositoryAsync<Student>, IStudentRepositiers
    {
        #region Fields
        private readonly DbSet<Student> students;

        #endregion

        #region Contrators
        public StudentRepositiry(ApplicationDbContext dbContext) : base(dbContext)
        {
            students = dbContext.Set<Student>();
        }


        #endregion

        #region Handel Functions

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await students.Include(d => d.Department).ToListAsync();
        }




        #endregion
    }


}
