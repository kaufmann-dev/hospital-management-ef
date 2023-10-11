using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hospital.model {
    
    [Table("OCCUPATIONS")]
    public class Occupation {

        public Ward Ward { get; set; }
        
        [Column("WARD_ID")]
        public int WardId { get; set; }

        public AEmployee Employee { get; set; }
        
        [Column("EMPLOYEE_ID")]
        public int EmployeeId { get; set; }

        [Required]
        [Column("WORKING_HOURS", TypeName = "INT")]
        public int WorkingHours { get; set; }
        
    }
}