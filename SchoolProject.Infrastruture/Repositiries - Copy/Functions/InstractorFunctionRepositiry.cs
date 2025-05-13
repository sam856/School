using SchoolProject.Data.Dto;
using SchoolProject.Infrastruture.Abstract.Functions;
using StoredProcedureEFCore;
using System.Data.Common;

namespace SchoolProject.Infrastruture.Repositiries.Functions
{
    public class InstractorFunctionRepositiry : IInsttactorFunctionRepositiry
    {
        #region Fields
        #endregion
        #region Constractor
        #endregion
        #region Handle Function 
        public async Task<decimal> GetSalaryOfInstactor(string query, DbCommand cmd)
        {
            decimal response = 0;
            cmd.CommandText = query;
            var value = await cmd.ExecuteReaderAsync();
            var rs = await value.ToListAsync<GetFunctionResult>();
            var result = value.ToString();
            if (decimal.TryParse(result, out decimal d))
            {
                response = d;
            }

            return response;


        }
        #endregion

    }
}
