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
            try 
	        {	        
	            var mediaItem = _repository.GetMediaItem(id);
	            if(mediaItem == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_mediaItemFactory.CreateMediaItem(mediaItem));
                }
	        }
	        catch (Exception)
	        {
	        	return InternalServerError();
	        }
        }

        public IHttpActionResult post([FromBody] DTO.MediaItem mediaItem){
            try 
	        {	        
	        	if(mediaItem == null)
                {
                    return BadRequest();
                }

                var mdItm = _mediaItemFactory.CreateMediaItem(mediaItem);
                var result = _repository.InsertMediaItem(mdItem);

                if(result.Status == RepositoryActionStatus.Created)
                {
                    var newMediaItem = _mediaItemFactory.CreateMediaItem(result.Entity);
                    return Created(Request.RequestUri + "/" + newMediaItem.Id.ToString(), newMediaItem);
                }

                return BadRequest();
	        }
	        catch (Exception)
	        {
	        	return InternalServerError();
	        }
        }

        public IHttpActionResult put([FromBody] DTO.MediaItem mediaItem)
        {
            try
            {
                if(mediaItem == null)
                {
                    return BadRequest();
                }

                var mdItm = _mediaItemFactory.CreateMediaItem(mediaItem);
                var result = _repository.UpdateMediaItem(mdItm);

                if(result.Status = RepositoryActionStatus.Updated)
                {
                    var updatedMediaItem = _mediaItemFactory.CreateMediaItem(result.Entity);

                    return Ok(updatedMediaItem);
                }
                else if(result.Status = RepositoryActionStatus.NotFound)
                {
                    return NotFound();
                }
                return BadRequest();
            }
            catch(Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult patch(int id,[FromBody] JsonPatchDocument<DTO.MediaItem> mediaItemPatchDocument)
        {
            try
            {
                if (mediaItemPatchDocument == null)
                {
                    return BadRequest();
                }

                var mediaItem = _repository.GetMediaItem(id);
                if (mediaItem == null)
                {
                    return NotFound();
                }

                // map
                var mdItem = _mediaItemFactory.CreateMediaItem(mediaItem);

                mediaItemPatchDocument.ApplyTo(mdItem);

                var result = _repository.UpdateMediaItem(_mediaItemFactory.CreateMediaItem(mdItm));

                if (result.Status == RepositoryActionStatus.Updated)
                {
                    // map to dto
                    var patchedMediaItem = _mediaItemFactory.CreateMediaItem(result.Entity);
                    return Ok(patchedMediaItem);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult delete(int id)
        {
            try
            {
                var result = _repository.DeleteMediaItem(id);

                if(result.Status == RepositoryActionStatus.Deleted)
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
                else if(result.Status = RepositoryActionStatus.NotFound)
                {
                    return NotFound();
                }
                return BadRequest();
            }
            catch(Exception)
            {
                return InternalServerError();
            }
        }
    }
}