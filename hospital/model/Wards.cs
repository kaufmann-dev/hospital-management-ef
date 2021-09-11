using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hospital.model
{
    [Table("WARDS")]
    public class Wards
    {
        [Column("NAME", TypeName = "VARCHAR(100)")]
        [Required]
        public string Name { get; set; }
        
        [Column("HOSPITAL_ID")]
        public int HospitalId { get; set; }
        
        public Facilities Hospital { get; set; }
        
        [Column("CARRYING_CAPACITY")]
        [Required]
        public int Capacity { get; set; }
        
        [ForeignKey("PHYSICIAN_ID")] 
        public Physicians Physician { get; set; }
    }
}