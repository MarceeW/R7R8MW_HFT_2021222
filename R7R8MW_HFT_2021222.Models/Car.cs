using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R7R8MW_HFT_2021222.Models
{
    internal class Car
    {
        [Key]
        []
        public int CarId { get; set; }
        public Brand Brand { get; set; }
        public RentEvent RentEvent { get; set; }
    }
}
