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
    }
}
