using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hospital.model
{
    [Table("EMPLOYEES")]
    public class Employee
    {
        [Column("EMPLOYEE_ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("SVNR")]
        [Required]
        public int svnr { get; set; }

        [Column("FIRST_NAME", TypeName = "VARCHAR(30)")]
        [Required]
        public string firstName { get; set; }
        
        [Column("LAST_NAME", TypeName = "VARCHAR(30)")]
        [Required]
        public string lastName { get; set; }

        [Column("SALARY")]
        [Required]
        public int salary { get; set; }
    }
}