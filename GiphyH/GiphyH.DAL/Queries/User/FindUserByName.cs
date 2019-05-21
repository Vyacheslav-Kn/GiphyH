using GiphyH.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.DAL.Queries.User
{
    public class FindUserByName : IQuery
    {
        public string PublicId { get; set; }
        public string Name { get; set; }
    }
}
