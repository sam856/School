using AutoMapper;
using SchoolProject.Core.Feature.Stduent.Commands.Models;
using SchoolProject.Core.Results;

namespace SchoolProject.Core.Mapping.Student
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<SchoolProject.Data.Entites.Student, GetStudentDto>()
                .ForMember(des => des.DepartmentName, op => op.MapFrom(db => db.Localize(db.Department.DNameAr, db.Department.DNameEN)))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));



            CreateMap<AddStudentCommand, Data.Entites.Student>()
          .ForMember(des => des.DID, op => op.MapFrom(src => src.DiD))
           .ForMember(des => des.NameAr, op => op.MapFrom(src => src.NameAr))
           .ForMember(des => des.NameEn, op => op.MapFrom(src => src.NameEn));



            CreateMap<EditStudentCommand, Data.Entites.Student>()
         .ForMember(des => des.DID, op => op.MapFrom(src => src.DiD))
         .ForMember(des => des.StudID, op => op.MapFrom(src => src.StudID))
          .ForMember(des => des.NameAr, op => op.MapFrom(src => src.NameAr))
           .ForMember(des => des.NameEn, op => op.MapFrom(src => src.NameEn));

        }
    }
}
