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
    public class SharedChannelController : ApiController
    {
        IMediaGuideRepository _repository;
        SharedChannelFactory _sharedChannelFactory = new SharedChannelFactory();

        public SharedChannelController()
        {
            _repository = new MediaGuideRepository();
        }
        public IHttpActionResult Get(){
            return Ok(_repository.GetSharedChannels());
        }

        public IHttpActionResult Get(int id){
            try
            {
                var sharedChannel = _repository.GetSharedChannel(id);
                if (sharedChannel == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_sharedChannelFactory.CreateSharedChannel(sharedChannel));
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult post([FromBody] DTO.SharedChannel sharedChannel){
            try
            {
                if (sharedChannel == null)
                {
                   return BadRequest();
                }

                var sc = _sharedChannelFactory.CreateSharedChannel(sharedChannel);
                var result = _repository.InsertSharedChannel(sc);

                if (result.Status == RepositoryActionStatus.Created)
                {
                    var newSharedChannel = _sharedChannelFactory.CreateSharedChannel(result.Entity);
                    return Created(Request.RequestUri + "/" + newSharedChannel.Id.ToString(), newSharedChannel);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult put([FromBody] DTO.SharedChannel sharedChannel){
            try
            {
                if (sharedChannel == null)
                {
                    return BadRequest();
                }

                var shdCh = _sharedChannelFactory.CreateSharedChannel(sharedChannel);
                var result = _repository.UpdateSharedChannel(shdCh);

                if (result.Status == RepositoryActionStatus.Updated)
                {
                    var updatedSharedChannel = _sharedChannelFactory.CreateSharedChannel(result.Entity);
                    return Ok(updatedSharedChannel);
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

        public IHttpActionResult patch(int id,[FromBody] JsonPatchDocument<DTO.SharedChannel> sharedChannelPatchDocument){
            try
            {
                if (sharedChannelPatchDocument == null)
                {
                    return BadRequest();
                }

                var sharedChannel = _repository.GetSharedChannel(id);
                if (sharedChannel == null)
                {
                    return NotFound();
                }

                var shdCh = _sharedChannelFactory.CreateSharedChannel(sharedChannel);
                sharedChannelPatchDocument.ApplyTo(shdCh);

                var result = _repository.UpdateSharedChannel(_sharedChannelFactory.CreateSharedChannel(shdCh));

                if (result.Status == RepositoryActionStatus.Updated)
                {
                    var patchedSharedChannel = _sharedChannelFactory.CreateSharedChannel(result.Entity);
                    return Ok(patchedSharedChannel);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult delete(int id){
            try
            {
                var result = _repository.DeleteSharedChannel(id);

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
