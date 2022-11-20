using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using R7R8MW_HFT_2021222.Endpoint.Services;
using R7R8MW_HFT_2021222.Logic;
using R7R8MW_HFT_2021222.Models;
using System.Collections.Generic;

namespace R7R8MW_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        IMovieLogic movieLogic;
        IHubContext<SignalRHub> hub;
        public MovieController(IMovieLogic movieLogic, IHubContext<SignalRHub> hub)
        {
            this.movieLogic = movieLogic;
            this.hub = hub;
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
            hub.Clients.All.SendAsync("MovieCreated", value);
        }

        // PUT api/<MovieController>/5
        [HttpPut]
        public void Update([FromBody] Movie value)
        {
            movieLogic.Update(value);
            hub.Clients.All.SendAsync("MovieUpdated", value);
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var movieToDelete = Read(id);
            movieLogic.Delete(id);
            hub.Clients.All.SendAsync("MovieDeleted", movieToDelete);
        }
    }
}
