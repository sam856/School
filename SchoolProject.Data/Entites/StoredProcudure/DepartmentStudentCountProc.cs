using SchoolProject.Data.Common;

namespace SchoolProject.Data.Entites.StoredProcudure
{
    public class DepartmentStudentCountProc : GenerLocalizableEntity
    {
        public int DID { get; set; }
        public string DNameAr { get; set; }
        public string DNameEn { get; set; }
        public int StudentCount { get; set; }
    }


    public class DepartmentStudentCountProcParams
    {
        public int DID { get; set; }
    }
}
