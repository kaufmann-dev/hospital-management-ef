using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hospital.model {
    [Table("EMPLOYEES")]
    public abstract class AEmployee {

        [Column("EMPLOYEE_ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("SVNR", TypeName = "int")]
        public int Svnr { get; set; }
        
        [Required]
        [Column("FIRST_NAME", TypeName = "VARCHAR(30)")]
        public string FirstName { get; set; }

        [Required]
        [Column("LAST_NAME", TypeName = "VARCHAR(30)")]
        public string LastName { get; set; }

        [Required]
        [Column("SALARY", TypeName = "INT")]
        public int Salary { get; set; }

        public override string ToString() {
            return $"{nameof(Id)}: {Id}, {nameof(Svnr)}: {Svnr}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, {nameof(Salary)}: {Salary}";
        }
    }
}