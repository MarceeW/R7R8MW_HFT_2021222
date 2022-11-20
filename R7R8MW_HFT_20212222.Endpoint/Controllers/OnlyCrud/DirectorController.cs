using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using R7R8MW_HFT_2021222.Endpoint.Services;
using R7R8MW_HFT_2021222.Logic;
using R7R8MW_HFT_2021222.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieDbApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        IPersonLogic directorLogic;
        IHubContext<SignalRHub> hub;
        public DirectorController(IPersonLogic logic, IHubContext<SignalRHub> hub)
        {
            directorLogic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Director> ReadAll()
        {
            return (IEnumerable<Director>)directorLogic.ReadAll(false);
        }

        [HttpGet("{id}")]
        public Director Read(int id)
        {
            return directorLogic.Read(id,false) as Director;
        }

        [HttpPost]
        public void Create([FromBody] Director value)
        {
            directorLogic.Create(value);
            hub.Clients.All.SendAsync("DirectorCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Director value)
        {
            directorLogic.Update(value);
            hub.Clients.All.SendAsync("DirectorUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var directrToDelete = directorLogic.Read(id, false);
            directorLogic.Delete(id,false);
            hub.Clients.All.SendAsync("DirectorDeleted", directrToDelete);
        }
    }
}
