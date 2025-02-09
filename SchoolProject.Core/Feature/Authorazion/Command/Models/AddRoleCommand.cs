using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Feature.Authorazion.Command.Models
{
    public class AddRoleCommand : IRequest<Response<string>>
    {
        public string RoleName { get; set; }
    }
}
