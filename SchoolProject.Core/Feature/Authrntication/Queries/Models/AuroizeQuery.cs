using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Feature.Authrntication.Queries.Models
{
    public class AuroizeQuery : IRequest<Response<string>>
    {
        public string AccessToken { get; set; }
    }
}
