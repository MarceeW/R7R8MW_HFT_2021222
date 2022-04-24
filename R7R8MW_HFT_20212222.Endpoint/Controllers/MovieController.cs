using Microsoft.AspNetCore.Mvc;
using R7R8MW_HFT_2021222.Logic;
using R7R8MW_HFT_2021222.Models;
using System.Collections.Generic;

namespace R7R8MW_HFT_20212222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        IMovieLogic movieLogic;

        public MovieController(IMovieLogic movieLogic)
        {
            this.movieLogic = movieLogic;
        }

        // GET: api/<MovieController>
        [HttpGet]
        public IEnumerable<Movie> ReadAll()
        {
            return movieLogic.ReadAll();
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public Movie Read(int id)
        {
            return movieLogic.Read(id);
        }

        // POST api/<MovieController>
        [HttpPost]
        public void Create([FromBody] Movie value)
        {
            movieLogic.Create(value);
        }

        // PUT api/<MovieController>/5
        [HttpPut]
        public void Update([FromBody] Movie value)
        {
            movieLogic.Update(value);
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            movieLogic.Delete(id);
        }
    }
}
