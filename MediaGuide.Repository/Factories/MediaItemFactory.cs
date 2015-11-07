using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaGuide.Repository.Entities;

namespace MediaGuide.Repository
{
    public class MediaItemFactory
    {
        public DTO.MediaItem CreateMediaItem(MediaItem mediaItem)
        {
            return new DTO.MediaItem()
            {
                Id = mediaItem.Id,
                Description = mediaItem.Description,
                Channel_Id = mediaItem.Channel_Id,
                Name = mediaItem.Name,
                Url = mediaItem.Url
            };
        }

        public MediaItem CreateMediaItem(DTO.MediaItem mediaItem)
        {
            return new MediaItem()
            {
                Id = mediaItem.Id,
                Description = mediaItem.Description,
                Channel_Id = mediaItem.Channel_Id,
                Name = mediaItem.Name,
                Url = mediaItem.Url
            };
        }
    }
}
