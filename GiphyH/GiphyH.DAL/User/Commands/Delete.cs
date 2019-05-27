using GiphyH.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.DAL.UserCommands
{
    public class Delete : ICommand
    {
        public int Id { get; set; }
    }
}
