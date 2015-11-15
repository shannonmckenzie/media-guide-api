using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaGuide.Repository.Entities;

namespace MediaGuide.Repository
{
     public class SharedChannelFactory
    {
        public DTO.SharedChannel CreateSharedChannel(SharedChannel sharedChannel)
        {
            return new DTO.SharedChannel()
            {
                Id = sharedChannel.Id,
                UserId = sharedChannel.UserId,
                SharedChannelId = sharedChannel.Name
            };
        }

        public SharedChannel CreateSharedChannel(DTO.SharedChannel sharedChannel)
        {

            return new SharedChannel()
            {
                Id = sharedChannel.Id,
                UserId = sharedChannel.UserId,
                Name = sharedChannel.SharedChannelId
            };
        }
    }
}
