using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Results;

namespace SchoolProject.Core.Feature.Authorazion.Queries.Modling
{
    public class GetRoleByIdCommand : IRequest<Response<GetRoleByIdDto>>
    {
        public int Id { get; set; }
        public GetRoleByIdCommand(int Id)
        {
            this.Id = Id;
        }
    }
}
