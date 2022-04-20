using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R7R8MW_HFT_2021222.Models
{
    public class Actor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActorId { get; set; }

        [Required]
        [StringLength(240)]
        public string ActorName { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<Role> Roles { get; set; }

        public Actor()
        {

        }
        public Actor(string seed)
        {
            string[] split = seed.Split('#');
            ActorId = int.Parse(split[0]);
            ActorName = split[1];
        }
    }
}
