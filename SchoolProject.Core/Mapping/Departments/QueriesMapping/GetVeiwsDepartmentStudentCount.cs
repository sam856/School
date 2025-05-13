using SchoolProject.Core.Results;
using SchoolProject.Data.Entites.Veiws;

namespace SchoolProject.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void GetVeiwDepartment()
        {


            CreateMap<VeiwDepartment, GetDepartmentbyStudentCountDto>()
            .ForMember(des => des.Name, op => op.
             MapFrom(db => db.Localize(db.DNameAr, db.DNameEn)))

            .ForMember(des => des.StudentCount, op => op.
             MapFrom(db => db.StudentAccount));
        }
    }
}
