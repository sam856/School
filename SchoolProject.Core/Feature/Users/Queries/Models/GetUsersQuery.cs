using MediatR;
using SchoolProject.Core.Results;
using SchoolProject.Core.Wapper;

namespace SchoolProject.Core.Feature.Users.Queries.Models
{
    public class GetUsersQuery : IRequest<PaginatedResult<GetUsersDto>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
