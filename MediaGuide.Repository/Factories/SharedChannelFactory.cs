using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaGuide.Repository.Entities;

namespace MediaGuide.Repository.Factories
{
    class SharedChannelFactory
    {
        public DTO.SharedChannelGroup CreateSharedChannelGroup(SharedChannelGroup sharedChannelGroup)
        {
            return new DTO.SharedChannelGroup()
            {
                Id = sharedChannelGroup.Id,
                UserId = sharedChannelGroup.UserId,
                ChannelGroupId = sharedChannelGroup.ChannelGroupId
            };
        }

        public SharedChannelGroup CreateSharedChannelGroup(DTO.SharedChannelGroup sharedChannelGroup)
        {

            return new SharedChannelGroup()
            {
                Id = sharedChannelGroup.Id,
                UserId = sharedChannelGroup.UserId,
                ChannelGroupId = sharedChannelGroup.ChannelGroupId
            };
        }
    }
}
