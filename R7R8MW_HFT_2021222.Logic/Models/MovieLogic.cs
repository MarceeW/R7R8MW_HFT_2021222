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
            if (id < 0)
                throw new KeyNotFoundException();

            repository.Delete(id);
        }

        public Movie Read(int id)
        {
            if (id < 0)
                throw new KeyNotFoundException();

            return repository.Read(id);
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
        public Movie LargestIncome()
        {
            return (from x in repository.ReadAll()
                    orderby x.Income
                    select x).FirstOrDefault();
        }
        public Movie Oldest()
        {
            return (from x in repository.ReadAll()
                    orderby x.Release
                    select x).FirstOrDefault();
        }
        public Movie TopRating()
        {
            return (from x in repository.ReadAll()
                    orderby x.Rating descending
                    select x).FirstOrDefault();
        }
    }
}
