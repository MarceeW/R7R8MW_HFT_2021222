using Microsoft.AspNetCore.Mvc;
using R7R8MW_HFT_2021222.Logic;
using R7R8MW_HFT_2021222.Models;
using System.Collections.Generic;
using System.Linq;

namespace R7R8MW_HFT_20212222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        IPersonLogic personLogic;

        public ActorController(IPersonLogic personLogic)
        {
            this.personLogic = personLogic;
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
        }

        // PUT api/<MovieController>/5
        [HttpPut]
        public void Update([FromBody] Actor value)
        {
            personLogic.Update(value);
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            personLogic.Delete(id,true);
        }
    }
}
