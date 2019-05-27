using GiphyH.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.DAL.GifQueries
{
    public class FindByTag : IQuery
    {
        public int Id { get; set; }
        public string TagTitle { get; set; }
    }
}
