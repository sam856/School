using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Results;

namespace SchoolProject.Core.Feature.Department.Queries.Models
{
    public class GetDepartmentbyStudentCount : IRequest<Response<List<GetDepartmentbyStudentCountDto>>>
    {

    }
}
