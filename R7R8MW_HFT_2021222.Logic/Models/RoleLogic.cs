using R7R8MW_HFT_2021222.Models;
using R7R8MW_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R7R8MW_HFT_2021222.Logic
{
    public class RoleLogic : IRoleLogic
    {
        IRepository<Role> roleRepository;
        public RoleLogic(IRepository<Role> rp)
        {
            roleRepository = rp;
        }
        public void Create(Role entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            if (id < 0)
                throw new KeyNotFoundException();

            roleRepository.Delete(id);
        }

        public Role Read(int id)
        {
            if (id < 0)
                throw new KeyNotFoundException();

            return roleRepository.Read(id);
        }

        public IQueryable<Role> ReadAll()
        {
            return roleRepository.ReadAll();
        }

        public void Update(Role entity)
        {
            if (entity == null)
                throw new NullReferenceException();

            roleRepository.Update(entity);
        }
        public string GetMostCommonRoleName()
        {
            return (from x in roleRepository.ReadAll()
                    group x by x.RoleName into roles
                    orderby roles.Count() descending
                    select roles.Key).FirstOrDefault();

        }
    }
}
