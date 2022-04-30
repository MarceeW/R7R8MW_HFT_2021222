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
            if (entity == null)
                throw new ArgumentNullException();

            roleRepository.Create(entity);
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

            Role role = roleRepository.Read(id);
            if (role == null)
                throw new NullReferenceException("This role's ID was recently removed from repository!");
            return role;
        }

        public IQueryable<Role> ReadAll()
        {
            return roleRepository.ReadAll();
        }

        public void Update(Role entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            roleRepository.Update(entity);
        }
        public IEnumerable<string> GetMostCommonRoleName()
        {
            int count = (from x in roleRepository.ReadAll()
                        group x by x.RoleName into roles
                        orderby roles.Count() descending
                        select roles.Count()).First();

            return from x in roleRepository.ReadAll()
                   group x by x.RoleName into roles
                   where roles.Count() == count
                   select roles.Key;
        }
    }
}
