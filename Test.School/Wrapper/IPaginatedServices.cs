using SchoolProject.Core.Wapper;

namespace Test.School.Wrapper
{
    public interface IPaginatedServices<T>
    {
        public Task<PaginatedResult<T>> ReturnPaginatedResult(IQueryable<T> source, int pageNumber, int pageSize);

    }
}
