using GiphyH.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.DAL.Commands.Gif
{
    public class DeleteGif : ICommand
    {
        public int Id { get; set; }
    }
}
