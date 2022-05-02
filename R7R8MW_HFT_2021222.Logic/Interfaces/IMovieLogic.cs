using R7R8MW_HFT_2021222.Models;
using System.Collections.Generic;
using System.Linq;

namespace R7R8MW_HFT_2021222.Logic
{
    public interface IMovieLogic
    {
        void Create(Movie entity);
        void Delete(int id);
        IEnumerable<Movie> LargestIncome();
        IEnumerable<Movie> Oldest();
        Movie Read(int id);
        IQueryable<Movie> ReadAll();
        IEnumerable<Movie> TopRating();
        IEnumerable<KeyValuePair<int, IEnumerable<Movie>>> MoviesPerYear();
        IEnumerable<Movie> MovieWithMostActors();
        void Update(Movie entity);
    }
}