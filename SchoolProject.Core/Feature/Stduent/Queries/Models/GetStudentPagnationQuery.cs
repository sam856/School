using MediatR;
using SchoolProject.Core.Results;
using SchoolProject.Core.Wapper;
using SchoolProject.Data.Helper;

namespace SchoolProject.Core.Feature.Stduent.Queries.Models
{
    public class GetStudentPagnationQuery : IRequest<PaginatedResult<GetStudentPagnationDto>>
    {

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public OrderingStudentEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
