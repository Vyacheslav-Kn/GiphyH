using GiphyH.DAL.GifHandlers;
using GiphyH.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.DAL.GifInterfaces
{
    public interface IGifHandler
    {
        CommandHandler CommandHandler { get; set; }
        QueryHandler QueryHandler { get; set; }
    }
}
