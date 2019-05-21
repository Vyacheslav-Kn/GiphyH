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
        public void Handle(AddGif command)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Gif gif = new Gif {
                    PublicId = command.PublicId,
                    Title = command.Title,
                    ImageUrl = command.ImageUrl,
                    PublicationDate = command.PublicationDate,
                    UserId = command.UserId
                };

                db.Gifs.Add(gif);
                db.SaveChanges();
            }
        }

        public void Handle(UpdateGif command)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Gif gif = new Gif {
                    Id = command.Id,
                    Title = command.Title
                };

                db.Attach(gif);
                db.Entry(gif).Property("Title").IsModified = true;
                db.SaveChanges();
            }
        }

        public void Handle(DeleteGif command)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Gif gif = new Gif
                {
                    Id = command.Id
                };

                db.Gifs.Remove(gif);
                db.SaveChanges();
            }
        }
    }
}
