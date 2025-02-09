using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Results;

namespace SchoolProject.Core.Feature.Authorazion.Queries.Modling
{
    public class GetRolesListCommand : IRequest<Response<List<GetRolesListDto>>>
    {
    }
}
