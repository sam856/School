using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entites
{
    public class Ins_Subject
    {
        [Key]
        public int InsId { get; set; }
        [Key]
        public int SubId { get; set; }
        [ForeignKey("InsId")]
        [InverseProperty("Ins_Subjects")]
        public Instructor? instructor { get; set; }
        [ForeignKey("SubId")]
        [InverseProperty("Ins_Subjects")]
        public Subjects? Subject { get; set; }
    }
}
