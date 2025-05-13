using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Services.Dtos;

namespace SchoolProject.Core.Feature.Authorazion.Queries.Modling
{
    public class ManageUserCliamQuery : IRequest<Response<ManageUserCliamsDto>>
    {
        public int Id { get; set; }
        public ManageUserCliamQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
