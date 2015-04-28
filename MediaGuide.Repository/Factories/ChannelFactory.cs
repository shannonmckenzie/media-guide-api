using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaGuide.Repository.Entities;

namespace MediaGuide.Repository
{
    public class ChannelFactory
    {
        public DTO.Channel CreateChannel(Channel channel)
        {
            return new DTO.Channel()
            {
                Id = channel.Id,
                Name = channel.Name,
                Description = channel.Description,
                Type = channel.Type,
                User = channel.User
            };
        }

        public Channel CreateChannel(DTO.Channel channel)
        {
            return new Channel()
            {
                Id = channel.Id,
                Name = channel.Name,
                Description = channel.Description,
                Type = channel.Type,
                User = channel.User
            };
        }
    }
}
