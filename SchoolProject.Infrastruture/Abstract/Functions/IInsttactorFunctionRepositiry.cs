using System.Data.Common;

namespace SchoolProject.Infrastruture.Abstract.Functions
{
    public interface IInsttactorFunctionRepositiry
    {
        public Task<decimal> GetSalaryOfInstactor(string query, DbCommand cmd);
    }
}
