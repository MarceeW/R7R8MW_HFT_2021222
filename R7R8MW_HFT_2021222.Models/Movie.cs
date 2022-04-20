using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R7R8MW_HFT_2021222.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(240)]
        public string Title { get; set; }

        [Range(0, 10000)]
        public double Income { get; set; }

        [Range(0, 10)]
        public double Rating { get; set; }

        public DateTime Release { get; set; }

        public int DirectorId { get; set; }

        public virtual Director Director { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public Movie()
        {
        }

        public Movie(string seed)
        {
            string[] split = seed.Split('#');
            Id = int.Parse(split[0]);
            Title = split[1];
            Income = double.Parse(split[2]);
            DirectorId = int.Parse(split[3]);
            Release = DateTime.Parse(split[4].Replace('*', '.'));
            Rating = double.Parse(split[5]);
        }
    }
}
