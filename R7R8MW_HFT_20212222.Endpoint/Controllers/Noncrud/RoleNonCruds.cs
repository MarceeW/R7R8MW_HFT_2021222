using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using R7R8MW_HFT_2021222.Logic;
using R7R8MW_HFT_2021222.Models;
using System.Collections.Generic;

namespace R7R8MW_HFT_2021222.Endpoint.Controllers.Noncrud
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RoleNonCruds : Controller
    {
        IRoleLogic logic;

        public RoleNonCruds(IRoleLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<string> GetMostCommonRoleName()
        {
            return logic.GetMostCommonRoleName();
        }
    }
}
