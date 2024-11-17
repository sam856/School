using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolProject.Data.Entites;
using SchoolProject.Core.Results;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Feature.Stduent.Queries.Models
{
    public class GetStudentListQuery:IRequest<Response<List<GetStudentDto>>>
    {
    }
}
