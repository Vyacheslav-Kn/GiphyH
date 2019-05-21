using GiphyH.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.DAL.Queries.User
{
    public class FindUserByPublicId : IQuery
    {
        public string PublicId { get; set; }
    }
}
