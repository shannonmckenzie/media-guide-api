using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaGuide.Repository.Entities;

namespace MediaGuide.Repository.Factories
{
    class MediaItemFactory
    {
        public DTO.MediaItem CreateMediaItem(MediaItem mediaItem)
        {
            return new DTO.MediaItem()
            {
                Id = mediaItem.Id,
                Description = mediaItem.Description,
                DateOfPurchase = mediaItem.DateOfPurchase,
                Type = mediaItem.Type
            };
        }

        public MediaItem CreateMediaItem(DTO.MediaItem mediaItem)
        {
            return new MediaItem()
            {
                Id = mediaItem.Id,
                Description = mediaItem.Description,
                DateOfPurchase = mediaItem.DateOfPurchase,
                Type = mediaItem.Type
            };
        }
    }
}
