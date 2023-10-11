using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hospital.model {
    [Table("PHYSICANS")]
    public class Physician : AEmployee {

        [Required]
        [Column("JOB_SPECIFICATION", TypeName = "VARCHAR(20)")]
        public EJobSpecialisation JobSpecialisation { get; set; }
        
    }
}