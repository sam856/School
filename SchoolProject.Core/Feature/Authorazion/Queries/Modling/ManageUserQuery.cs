using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Service;

namespace SchoolProject.Core.Feature.Authorazion.Queries.Modling
{
    public class ManageUserQuery : IRequest<Response<ManageUserRoleDto>>
    {
        public int Id { get; set; }
        public ManageUserQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
