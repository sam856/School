using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Data.Helper;

namespace SchoolProject.Core.Feature.Authrntication.Command.Models
{
    public class RefreshTokenCommand : IRequest<Response<JWTAuthResult>>
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}

