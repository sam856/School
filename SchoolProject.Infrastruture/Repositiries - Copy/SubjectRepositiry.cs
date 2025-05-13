using Microsoft.EntityFrameworkCore;
using
    SchoolProject.Data.Entites;
using SchoolProject.Infrastruture.Abstract;
using SchoolProject.Infrastruture.Context;
using SchoolProject.Infrastruture.InfrastrutureBases;

namespace SchoolProject.Infrastruture.Repositiries
{
    public class SubjectRepositiry : GenericRepositoryAsync<Subjects>, ISubjectRepositiry
    {
        #region Field
        public DbSet<Subjects> Subjects;

        #endregion

        #region Constractor
        public SubjectRepositiry(ApplicationDbContext dbContext) : base(dbContext)
        {
            Subjects = dbContext.Set<Subjects>();
        }
        #endregion

    }
}
