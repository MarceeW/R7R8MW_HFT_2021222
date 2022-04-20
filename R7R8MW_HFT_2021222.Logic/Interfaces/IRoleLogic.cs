using R7R8MW_HFT_2021222.Models;
using System.Linq;

namespace R7R8MW_HFT_2021222.Logic
{
    public interface IRoleLogic
    {
        void Create(Role entity);
        void Delete(int id);
        string GetMostCommonRoleName();
        Role Read(int id);
        IQueryable<Role> ReadAll();
        void Update(Role entity);
    }
}