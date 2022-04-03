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

        [ForeignKey(nameof(Brand))]
        public int? BrandId { get; set; }

        public virtual Brand Brand { get; private set; }
        public virtual ICollection<RentEvent> RentEvents { get; set; }
        public Car()
        {

        }
        public Car(string data)
        {
            string[] splitted=data.Split('#');
            CarId = int.Parse(splitted[0]);
            BrandId = int.Parse(splitted[2]);
        }
    }
}
