using System.ComponentModel.DataAnnotations.Schema;

namespace hospital.model {
    [Table("CARETAKER")]
    public class Caretaker : AEmployee {

        public Caretaker Superior { get; set; }

        [Column("SUPERIOR_ID")]
        public int? SuperiorId { get; set; }

    }
}