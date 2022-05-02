using Microsoft.AspNetCore.Mvc;
using R7R8MW_HFT_2021222.Logic;
using R7R8MW_HFT_2021222.Models;
using System.Collections.Generic;

namespace R7R8MW_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MovieNonCruds : ControllerBase
    {
        IMovieLogic logic;

        public MovieNonCruds(IMovieLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public IEnumerable<Movie> OldestMovie()
        {
            return logic.Oldest();
        }
        [HttpGet]
        public IEnumerable<Movie> TopRatedMovie()
        {
            return logic.TopRating();
        }
        [HttpGet]
        public IEnumerable<Movie> MovieWithLargestIncome()
        {
            return logic.LargestIncome();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<int, IEnumerable<Movie>>> MoviesPerYear()
        {
            return logic.MoviesPerYear();
        }
        [HttpGet]
        public IEnumerable<Movie> MoviesWithMostActors()
        {
            return logic.MovieWithMostActors();
        }
    }
}
