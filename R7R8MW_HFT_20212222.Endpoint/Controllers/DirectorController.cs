using Microsoft.AspNetCore.Mvc;
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
        public DirectorController(IPersonLogic logic)
        {
            directorLogic = logic;
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
        }

        [HttpPut]
        public void Put([FromBody] Director value)
        {
            directorLogic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            directorLogic.Delete(id,false);
        }
    }
}
