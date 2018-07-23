using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Planet.Data.Core;
using Planet.Data.Core.Domain;
using Planet.Infrastructure.Core;
using Planet.Infrastructure.Identity;
using Planet.Services.Core;
using Planet.WebApi.Common;
using Planet.WebApi.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace Planet.WebApi.Controllers
{
    [RoutePrefix("api/users")]
    //[Authorize]
    //    [Permission(Function = FunctionName.User)]
    public class AppUsersController : BaseApiController
    {
        public AppUsersController(IErrorService errorService, IUnitOfWork unitOfWork) : base(errorService, unitOfWork)
        {
        }

        /// <summary>
        /// Creates the specified view model.
        /// </summary>
        /// <param name="user">The view model.</param>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        //        [Permission(Action = ActionName.CanCreate)]
        public IHttpActionResult Create([FromBody] AppUserDto user)
        {
            return CreateResponse(() =>
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var model = Mapper.Map<AppUserDto, AppUser>(user);

                UserManager.Create(model, user.Password);

                if (user.Roles.Any())
                {
                    var modelDb = UserManager.FindByEmail(user.Email);
                    UserManager.AddToRoles(modelDb.Id, user.Roles.ToArray());
                    user.Id = modelDb.Id;
                }

                return Created(new Uri(Request.RequestUri + "/" + user.Id), user);
            });
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        [Route("")]
        [HttpGet]
        //        [Permission(Action = ActionName.CanRead)]
        public IHttpActionResult GetAll(string filter = null)
        {
            return CreateResponse(() =>
            {
                var model = UserManager.Users;
                if (!string.IsNullOrEmpty(filter))
                    model = model.Where(u => u.UserName.Contains(filter) || u.Email.Contains(filter) || u.LastName.Contains(filter));

                var viewModel = Mapper.Map<IEnumerable<AppUser>, IEnumerable<AppUserDto>>(model);

                return Ok(viewModel);

            });
        }

        /// <summary>
        /// Gets all with paging.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        [Route("paging")]
        [HttpGet]
        //        [Permission(Action = ActionName.CanRead)]
        public IHttpActionResult GetAllWithPaging(int pageIndex = 1, int pageSize = 20, string filter = null)
        {
            return CreateResponse(() =>
            {
                var model = UserManager.Users;
                if (!string.IsNullOrEmpty(filter))
                    model = model.Where(u => u.UserName.Contains(filter) || u.Email.Contains(filter) || u.LastName.Contains(filter));

                int totalItems = model.Count();
                model = model.OrderBy(u => u.Email).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                var viewModel = Mapper.Map<IEnumerable<AppUser>, IEnumerable<AppUserDto>>(model);

                var pagedResult = new PagedResult<AppUserDto>()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    Items = viewModel,
                    TotalItems = totalItems
                };

                return Ok(pagedResult);
            });
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpGet]
        //        [Permission(Action = ActionName.CanRead)]
        public IHttpActionResult Get(string id)
        {
            return CreateResponse(() =>
            {
                var model = UserManager.FindById(id);
                if (model == null)
                    return Content(HttpStatusCode.NotFound, ApiMessage.UserNotFound);

                var viewModel = Mapper.Map<AppUser, AppUserDto>(model);
                var roles = UserManager.GetRoles(id);
                viewModel.Roles = roles;

                return Ok(viewModel);
            });

        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The view model.</param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpPut]
        //        [Permission(Action = ActionName.CanUpdate)]
        public IHttpActionResult Edit(string id, [FromBody] AppUserDto user)
        {
            return CreateResponse(() =>
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var model = UserManager.FindById(id);

                Mapper.Map(user, model);

                UserManager.Update(model);

                if (user.Roles.Any())
                {
                    var userRoles = UserManager.GetRoles(model.Id);
                    UserManager.RemoveFromRoles(model.Id, userRoles.ToArray());
                    UserManager.AddToRoles(model.Id, user.Roles.ToArray());
                }

                return Ok();
            });

        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpDelete]
        //        [Permission(Action = ActionName.CanDelete)]
        public IHttpActionResult Delete(string id)
        {
            return CreateResponse(() =>
            {
                var model = UserManager.FindById(id);
                if (model == null)
                    return Content(HttpStatusCode.NotFound, ApiMessage.UserNotFound);

                UserManager.Delete(model);

                return StatusCode(HttpStatusCode.NoContent);
            });
        }

        [Route("")]
        [HttpDelete]
        public IHttpActionResult DeleteMulti(string ids)
        {
            return CreateResponse(() =>
            {
                var checkedIds = new JavaScriptSerializer().Deserialize<List<string>>(ids);

                foreach (var id in checkedIds)
                {
                    var model = UserManager.FindById(id);
                    UserManager.Delete(model);
                }

                UnitOfWork.Commit();

                return StatusCode(HttpStatusCode.NoContent);
            });
        }

        [Route("active")]
        [HttpPost]
        public IHttpActionResult Active([FromBody] string ids)
        {
            return CreateResponse(() =>
            {
                var checkedIds = new JavaScriptSerializer().Deserialize<List<string>>(ids);

                foreach (var id in checkedIds)
                {
                    var model = UserManager.FindById(id);
                    model.Status = true;
                    UserManager.Update(model);
                }

                UnitOfWork.Commit();

                return StatusCode(HttpStatusCode.NoContent);
            });
        }

        [Route("deactive")]
        [HttpPost]
        public IHttpActionResult Deactive([FromBody] string ids)
        {
            return CreateResponse(() =>
            {
                var checkedIds = new JavaScriptSerializer().Deserialize<List<string>>(ids);

                foreach (var id in checkedIds)
                {
                    var model = UserManager.FindById(id);
                    model.Status = false;
                    UserManager.Update(model);
                }

                UnitOfWork.Commit();

                return StatusCode(HttpStatusCode.NoContent);
            });
        }


        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
    }


}
