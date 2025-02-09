using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Data.Helper;

namespace SchoolProject.Core.Feature.Authrntication.Command.Models
{
    public class SigInCommand : IRequest<Response<JWTAuthResult>>
    {
        public string UserName { get; set; }

        public string Password { get; set; }

    }
}
