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
                    return Ok(_sharedChannelFactory.CreateSharedChannelGroup(sharedChannel));
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
                    BadRequest();
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
                InternalServerError();
            }
        }

        public IHttpActionResult put([FromBody] DTO.SharedChannel sharedChannel){

        }

        public IHttpActionResult patch(int id,[FromBody] JsonPatchDocument<DTO.SharedChannel> sharedChannel){

        }

        public IHttpActionResult delete(int id){

        }
    }
}
