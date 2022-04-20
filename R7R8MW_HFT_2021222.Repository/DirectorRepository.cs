using R7R8MW_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R7R8MW_HFT_2021222.Repository
{
    internal class DirectorRepository : Repository<Director>, IRepository<Director>
    {
        public DirectorRepository(MovieDbContext ctx) : base(ctx)
        {
        }

        public override Director Read(int id)
        {
            return ctx.Directors.FirstOrDefault(x => x.DirectorId == id);
        }

        public override void Update(Director item)
        {
            var old = Read(item.DirectorId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
