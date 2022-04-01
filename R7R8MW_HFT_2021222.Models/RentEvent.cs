using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R7R8MW_HFT_2021222.Models
{
    public class RentEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentEventId { get; set; }
        [Required]
        public DateTime RentDate { get; set; }
        [Required]
        public double Duration { get; set; }

        public int? CarId { get; set; }

        public virtual Car Car { get; private set; }
    }
}
