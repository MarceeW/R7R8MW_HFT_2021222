using R7R8MW_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R7R8MW_HFT_2021222.Repository
{
    public class RoleRepository : Repository<Role>,IRepository<Role>
    {
        public RoleRepository(MovieDbContext ctx) : base(ctx)
        {
        }

        public override Role Read(int id)
        {
            return ctx.Roles.FirstOrDefault(x => x.RoleId==id);
        }

        public override void Update(Role item)
        {
            var old = Read(item.RoleId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
