using R7R8MW_HFT_2021222.Models;
using System.Linq;

namespace R7R8MW_HFT_2021222.Logic
{
    public interface IPersonLogic
    {
        void Create(IPerson entity);
        void Delete(int id, bool isActor);
        IPerson Read(int id, bool isActor);
        IQueryable<IPerson> ReadAll(bool readActors);
        void Update(IPerson entity);
        public Director MostSuccesfulDirector(IMovieLogic logic);
        public Director DirectorWithMostFilms();
        public Actor MostCommonActor();
    }
}