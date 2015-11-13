 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaGuide.Repository.Entities;

namespace MediaGuide.Repository
{
    public class MediaGuideRepository : IMediaGuideRepository
    {
        public IQueryable<Channel> GetChannels()
        {
            return BuildChannelsList().AsQueryable();
        }

        public Channel GetChannel(int id)
        {
            return BuildChannelsList().Where(c => c.Id == id).FirstOrDefault();
        }

        public RepositoryActionResult<Channel> DeleteChannel(int id)
        {
            try
            {
                var channelList = BuildChannelsList();
                var channelToRemove = channelList.FirstOrDefault(c => c.Id == id);
                if (channelToRemove != null)
                {
                    BuildChannelsList().Remove(channelToRemove);
                    return new RepositoryActionResult<Channel>(null, RepositoryActionStatus.Deleted);
                }
             
                return new RepositoryActionResult<Channel>(null, RepositoryActionStatus.NotFound);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Channel>(null, RepositoryActionStatus.Error, ex);
            }
        }

        public RepositoryActionResult<Channel> InsertChannel(Channel channel)
        {
            try
            {
                var channelList = BuildChannelsList();
                channel.Id = channelList.Max(c => c.Id) + 1;
                channelList.Add(channel);

                return new RepositoryActionResult<Channel>(channel, RepositoryActionStatus.Created);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Channel>(null, RepositoryActionStatus.Error, ex);
            }
        }

        public RepositoryActionResult<Channel> UpdateChannel(Channel channel)
        {
            try
            {
                var channelList = BuildChannelsList();
                var existingChannel = channelList.Where(c => c.Id == channel.Id).FirstOrDefault();
                channelList[channelList.IndexOf(existingChannel)] = channel;

                return new RepositoryActionResult<Channel>(channel, RepositoryActionStatus.Updated);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Channel>(null, RepositoryActionStatus.Error, ex);
            }
        }

        private List<Channel> BuildChannelsList()
        {
            var channels = new List<Channel>
            {
                new Channel()
                {
                    Id = 1,
                    Name = "Amazon",
                    Description = "Amazon Instant Video"
                },
                new Channel()
                {
                    Id = 2,
                    Name = "Netflix",
                    Description = "Netflix Streaming"
                },
                new Channel()
                {
                    Id = 3,
                    Name = "National Geographic",
                    Description = "National Geographic Roku Channel"
                },
                new Channel()
                {
                    Id = 4,
                    Name = "Plex",
                    Description = "Plex Media Server"
                },
                new Channel()
                {
                    Id = 5,
                    Name = "CBS",
                    Description = "Broadcast TV Channel"
                },
                new Channel()
                {
                    Id = 6,
                    Name = "NBC",
                    Description = "Broadcast TV Channel"
                },
                new Channel()
                {
                    Id = 7,
                    Name = "ABC",
                    Description = "Broadcast TV Channel"
                },
                new Channel()
                {
                    Id = 8,
                    Name = "YouTube",
                    Description = "Internet Channel"
                },
                new Channel()
                {
                    Id = 9,
                    Name = "ESPN",
                    Description = "Cable TV Channel"
                },
                new Channel()
                {
                    Id = 10,
                    Name = "Comedy Central",
                    Description = "Cable TV Channel"
                }
            };

            return channels;
        }

        public IQueryable<ChannelGroup> GetChannelGroups()
        {
            return BuildChannelGroupsList().AsQueryable();
        }

        public ChannelGroup GetChannelGroup(int id)
        {
            return BuildChannelGroupsList().Where(p => p.Id == id).FirstOrDefault();
        }

        public RepositoryActionResult<ChannelGroup> UpdateChannelGroup(ChannelGroup channelGroup)
        {
            try
            {
                var channelGroupList = BuildChannelGroupsList();
                var channelGroupToUpdate = channelGroupList.Where(p => p.Id = channelGroup.Id).FirstOrDefault();
                channelGroupList[channelGroupList.IndexOf(channelGroupToUpdate)] = channelGroup;

                return new RepositoryActionResult<ChannelGroup>(channelGroup, RepositoryActionStatus.Updated);
            }
            catch(Exception ex)
            {
                return new RepositoryActionResult<ChannelGroup>(null, RepositoryActionStatus.Error, ex);
            }
        }

        public RepositoryActionResult<ChannelGroup> InsertChannelGroup(ChannelGroup channelGroup)
        {
            try
            {
                var channelGroupsList = BuildChannelGroupsList();
                channelGroup.Id = channelGroupsList.Max(p => p.Id) + 1;
                channelGroupsList.Add(channelGroup);

                return new RepositoryActionResult<ChannelGroup>(channelGroup, RepositoryActionStatus.Created);
            }
            catch(Exception ex)
            {
                return new RepositoryActionResult<ChanelGroup>(null, RepositoryActionStatus.Error, ex);
            }
        }

        public RepositoryActionResult<ChannelGroup> DeleteChannelGroup(int id)
        {
            try
            {
                var channelGroupList = BuildChannelGroupsList();
                var channelGroupToRemove = channelGroupList.Where(p => p.Id == id).FirstOrDefault();

                if (channelGroupToRemove == null)
                {
                    return new RepositoryActionResult<ChannelGroup>(null, RepositoryActionStatus.NotFound);
                }

                BuildChannelGroupsList().Remove(channelGroupToRemove);
                return new RepositoryActionResult<ChannelGroup>(null, RepositoryActionStatus.Deleted);
            }
            catch(Exception ex)
            {
                return new RepositoryActionResult<ChannelGroup>(null, RepositoryActionStatus.Error, ex)
            }
        }

        private List<ChannelGroup> BuildChannelGroupsList()
        {
            var channelGroups = new List<ChannelGroup>
            {
                new ChannelGroup()
                {
                    Id = 1,
                    Name = "Sports"
                },
                new ChannelGroup()
                {
                    Id = 2,
                    Name = "Family"
                },
                new ChannelGroup()
                {
                    Id = 3,
                    Name = "Carton"
                },
                new ChannelGroup()
                {
                    Id = 4,
                    Name = "Reality TV"
                },
                new ChannelGroup()
                {
                    Id = 5,
                    Name = "Outdoors"
                }
            }
            return channelGroups;
        } 

        public RepositoryActionResult<MediaItem> DeleteMediaItem(int id)
        {
            try
            {
                var mediaItemList = BuildMediaItemsList();
                var mediaItemToRemove = mediaItemList.Where(p => p.Id == id).FirstOrDefault();

                if(mediaItemToRemove == null)
                {
                    return new RepositoryActionResult<MediaItem>(null, RepositoryActionStatus.NotFound);
                }

                BuildMediaItemsList().Remove(mediaItemToRemove);
                return new RepositoryActionResult<MediaItem>(null, RepositoryActionStatus.Deleted);
            }
            catch(Exception ex)
            {
                return new RepositoryActionResult<MediaItem>(null, RepositoryActionStatus.Error, ex);
            }
        }

        public RepositoryActionResult<MediaItem> InsertMediaItem(MediaItem mediaItem)
        {
            try
            {
                var mediaItemList = BuildMediaItemsList();
                mediaItem.Id = mediaItemList.Max(p => p.Id) + 1;
                mediaItemList.Add(mediaItem);

                return new RepositoryActionResult<MediaItem>(mediaItem, RepositoryActionStatus.Created);
            }
            catch(Exception ex)
            {
                return new RepositoryActionResult<MediaItem>(null, RepositoryActionStatus.Error, ex);
            }
        }

        public IQueryable<MediaItem> GetMediaItems()
        {
            return BuildMediaItemsList().AsQueryable();
        }

        public MediaItem GetMediaItem(int id)
        {
            return BuildMediaItemsList().Where(p => p.Id == id).FirstOrDefault();
        }

        public RepositoryActionResult<MediaItem> UpdateMediaItem(MediaItem mediaItem)
        {
            try
            {
                var mediaItemList = BuildMediaItemsList();
                var mediaItemToUpdate = mediaItemList.Where(p => p.Id == mediaItem.Id).FirstOrDefault();
                mediaItemList[mediaItemList.IndexOf(mediaItemToUpdate)] = mediaItem;

                return new RepositoryActionResult<MediaItem>(mediaItem, RepositoryActionStatus.Updated);
            }
            catch(Exception ex)
            {
                return new RepositoryActionResult<MediaItem>(null, RepositoryActionStatus.Error, ex);
            }
        }

        private List<MediaItem> BuildMediaItemsList()
        {
            var mediaItems = new List<MediaItem>
            {
                new MediaItem()
                {
                    Id = 1,
                    Name = "Media Item 1"
                },
                new MediaItem()
                {
                    Id = 2,
                    Name = "Media Item 2"
                }
            }
        }
    } 
}
