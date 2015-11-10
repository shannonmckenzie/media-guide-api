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

        public IHttpActionResult Get(int id)
        {
            try 
	        {	        
	        	var channelGroup = _repository.GetChannelGroup(id);
                        if(channelGroup == null){
                            return NotFound();
                        }
                        else{
                            return Ok(_channelGroupFactory.CreateChannelGroup(channelGroup));
                        }
	        }
	        catch (Exception)
	        {
	        	return InternalServerError();
	        }
        }

        public IHttpActionResult post([FromBody] DTO.ChannelGroup channelGroup)
        {
            try 
	        {	        
	        	if(channelGroup == null)
                {
                    return BadRequest();
                }

                var chGroup = _channelGroupFactory.CreateChannelGroup(channelGroup);
                var result = _repository.InsertChannel(chGroup);

                if(result.Status == RepositoryActionStatus.Created)
                {
                    var newChannelGroup = _channelGroupFactory.CreateChannelGroup(result.Entity);
                    return Created(Request.RequestUri + "/" + newChannelGroup.Id.ToString(),newChannelGroup);
                }

                return BadRequest();
	        }
	        catch (Exception)
	        {
	        	return InternalServerError();
	        }
        }

        public IHttpActionResult put([FromBody] DTO.ChannelGroup channelGroup)
        {
            try 
	        {	        
	        	if(channelGroup == null)
                {
                    return BadRequest();
                }

                var chGroup = _channelGroupFactory.CreateChannelGroup(channelGroup);
                var result = _repository.UpdateChannelGroup(chGroup);

                if(result.Status == RepositoryActionStatus.Updated)
                {
                    var updatedChannelGroup = _channelGroupFactory.CreateChannelGroup(result.Entity);

                    return Ok(updatedChannelGroup);
                }
                else if(result.Status == RepositoryActionStatus.NotFound)
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

        public IHttpActionResult patch(int id,[FromBody] JsonPatchDocument<DTO.ChannelGroup> channelGroupPatchDocument)
        {
            try
            {
                if (channelGroupPatchDocument == null)
                {
                    return BadRequest();
                }

                var channelGroup = _repository.GetChannelGroup(id);
                if (channelGroup == null)
                {
                    return NotFound();
                }

                // map
                var chGroup = _channelGroupFactory.CreateChannelGroup(channelGroup);

                channelGroupPatchDocument.ApplyTo(chGroup);

                var result = _repository.UpdateChannelGroup(_channelGroupFactory.CreateChannelGroup(chGroup));

                if (result.Status == RepositoryActionStatus.Updated)
                {
                    // map to dto
                    var patchedChannelGroup = _channelGroupFactory.CreateChannelGroup(result.Entity);
                    return Ok(patchedChannelGroup);
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
	            var result = _repository.DeleteChannelGroup(id);
	
                if(result.Status == RepositoryActionStatus.Deleted)
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
                else if(result.Status == RepositoryActionStatus.NotFound)
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