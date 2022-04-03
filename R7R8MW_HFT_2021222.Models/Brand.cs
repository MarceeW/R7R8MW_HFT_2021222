using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R7R8MW_HFT_2021222.Models
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; }
        [Required]
        [StringLength(100)]
        public string BrandName { get; set; }

        [Required]
        public int? Price { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public Brand()
        {

        }
        public Brand(string data)
        {
            string[] splitted = data.Split('#');
            BrandId=int.Parse(splitted[0]);
            BrandName=splitted[1];
            Price = int.Parse(splitted[2]);
        }
    }
}
