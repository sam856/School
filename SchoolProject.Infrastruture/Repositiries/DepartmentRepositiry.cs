using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using SchoolProject.Infrastruture.Abstract;
using SchoolProject.Infrastruture.Context;
using SchoolProject.Infrastruture.InfrastrutureBases;

namespace SchoolProject.Infrastruture.Repositiries
{
    public class DepartmentRepositiry : GenericRepositoryAsync<Department>, IDepartmentRepositiry
    {

        #region Field
        private DbSet<Department> departmentSet;
        #endregion
        #region Constractor
        public DepartmentRepositiry(ApplicationDbContext dbContext) : base(dbContext)
        {
            departmentSet = dbContext.Set<Department>();
        }
        #endregion

        #region  Handel Function
        #endregion
    }
}
