using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Feature.Emails.Query.Model
{
    public class ConfirmEmailQuery : IRequest<Response<string>>
    {
        public string code { get; set; }
        public int userId { get; set; }
    }
}
