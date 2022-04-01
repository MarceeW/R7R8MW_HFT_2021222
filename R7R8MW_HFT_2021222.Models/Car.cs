using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R7R8MW_HFT_2021222.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarId { get; set; }
        public string CarName { get; set; }

        public int? BrandId { get; set; }
        public int? RentEventId { get; set; }

        public virtual Brand Brand { get; private set; }
        public virtual RentEvent RentEvent { get; private set; }
    }
}
