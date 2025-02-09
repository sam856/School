using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Feature.Users.Commands.Models
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteUserCommand(int Id)
        {
            this.Id = Id;
        }
    }
}
