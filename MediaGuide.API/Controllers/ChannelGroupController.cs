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
    public class ChannelGroupController: ApiController
    {
        IMediaGuideRepository _repository;
        ChannelGroupFactory _channelGroupFactory = new ChannelGroupFactory();

        public channelGroupController()
        {
            _repository = new MediaGuideRepository();
        }
        public IHttpActionResult Get(){
            return Ok(_repository.GetChannelGroups());
        }

        public IHttpActionResult Get(int id){

        }

        public IHttpActionResult post([FromBody] DTO.ChannelGroup channelGroup){

        }

        public IHttpActionResult put([FromBody] DTO.ChannelGroup channelGroup){

        }

        public IHttpActionResult patch(int id,[FromBody] JsonPatchDocument<DTO.ChannelGroup> channelGroup){

        }

        public IHttpActionResult delete(int id){

        }
    }
}