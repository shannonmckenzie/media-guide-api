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
    public class MediaItemController: ApiController
    {
        IMediaGuideRepository _repository;
        MediaItemFactory mediaItemFactory = new MediaItemFactory();

        public channelGroupController()
        {
            _repository = new MediaGuideRepository();
        }
        public IHttpActionResult Get(){
            return Ok(_repository.GetMediaItems());
        }

        public IHttpActionResult Get(int id){

        }

        public IHttpActionResult post([FromBody] DTO.MediaItem mediaItem){

        }

        public IHttpActionResult put([FromBody] DTO.MediaItem mediaItem){

        }

        public IHttpActionResult patch(int id,[FromBody] JsonPatchDocument<DTO.MediaItem> mediaItem){

        }

        public IHttpActionResult delete(int id){

        }
    }
}