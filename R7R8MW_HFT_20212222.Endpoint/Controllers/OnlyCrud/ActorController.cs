using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using R7R8MW_HFT_2021222.Endpoint.Services;
using R7R8MW_HFT_2021222.Logic;
using R7R8MW_HFT_2021222.Models;
using System.Collections.Generic;
using System.Linq;

namespace R7R8MW_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        IPersonLogic personLogic;
        IHubContext<SignalRHub> hub;

        public ActorController(IPersonLogic personLogic,IHubContext<SignalRHub> hub)
        {
            this.personLogic = personLogic;
            this.hub = hub;
        }

        // GET: api/<MovieController>
        [HttpGet]
        public IEnumerable<Actor> ReadAll()
        {
            return (IEnumerable<Actor>)personLogic.ReadAll(true);
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public Actor Read(int id)
        {
            return personLogic.Read(id,true) as Actor;
        }

        // POST api/<MovieController>
        [HttpPost]
        public void Create([FromBody] Actor value)
        {
            personLogic.Create(value);
            hub.Clients.All.SendAsync("ActorCreated",value);
        }

        // PUT api/<MovieController>/5
        [HttpPut]
        public void Put([FromBody] Actor value)
        {
            personLogic.Update(value);
            hub.Clients.All.SendAsync("ActorUpdated", value);
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var actorToDelete = personLogic.Read(id, true);
            personLogic.Delete(id, true);
            hub.Clients.All.SendAsync("ActorDeleted", actorToDelete);
        }
    }
}
