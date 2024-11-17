using SchoolProject.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entites
{
    public class Instructor : GenerLocalizableEntity
    {
        public Instructor()
        {
            Instructors = new HashSet<Instructor>();
            Ins_Subjects = new HashSet<Ins_Subject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int InsId { get; set; }
        public string? ENameAr { get; set; }
        public string? ENameEn { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public int? SupervisorId { get; set; }
        public decimal? Salary { get; set; }
        public string? Image { get; set; }
        public int? DID { get; set; }
        [ForeignKey("DID")]
        [InverseProperty("Instructors")]
        public Department? Department { get; set; }
        [InverseProperty("Instructor")]
        public Department DepartmentManager { get; set; }
        [ForeignKey("SupervisorId")]
        public virtual Instructor? Supervisior { get; set; }
        [InverseProperty("Supervisior")]
        public ICollection<Instructor> Instructors { get; set; }


        [InverseProperty("instructor")]
        public ICollection<Ins_Subject> Ins_Subjects { get; set; }





    }
}
