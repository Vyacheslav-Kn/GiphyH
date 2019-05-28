using GiphyH.DAL.Interfaces;
using GiphyH.DAL.UserHandlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.DAL.UserInterfaces
{
    public interface ICommonHandler
    {
        CommandHandler CommandHandler { get; set; }
        QueryHandler QueryHandler { get; set; }
    }
}
