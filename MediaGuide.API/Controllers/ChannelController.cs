using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using Marvin.JsonPatch;
using MediaGuide.Repository;

namespace MediaGuide.API.Controllers
{
    public class ChannelController : ApiController
    {
        IMediaGuideRepository _repository;
        ChannelFactory _channelFactory = new ChannelFactory();

        public ChannelController()
        {
            _repository = new MediaGuideRepository();
        }

        public IHttpActionResult Get()
        {
            return Ok(_repository.GetChannels());
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var channel = _repository.GetChannel(id);
                if (channel == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_channelFactory.CreateChannel(channel));
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] DTO.Channel channel)
        {
            try
            {
                if (channel == null)
                {
                    return BadRequest();
                }

                var ch = _channelFactory.CreateChannel(channel);
                var result = _repository.InsertChannel(ch);

                if (result.Status == RepositoryActionStatus.Created)
                {
                    var newChannel = _channelFactory.CreateChannel(result.Entity);
                    return Created(Request.RequestUri + "/" + newChannel.Id.ToString(), newChannel);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Put([FromBody] DTO.Channel channel)
        {
            try
            {
                if (channel == null)
                {
                    return BadRequest();
                }

                var ch = _channelFactory.CreateChannel(channel);
                var result = _repository.UpdateChannel(ch);

                if (result.Status == RepositoryActionStatus.Updated)
                {
                    var updatedExpenseGroup = _channelFactory.CreateChannel(result.Entity);

                    return Ok(updatedExpenseGroup);
                }
                else if (result.Status == RepositoryActionStatus.NotFound)
                {
                    return NotFound();
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPatch]
        public IHttpActionResult Patch(int id, [FromBody] JsonPatchDocument<DTO.Channel> channelPatchDocument)
        {
            try
            {
                if (channelPatchDocument == null)
                {
                    return BadRequest();
                }

                var channel = _repository.GetChannel(id);
                if (channel == null)
                {
                    return NotFound();
                }

                // map
                var ch = _channelFactory.CreateChannel(channel);

                channelPatchDocument.ApplyTo(ch);

                var result = _repository.UpdateChannel(_channelFactory.CreateChannel(ch));

                if (result.Status == RepositoryActionStatus.Updated)
                {
                    // map to dto
                    var patchedChannel = _channelFactory.CreateChannel(result.Entity);
                    return Ok(patchedChannel);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }

        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                var result = _repository.DeleteChannel(id);

                if (result.Status == RepositoryActionStatus.Deleted)
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
                else if (result.Status == RepositoryActionStatus.NotFound)
                {
                    return NotFound();
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
