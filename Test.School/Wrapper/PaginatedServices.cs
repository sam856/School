using SchoolProject.Core.Wapper;
using SchoolProject.Data.Entites;

namespace Test.School.Wrapper
{
    public class PaginatedServices : IPaginatedServices<Student>
    {
        public async Task<PaginatedResult<Student>> ReturnPaginatedResult(IQueryable<Student> source, int pageNumber, int pageSize)
        {
            return await source.ToPaginatedListAsync(pageNumber, pageSize);
        }


    }
}
