using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using SchoolProject.Infrastruture.Abstract;
using SchoolProject.Infrastruture.Context;
using SchoolProject.Infrastruture.InfrastrutureBases;

namespace SchoolProject.Infrastruture.Repositiries
{
    public class InstractorRepositiry : GenericRepositoryAsync<Instructor>, IInstractorRepositiry
    {

        #region Fields
        public DbSet<Instructor> Instructors;
        #endregion

        #region Constractor
        public InstractorRepositiry(ApplicationDbContext dbContext) : base(dbContext)
        {
            Instructors = dbContext.Set<Instructor>();
        }
        #endregion


    }
}
