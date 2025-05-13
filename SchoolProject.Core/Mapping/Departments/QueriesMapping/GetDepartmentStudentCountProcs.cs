using SchoolProject.Core.Feature.Department.Queries.Models;
using SchoolProject.Core.Results;
using SchoolProject.Data.Entites.StoredProcudure;

namespace SchoolProject.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentStudentCountproc()
        {

            CreateMap<GetDepartmentStudentCountProcsQuery, DepartmentStudentCountProcParams>();

            CreateMap<DepartmentStudentCountProc, GetDepartmentStudentCountProcsDto>().ForMember(des => des.Name, op => op.
             MapFrom(db => db.Localize(db.DNameAr, db.DNameEn)));

        }
    }
}
