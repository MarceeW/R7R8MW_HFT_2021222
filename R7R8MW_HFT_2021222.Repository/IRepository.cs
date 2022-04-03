using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R7R8MW_HFT_2021222.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> ReadAll();
        public void Read(int id);
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(int id);
    }
}
