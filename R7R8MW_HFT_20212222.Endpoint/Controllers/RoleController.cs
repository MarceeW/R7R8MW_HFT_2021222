using Microsoft.AspNetCore.Mvc;
using R7R8MW_HFT_2021222.Logic;
using R7R8MW_HFT_2021222.Models;
using System.Collections.Generic;

namespace MovieDbApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRoleLogic logic;
        public RoleController(IRoleLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Role> ReadAll()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Role Read(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Role value)
        {
            logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Role value)
        {
            logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
