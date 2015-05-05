using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaGuide.Repository;

namespace MediaGuide.Repository
{
    public interface IMediaGuideRepository
    {
        IQueryable<Entities.Channel> GetChannels();
        Entities.Channel GetChannel(int id);
        RepositoryActionResult<Entities.Channel> DeleteChannel(int id);
        RepositoryActionResult<Entities.Channel> InsertChannel(Entities.Channel channel);
        RepositoryActionResult<Entities.Channel> UpdateChannel(Entities.Channel channel);

        //********************TODO: MUST ADD ALL BELOW TO MEDIAGUIDEREPOSITORY.CS!!*********************//
        IQueryable<Entities.SharedChannelGroup> GetSharedChannelGroups();
        Entities.SharedChannelGroup GetSharedChannelGroup(int id);
        RepositoryActionResult<Entities.SharedChannelGroup> DeleteSharedChannelGroup(Entities.SharedChannelGroup sharedChannelGroup);
        RepositoryActionResult<Entities.SharedChannelGroup> InsertSharedChannelGroup(Entities.SharedChannelGroup sharedChannelGroup);
        RepositoryActionResult<Entities.SharedChannelGroup> UpdateSharedChannelGroup(Entities.SharedChannelGroup sharedChannelGroup);

        IQueryable<Entities.MediaItem> GetMediaItems();
        Entities.MediaItem GetMediaItem(int id);
        RepositoryActionResult<Entities.MediaItem> DeleteMediaItem(int id);
        RepositoryActionResult<Entities.MediaItem> InsertMediaItem(Entities.MediaItem mediaItem);
        RepositoryActionResult<Entities.MediaItem> UpdateMediaItem(Entities.MediaItem mediaItem);

        IQueryable<Entities.Channel> GetChannelGroups();
        Entities.ChannelGroup GetChannelGroup(int id);
        RepositoryActionResult<Entities.ChannelGroup> DeleteChannelGroup(int id);
        RepositoryActionResult<Entities.ChannelGroup> InsertChannelGroup(Entities.ChannelGroup channelGroup);
        RepositoryActionResult<Entities.ChannelGroup> UpdateChannelGroup(Entities.ChannelGroup channelGroup);
    }
}
