using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaGuide.Repository.Entities;

namespace MediaGuide.Repository.Factories
{
    class ChannelGroupFactory
    {
        public DTO.ChannelGroup CreateChannelGroup(ChannelGroup channelGroup)
        {
            return new DTO.ChannelGroup()
            {
                Id = channelGroup.Id,
                Name = channelGroup.Name,
                Description = channelGroup.Description
            };
        }

        public ChannelGroup CreateChannelGroup(DTO.ChannelGroup channelGroup)
        {
            return new ChannelGroup()
            {
                Id = channelGroup.Id,
                Name = channelGroup.Name,
                Description = channelGroup.Description
            };
        }
    }
}
