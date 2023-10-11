using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hospital.model {
    [Table("HOSPITAL_FACILITIES")]
    public class Facility {

        [Column("FACILITY_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("NAME", TypeName = "VARCHAR(100)")]
        public string Name { get; set; }

        [Required]
        [Column("PHONE_NR", TypeName = "VARCHAR(20)")]
        public string  PhoneNr { get; set; }
        
    }
}