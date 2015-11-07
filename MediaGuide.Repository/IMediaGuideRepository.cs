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
        IQueryable<Entities.ChannelGroup> GetChannelGroups();
        Entities.ChannelGroup GetChannelGroup(int id);
        RepositoryActionResult<Entities.ChannelGroup> DeleteChannelGroup(int id);
        RepositoryActionResult<Entities.ChannelGroup> InsertChannelGroup(Entities.ChannelGroup channelGroup);
        RepositoryActionResult<Entities.ChannelGroup> UpdateChannelGroup(Entities.ChannelGroup channelGroup);
        IQueryable<Entities.MediaItem> GetMediaItems();
        Entities.MediaItem GetMediaItem(int id);
        RepositoryActionResult<Entities.MediaItem> DeleteMediaItem(int id);
        RepositoryActionResult<Entities.MediaItem> InsertMediaItem(Entities.MediaItem mediaItem);
        RepositoryActionResult<Entities.MediaItem> UpdateMediaItem(Entities.MediaItem mediaItem);
        IQueryable<Entities.SharedChannel> GetSharedChannels();
        Entities.SharedChannel GetSharedChannel(int id);
        RepositoryActionResult<Entities.SharedChannel> DeleteSharedChannel(int id);
        RepositoryActionResult<Entities.SharedChannel> InsertSharedChannel(Entities.SharedChannel sharedChannel);
        RepositoryActionResult<Entities.SharedChannel> UpdateSharedChannel(Entities.SharedChannel sharedChannel);
    }
}
