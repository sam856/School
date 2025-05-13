using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Feature.Authrntication.Command.Models
{
    public class SendResetPasswordCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
