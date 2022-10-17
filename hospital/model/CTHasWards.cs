using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hospital.model
{
    [Table("CARETAKERS_HAS_WARDS")]
    public class CTHasWards
    {
        [Column("CARETAKER_ID")] 
        public int CaretakerId { get; set; }
        
        [Column("WARD_NAME", TypeName = "VARCHAR(100)")]
        public string WardName { get; set; }
        
        [Column("WORKING_HOURS")]
        public int Hours { get; set; }
        
        public Caretakers Caretaker { get; set; }
        
        public Wards Ward { get; set; }
    }
}