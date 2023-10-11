using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hospital.model {
    
    [Table("WARDS")]
    public class Ward {

        [Column("WARD_ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("NAME", TypeName = "VARCHAR(100)")]
        public string Name { get; set; }

        [Required]
        [Column("CARRING_CAPACITY", TypeName = "INT")]
        public int CarryingCapacity { get; set; }

        public Physician Manager { get; set; }

        [Column("MANAGER_ID")]
        public int? ManagerId { get; set; }

        public Facility Facility { get; set; }

        [Column("FACILITY_ID")]
        public int FacilityId { get; set; }

        public override string ToString() {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(CarryingCapacity)}: {CarryingCapacity}, {nameof(ManagerId)}: {ManagerId}, {nameof(FacilityId)}: {FacilityId}";
        }
    }
}