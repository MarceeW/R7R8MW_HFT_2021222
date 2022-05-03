using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using R7R8MW_HFT_2021222.Logic;
using R7R8MW_HFT_2021222.Models;
using System.Collections.Generic;

namespace R7R8MW_HFT_2021222.Endpoint.Controllers.Noncrud
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PersonNonCruds : Controller
    {
        IPersonLogic logic;

        public PersonNonCruds(IPersonLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public IEnumerable<Actor> AllActorsFromAvengers()
        {
            return logic.AllActorsFromAvengers();
        }
        [HttpGet]
        public IEnumerable<Director> DirectorWithMostFilms()
        {
            return logic.DirectorWithMostFilms();
        }
        [HttpGet]
        public IEnumerable<Actor> MostCommonActor()
        {
            return logic.MostCommonActor();
        }
        [HttpGet("{letter}")]
        public IEnumerable<IPerson> GetAllPersonWithStarting(char letter)
        {
            return logic.GetAllPersonWithStarting(letter);
        }
        [HttpGet]
        public IEnumerable<Director> GetMostSuccesfulDirector()
        {
            return logic.MostSuccesfulDirector();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, IEnumerable<KeyValuePair<string, string>>>> ActorInfo()
        {
            return logic.ActorInfo();
        }
    }
}
