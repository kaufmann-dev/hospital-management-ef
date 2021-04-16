using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hospital.model
{
    [Table("PHYSICIANS")]
    public class Physicians : Employee
    {
        [Column("JOB_SPECIALISATION", TypeName = "VARCHAR(30)")]
        [Required]
        public string jobspecialisation { get; set; }
    }
}