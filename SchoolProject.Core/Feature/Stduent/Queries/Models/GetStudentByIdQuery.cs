using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Feature.Stduent.Queries.Models
{
    public class GetStudentByIdQuery:IRequest<Response<GetStudentDto>>
    {
        public int Id { get; set; }
        public GetStudentByIdQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
