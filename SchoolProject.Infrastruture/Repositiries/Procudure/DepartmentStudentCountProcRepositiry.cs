using SchoolProject.Data.Entites.StoredProcudure;
using SchoolProject.Infrastruture.Abstract.Procudure;
using SchoolProject.Infrastruture.Context;
using StoredProcedureEFCore;

namespace SchoolProject.Infrastruture.Repositiries.Procudure
{
    public class DepartmentStudentCountProcRepositiry : IDepartmentStudentCountProcRepositiry
    {
        #region Fields 
        private readonly ApplicationDbContext _dbContext;
        #endregion
        #region Constractor
        public DepartmentStudentCountProcRepositiry(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion
        #region Handle Function
        public async Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProcsAsync(DepartmentStudentCountProcParams prams)
        {
            var rows = new List<DepartmentStudentCountProc>();

            await _dbContext.LoadStoredProc(nameof(DepartmentStudentCountProc))
                .AddParam(nameof(DepartmentStudentCountProcParams.DID), prams.DID)
                .ExecAsync(async r => rows = await r.ToListAsync<DepartmentStudentCountProc>());
            return rows;
        }
        #endregion

    }
}
