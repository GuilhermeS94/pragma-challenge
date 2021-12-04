using System;
using System.Collections.Generic;
using DotNetCodeChallenge.Models;

namespace DotNetCodeChallenge.Repo
{
    public interface IBeersRepo
    {
        public List<Beer> ListAll();

        public Beer GetById(string id);
    }
}
