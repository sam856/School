﻿using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Feature.Stduent.Commands.Models
{
    public class EditStudentCommand : IRequest<Response<string>>
    {
        public int StudID { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }


        public string Address { get; set; }
        public string? Phone { get; set; }
        public int DiD { get; set; }
    }
}
