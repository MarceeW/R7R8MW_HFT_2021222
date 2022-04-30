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
            {
                try
                {
                    actorRep.Delete(id);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                try
                {
                    directorRep.Delete(id);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public IPerson Read(int id, bool isActor)
        {
            if (id < 0)
                throw new KeyNotFoundException();

            if (isActor)
            {
                Actor actor = actorRep.Read(id);
                if (actor == null)
                    throw new NullReferenceException("This actor's ID was recently removed from repository!");
                return actor;
            }
            else
            {
                Director director = directorRep.Read(id);
                if (director == null)
                    throw new NullReferenceException("This director's ID was recently removed from repository!");
                return director;
            }
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
        public IEnumerable<Director> MostSuccesfulDirector(IMovieLogic logic)
        {
            return logic.TopRating().Select(x => x.Director);
        }
        public IEnumerable<Director> DirectorWithMostFilms()
        {
            int films = (from x in directorRep.ReadAll()
                         orderby x.Movies.Count descending
                         select x.Movies.Count).FirstOrDefault();

            return directorRep.ReadAll().Where(x => x.Movies.Count == films);
        }
        public IEnumerable<Actor> MostCommonActor()
        {
            int count = (from x in actorRep.ReadAll()
                         orderby x.Movies.Count() descending
                         select x.Movies.Count()).FirstOrDefault();

            return actorRep.ReadAll().Where(x => x.Movies.Count == count);
        }
        public IEnumerable<Actor> AllActorsFromAvengers()
        {
            return from x in actorRep.ReadAll()
                   where x.Movies.Any(x => x.Title.ToLower().Contains("avengers"))
                   select x;
        }
    }
}
