using GiphyH.DAL.Commands.Gif;
using GiphyH.DAL.Database;
using GiphyH.DAL.Entities;
using GiphyH.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiphyH.DAL.Handlers
{
    public class CommandHandler :
        ICommandHandler<AddGif>,
        ICommandHandler<UpdateGif>,
        ICommandHandler<DeleteGif>
    {
        private ApplicationContext _db;

        public CommandHandler(ApplicationContext db)
        {
            this._db = db;
        }

        public void Handle(AddGif command)
        {
            Gif gif = new Gif
            {
                Title = command.Title,
                ImageUrl = command.ImageUrl,
                PublicationDate = command.PublicationDate,
                UserId = command.UserId
            };

            _db.Gifs.Add(gif);
            _db.SaveChanges();
        }

        public void Handle(UpdateGif command)
        {
            Gif gif = new Gif
            {
                Id = command.Id,
                Title = command.Title
            };

            _db.Attach(gif);
            _db.Entry(gif).Property("Title").IsModified = true;
            _db.SaveChanges();
        }

        public void Handle(DeleteGif command)
        {
            Gif gif = new Gif
            {
                Id = command.Id
            };

            _db.Gifs.Remove(gif);
            _db.SaveChanges();
        }
    }
}
