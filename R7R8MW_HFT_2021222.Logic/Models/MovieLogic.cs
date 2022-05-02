using R7R8MW_HFT_2021222.Models;
using R7R8MW_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R7R8MW_HFT_2021222.Logic
{
    public class MovieLogic : IMovieLogic
    {
        IRepository<Movie> repository;

        public MovieLogic(IRepository<Movie> repository)
        {
            this.repository = repository;
        }

        public void Create(Movie entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            repository.Create(entity);
        }

        public void Delete(int id)
        {
            if (id < 0 || id > repository.ReadAll().Count())
                throw new KeyNotFoundException();
            else 
                repository.Delete(id);
        }

        public Movie Read(int id)
        {
            if (id < 0)
                throw new KeyNotFoundException();

            Movie movie = repository.Read(id);
            if (movie == null)
                throw new NullReferenceException("This movie's ID was recently removed from repository!");
            return movie;
        }

        public IQueryable<Movie> ReadAll()
        {
            return repository.ReadAll();
        }

        public void Update(Movie entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            repository.Update(entity);
        }
        public IEnumerable<Movie> LargestIncome()
        {
            double largestIncome = (from x in repository.ReadAll()
                                    orderby x.Income descending
                                    select x.Income).First();

            return from x in repository.ReadAll()
                   where x.Income == largestIncome
                   select x;
        }
        public IEnumerable<Movie> Oldest()
        {
            DateTime oldestDate = (from x in repository.ReadAll()
                                   orderby x.Release
                                   select x.Release).FirstOrDefault();

            return repository.ReadAll().Where(x => x.Release.Equals(oldestDate));
        }
        public IEnumerable<Movie> TopRating()
        {
            double topRating = (from x in repository.ReadAll()
                                orderby x.Rating descending
                                select x.Rating).FirstOrDefault();

            return repository.ReadAll().Where(x=>x.Rating == topRating);
        }
        public IEnumerable<KeyValuePair<int, IEnumerable<Movie>>> MoviesPerYear()
        {
            return from x in repository.ReadAll()
                   group x by x.Release.Year into years
                   select new KeyValuePair<int, IEnumerable<Movie>>
                   (years.Key, 
                   repository.ReadAll()
                   .Where(x => x.Release.Year == years.Key)
                   .AsEnumerable());
        }
        public IEnumerable<Movie> MovieWithMostActors()
        {
            int mostActors=repository.ReadAll().Max(x=>x.Actors.Count());

            return repository.ReadAll().Where(x=>x.Actors.Count()==mostActors);
        }
    }
}
