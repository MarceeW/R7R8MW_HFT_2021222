using R7R8MW_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R7R8MW_HFT_2021222.Repository
{
    internal class ActorRepository : Repository<Actor>, IRepository<Actor>
    {
        public ActorRepository(MovieDbContext ctx) : base(ctx)
        {
        }

        public override Actor Read(int id)
        {
            return ctx.Actors.FirstOrDefault(x => x.ActorId == id);
        }

        public override void Update(Actor item)
        {
            var old = Read(item.ActorId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
