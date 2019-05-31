using GiphyH.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.DAL.GifCommands
{
    public class Delete : ICommand
    {
        public int Id { get; set; }
    }
}
