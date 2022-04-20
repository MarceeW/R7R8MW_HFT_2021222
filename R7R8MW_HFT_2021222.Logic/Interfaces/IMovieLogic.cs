using R7R8MW_HFT_2021222.Models;
using System.Linq;

namespace R7R8MW_HFT_2021222.Logic
{
    public interface IMovieLogic
    {
        void Create(Movie entity);
        void Delete(int id);
        Movie LargestIncome();
        Movie Oldest();
        Movie Read(int id);
        IQueryable<Movie> ReadAll();
        Movie TopRating();
        void Update(Movie entity);
    }
}