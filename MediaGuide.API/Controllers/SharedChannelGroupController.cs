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
    public class SharedChannelGroupController : ApiController
    {
        IMediaGuideRepository _repository;
        SharedChannelGroupFactory _sharedChannelGroupFactory = new SharedChannelGroupFactory();

        public SharedChannelGroupController()
        {
            _repository = new MediaGuideRepository();
        }

        public IHttpActionResult Get()
        {
            return Ok(_repository.GetSharedChannelGroups());
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var sharedChannelGroup = _repository.GetSharedChannelGroup(id);
                if (sharedChannelGroup == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_sharedChannelGroupFactory.CreateSharedChannelGroup(sharedChannelGroup));
                }
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
        [HttpPost]
        public IHttpActionResult Post([FromBody] DTO.SharedChannelGroup sharedChannelGroup)
        {
            try
            {
                if (sharedChannelGroup == null)
                {
                    return BadRequest();
                }

                var shrdChnl = _sharedChannelGroupFactory.CreateSharedChannelGroup(sharedChannelGroup);
                var result = _repository.InsertSharedChannelGroup(shrdChnl);

                if (result.Status == RepositoryActionStatus.Created)
                {
                    var newSharedChannelGroup = _sharedChannelGroupFactory.CreateSharedChannelGroup(result.Entity);
                    return Created(Request.RequestUri + "/" + newSharedChannelGroup.Id.ToString(), newSharedChannelGroup); 
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Put([FromBody] DTO.SharedChannelGroup sharedChannelGroup)
        {
            try
            {
                if (sharedChannelGroup == null)
                {
                    return BadRequest();
                }

                var shrdChnlGrp = _sharedChannelGroupFactory.CreateSharedChannelGroup(sharedChannelGroup);
                var result = _repository.UpdateSharedChannelGroup(shrdChnlGrp);
                if (result.Status == RepositoryActionStatus.Updated)
                {
                    var updatedExpenseGroup = _sharedChannelGroupFactory.CreateSharedChannelGroup(result.Entity);

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
        public IHttpActionResult Patch(int id, [FromBody] JsonPatchDocument<DTO.SharedChannelGroup> sharedChannelGroupPatchDocument)
        {
            try
            {
                if (sharedChannelGroupPatchDocument == null)
                {
                    return BadRequest();
                }

                var sharedChannelGroup = _repository.GetSharedChannelGroup(id);
                if (sharedChannelGroup == null)
                {
                    return NotFound();
                }

                // map
                var shrdChnl = _sharedChannelGroupFactory.CreateSharedChannelGroup(sharedChannelGroup);

                sharedChannelGroupPatchDocument.ApplyTo(shrdChnl);

                var result = _repository.UpdateSharedChannelGroup(_sharedChannelGroupFactory.CreateSharedChannelGroup(shrdChnl));

                if (result.Status == RepositoryActionStatus.Updated)
                {
                    // map to dto
                    var patchedChannel = _sharedChannelGroupFactory.CreateSharedChannelGroup(result.Entity);
                    return Ok(patchedChannel);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }

        }
        //****did boths gets and post and put and patch, do delete************then do other two controllers////
    }
}