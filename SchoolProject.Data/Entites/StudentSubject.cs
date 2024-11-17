using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entites
{
    public class StudentSubject
    {
        [Key]
        public int StudSubID { get; set; }
        public int StudID { get; set; }
        public int SubID { get; set; }
        public decimal? Grade { get; set; }
        [ForeignKey("StudID")]
        [InverseProperty("StudentSubjects")]
        public virtual Student Student { get; set; }

        [ForeignKey("SubID")]
        [InverseProperty("StudentsSubjects")]
        public virtual Subjects Subject { get; set; }

    }
}
