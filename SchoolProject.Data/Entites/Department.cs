using SchoolProject.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entites

{
    public class Department : GenerLocalizableEntity
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmetSubject>();
            Instructors = new HashSet<Instructor>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DID { get; set; }
        [StringLength(100)]
        public string? DNameAr { get; set; }
        [StringLength(100)]

        public string? DNameEN { get; set; }
        public int? Manager { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<Instructor> Instructors { get; set; }
        [ForeignKey("Manager")]
        [InverseProperty("DepartmentManager")]
        public virtual Instructor? Instructor { get; set; }




    }
}
