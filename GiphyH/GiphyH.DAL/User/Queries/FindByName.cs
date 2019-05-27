using GiphyH.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.DAL.UserQueries
{
    public class FindByName : IQuery
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
