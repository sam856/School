using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites.Veiws;
using SchoolProject.Infrastruture.Abstract.IViews;
using SchoolProject.Infrastruture.Context;
using SchoolProject.Infrastruture.InfrastrutureBases;

namespace SchoolProject.Infrastruture.Repositiries
{
    public class ViewDepartmentRepositiry : GenericRepositoryAsync<VeiwDepartment>, IViewsRepositiry<VeiwDepartment>
    {
        #region Fields
        private readonly DbSet<VeiwDepartment> _dbSet;

        #endregion



        #region Constractor
        public ViewDepartmentRepositiry(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbSet = dbContext.Set<VeiwDepartment>();
        }
        #endregion



        #region Handle Function
        #endregion
    }
}
