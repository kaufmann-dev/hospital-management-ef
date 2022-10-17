using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hospital.model
{
    [Table("HOSPITAL_FACILITIES")]
    public class Facilities
    {
        [Column("FACILITY_ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Column("NAME", TypeName = "VARCHAR(100)")]
        [Required]
        public string Name { get; set; }
        
        [Column("PHONE_NR", TypeName = "VARCHAR(20)")]
        [Required]
        public string PhoneNr { get; set; }
    }
}