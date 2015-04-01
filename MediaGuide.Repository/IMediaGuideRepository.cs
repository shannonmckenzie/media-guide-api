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

    }
}
