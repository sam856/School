using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Results;


namespace SchoolProject.Core.Feature.Department.Queries.Models
{
    public class GetDepartmentById : IRequest<Response<GetDepartmentDto>>
    {
        public int Id { get; set; }
        public int StudentPageSize { get; set; }
        public int StudentPageNumber { get; set; }

    }
}
