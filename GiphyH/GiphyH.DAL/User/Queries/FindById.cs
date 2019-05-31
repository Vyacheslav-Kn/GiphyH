using GiphyH.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.DAL.UserQueries
{
    public class FindById : IQuery
    {
        public int Id { get; set; }
    }
}
