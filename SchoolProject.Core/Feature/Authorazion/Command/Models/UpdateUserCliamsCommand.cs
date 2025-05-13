using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Services.Dtos;

namespace SchoolProject.Core.Feature.Authorazion.Command.Models
{
    public class UpdateUserCliamsCommand : UpdateUserClaimsDto, IRequest<Response<string>>
    {
    }
}
