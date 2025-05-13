using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Feature.Emails.Command.Models
{
    public class SendEmailCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
