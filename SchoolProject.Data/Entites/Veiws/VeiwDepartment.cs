using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Common;

namespace SchoolProject.Data.Entites.Veiws
{
    [Keyless]
    public class VeiwDepartment : GenerLocalizableEntity
    {
        public int DID { get; set; }
        public string DNameAr { get; set; }
        public string DNameEn { get; set; }
        public int StudentAccount { get; set; }
    }
}
