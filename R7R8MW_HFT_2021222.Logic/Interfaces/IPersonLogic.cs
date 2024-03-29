﻿using R7R8MW_HFT_2021222.Models;
using System.Collections.Generic;
using System.Linq;

namespace R7R8MW_HFT_2021222.Logic
{
    public interface IPersonLogic
    {
        IEnumerable<Actor> AllActorsFromAvengers();
        void Create(IPerson entity);
        void Delete(int id, bool isActor);
        IEnumerable<Director> DirectorWithMostFilms();
        IEnumerable<Actor> MostCommonActor();
        IEnumerable<IPerson> GetAllPersonWithStarting(char startingWith);
        IEnumerable<KeyValuePair<string, IEnumerable<KeyValuePair<string, string>>>> ActorInfo();
        IEnumerable<Director> MostSuccesfulDirector();
        IPerson Read(int id, bool isActor);
        IQueryable<IPerson> ReadAll(bool readActors);
        void Update(IPerson entity);
    }
}