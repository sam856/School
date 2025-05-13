using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Feature.Instractor.Query.Model
{
    public class GetInstractorSalaryQuery : IRequest<Response<decimal>>
    {
    }
}
