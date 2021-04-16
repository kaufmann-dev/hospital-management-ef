using System.ComponentModel.DataAnnotations.Schema;

namespace hospital.model
{
    [Table("CARE_TAKERS")]
    public class Caretakers : Employee
    {
        [ForeignKey("SUPERIOR_ID")]
        public Caretakers superior { get; set; }
    }
}