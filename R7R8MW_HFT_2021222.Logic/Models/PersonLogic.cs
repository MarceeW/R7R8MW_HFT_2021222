using R7R8MW_HFT_2021222.Models;
using R7R8MW_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R7R8MW_HFT_2021222.Logic
{
    public class PersonLogic : IPersonLogic
    {
        IRepository<Actor> actorRep;
        IRepository<Director> directorRep;

        public PersonLogic(IRepository<Actor> actorRep, IRepository<Director> directorRep)
        {
            this.actorRep = actorRep;
            this.directorRep = directorRep;
        }

        public void Create(IPerson entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            if (entity is Actor)
                actorRep.Create(entity as Actor);
            else if (entity is Director)
                directorRep.Create(entity as Director);
        }

        public void Delete(int id, bool isActor)
        {
            if (id < 0)
                throw new KeyNotFoundException();

            if (isActor)
                actorRep.Delete(id);
            else
                directorRep.Delete(id);
        }

        public IPerson Read(int id, bool isActor)
        {
            if (id < 0)
                throw new KeyNotFoundException();

            if (isActor)
                return actorRep.Read(id);
            else
                return directorRep.Read(id);
        }

        public IQueryable<IPerson> ReadAll(bool readActors)
        {
            if (readActors)
                return actorRep.ReadAll();
            else
                return directorRep.ReadAll();
        }

        public void Update(IPerson entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            if (entity is Actor)
                actorRep.Update(entity as Actor);
            else if (entity is Director)
                directorRep.Update(entity as Director);
        }
        public Director MostSuccesfulDirector(IMovieLogic logic)
        {
            return logic.TopRating().Director;
        }
        public Director DirectorWithMostFilms()
        {
            return (from x in directorRep.ReadAll()
                    orderby x.Movies.Count() descending
                    select x).FirstOrDefault();
        }
        public Actor MostCommonActor()
        {
            return (from x in actorRep.ReadAll()
                    orderby x.Movies.Count() descending
                    select x).FirstOrDefault();
        }
        public IEnumerable<Actor> AllActorsFromAvengers()
        {
            return from x in actorRep.ReadAll()
                   where x.Movies.Any(x => x.Title.ToLower().Contains("avengers"))
                   select x;
        }
    }
}
