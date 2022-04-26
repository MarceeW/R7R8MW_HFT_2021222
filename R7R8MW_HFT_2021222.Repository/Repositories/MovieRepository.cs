using R7R8MW_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R7R8MW_HFT_2021222.Repository
{
    public class MovieRepository : Repository<Movie>,IRepository<Movie>
    {
        public MovieRepository(MovieDbContext ctx) : base(ctx)
        {
        }

        public override Movie Read(int id)
        {
            return ctx.Movies.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(Movie item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                if(prop.GetAccessors().FirstOrDefault(x=>x.IsVirtual)==null)
                    prop.SetValue(old,prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
