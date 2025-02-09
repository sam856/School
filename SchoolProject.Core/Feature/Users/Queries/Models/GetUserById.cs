using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Results;

namespace SchoolProject.Core.Feature.Users.Queries.Models
{
    public class GetUserById : IRequest<Response<GetUserByIdDto>>
    {
        public int Id { get; set; }
        public GetUserById(int Id)
        {
            this.Id = Id;
        }

    }
}
