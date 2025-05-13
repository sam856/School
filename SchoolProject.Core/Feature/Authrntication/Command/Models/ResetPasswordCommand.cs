using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Feature.Authrntication.Command.Models
{
    public class ResetPasswordCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
    }
}
