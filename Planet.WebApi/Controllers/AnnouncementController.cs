using AutoMapper;
using Microsoft.AspNet.Identity;
using Planet.Data.Core;
using Planet.Data.Core.Domain;
using Planet.Infrastructure.Core;
using Planet.Services.Core;
using Planet.WebApi.Dtos.Notification;
using Planet.WebApi.SignalR;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace Planet.WebApi.Controllers
{
    [RoutePrefix("api/announcements")]
    public class AnnouncementController : BaseApiController
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService, IErrorService errorService, IUnitOfWork unitOfWork) : base(errorService, unitOfWork)
        {
            _announcementService = announcementService;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll(int pageIndex, int pageSize)
        {
            return CreateResponse(() =>
            {
                var announcements = _announcementService.GetAll(pageIndex, pageSize, out int totalItems);
                var pagedResult = new PagedResult<AnnouncementDto>
                {
                    Items = Mapper.Map<IEnumerable<AnnouncementDto>>(announcements),
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    TotalItems = totalItems
                };

                return Ok(pagedResult);
            });
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            return CreateResponse(() =>
            {
                var announcement = _announcementService.GetById(id);
                if (announcement == null)
                    return NotFound();

                return Ok(Mapper.Map<AnnouncementDto>(announcement));
            });
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create(AnnouncementDto announcement)
        {
            return CreateResponse(() =>
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                announcement.DateCreated = DateTime.Now;

                var model = Mapper.Map<Announcement>(announcement);
                _announcementService.Add(model);

                UnitOfWork.Commit();

                announcement.Id = model.Id;

                PlanetHub.PushToAllUsers(announcement, null);

                return Created(new Uri(Request.RequestUri + "/" + announcement.Id), announcement);
            });
        }

        [Route("markasread/{id}")]
        [HttpPost]
        public IHttpActionResult MarkAsRead(int id)
        {
            return CreateResponse(() =>
            {
                if (_announcementService.GetById(id) == null)
                    return NotFound();

                _announcementService.MarkAsRead(User.Identity.GetUserId(), id);
                UnitOfWork.Commit();

                return Ok();
            });
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return CreateResponse(() =>
            {
                var model = _announcementService.GetById(id);
                if (model == null)
                    return NotFound();

                _announcementService.Delete(model);
                UnitOfWork.Commit();
                return StatusCode(HttpStatusCode.NoContent);
            });
        }
    }
}
