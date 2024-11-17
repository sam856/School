using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Feature.Stduent.Commands.Models
{
    public class DeleteStudentCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteStudentCommand(int Id)
        {
            this.Id = Id;
        }
    }
}
