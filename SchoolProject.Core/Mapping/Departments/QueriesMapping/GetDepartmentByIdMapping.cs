using SchoolProject.Core.Results;
using SchoolProject.Data.Entites;


namespace SchoolProject.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentByIdMapping()
        {
            CreateMap<Department, GetDepartmentDto>()
            .ForMember(des => des.Name, op => op.
             MapFrom(db => db.Localize(db.DNameAr, db.DNameEN)))

            .ForMember(des => des.Id, op => op.
             MapFrom(db => db.DID))




            .ForMember(des => des.ManagerName, op => op.
             MapFrom(db => db.Instructor.Localize(db.Instructor.ENameAr, db.Instructor.ENameEn)))

             .ForMember(des => des.Subjects, op => op.
             MapFrom(db => db.DepartmentSubjects))


             .ForMember(des => des.Instractors, op => op.
             MapFrom(db => db.Instructors));




            CreateMap<DepartmetSubject, SubjectResonse>()
                 .ForMember(des => des.Id, op => op.
                 MapFrom(db => db.SubID))

                 .ForMember(des => des.Name, op => op.
                 MapFrom(db => db.Subjects.Localize(db.Subjects.SubjectNameAr, db.Subjects.SubjectNameEn)));





            CreateMap<Data.Entites.Instructor, InstractorResponse>()
                .ForMember(des => des.Id, op => op.
                MapFrom(db => db.InsId))
                .ForMember(des => des.Name, op => op.
                MapFrom(db => db.Localize(db.ENameAr, db.ENameEn)));










        }
    }
}
