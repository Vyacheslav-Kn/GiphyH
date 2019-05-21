using GiphyH.DAL.Entities;
using GiphyH.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.DAL.Commands.Gif
{
    public class UpdateGif : ICommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
