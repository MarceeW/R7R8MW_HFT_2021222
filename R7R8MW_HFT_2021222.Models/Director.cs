using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace R7R8MW_HFT_2021222.Models
{
    public class Director : IPerson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(240)]
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Movie> Movies { get; set; }

        public Director()
        {   
        }

        public Director(string seed)
        {
            string[] split = seed.Split('#');
            Id = int.Parse(split[0]);
            Name = split[1];
            Movies = new HashSet<Movie>();
        }
        public override bool Equals(object obj)
        {
            Director other = obj as Director;
            return Id == other.Id && Name == other.Name;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
