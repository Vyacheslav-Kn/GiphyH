using GiphyH.DAL.Interfaces;
using System;

namespace GiphyH.DAL.GifCommands
{
    public class Add : ICommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ImageUrl { get; set; }
        public int UserId { get; set; }
    }
}
