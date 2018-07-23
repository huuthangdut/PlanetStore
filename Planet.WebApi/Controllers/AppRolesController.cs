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
using System.Web.Http.Description;
using System.Web.Script.Serialization;

namespace Planet.WebApi.Controllers
{
    [RoutePrefix("api/roles")]
    //[Authorize]
    //[Permission(Function = FunctionName.Role)]
    public class AppRolesController : BaseApiController
    {
        private readonly IPermissionService _permissionService;

        public AppRolesController(
            IPermissionService permissionService,
            IErrorService errorService,
            IUnitOfWork unitOfWork) : base(errorService, unitOfWork)
        {
            _permissionService = permissionService;
        }

        /// <summary>
        /// Get a specific role by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpGet]
        //[Permission(Action = ActionName.CanRead)]
        public IHttpActionResult Get(string id)
        {
            return CreateResponse(() =>
            {
                var model = RoleManager.FindById(id);
                if (model == null)
                    return Content(HttpStatusCode.NotFound, ApiMessage.RoleNotFound);

                var viewModel = Mapper.Map<AppRole, AppRoleDto>(model);
                viewModel.Permissions = Mapper.Map<IEnumerable<PermissionDto>>(_permissionService.GetPermissionsByRoleId(id));

                return Ok(viewModel);
            });
        }

        /// <summary>
        /// Create a new role.
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(AppRoleDto))]
        //[Permission(Action = ActionName.CanCreate)]
        public IHttpActionResult Create([FromBody] AppRoleDto role)
        {
            return CreateResponse(() =>
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var model = Mapper.Map<AppRoleDto, AppRole>(role);

                RoleManager.Create(model);

                //add new permissions for role
                foreach (var permission in role.Permissions)
                {
                    _permissionService.Add(new Permission
                    {
                        RoleId = model.Id,
                        FunctionId = permission.FunctionId,
                        CanRead = permission.CanRead,
                        CanUpdate = permission.CanUpdate,
                        CanDelete = permission.CanDelete,
                        CanCreate = permission.CanCreate
                    });
                }

                UnitOfWork.Commit();


                return Created(new Uri(Request.RequestUri + "/" + model.Id), role);
            });
        }

        /// <summary>
        /// Get all roles.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [Route("")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<AppRoleDto>))]
        //[Permission(Action = ActionName.CanRead)]
        public IHttpActionResult GetAll(string filter = null)
        {
            return CreateResponse(() =>
            {
                var model = RoleManager.Roles;
                if (!string.IsNullOrEmpty(filter))
                    model = model.Where(r => r.Name.Contains(filter) || r.Description.Contains(filter));

                var viewModel = Mapper.Map<IEnumerable<AppRole>, IEnumerable<AppRole>>(model);

                return Ok(viewModel);

            });
        }

        /// <summary>
        /// Get all roles with paging.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        [Route("paging")]
        [HttpGet]
        //[Permission(Action = ActionName.CanRead)]
        public IHttpActionResult GetAllWithPaging(int pageIndex = 1, int pageSize = 20, string filter = null)
        {
            return CreateResponse(() =>
            {
                var model = RoleManager.Roles;
                if (!string.IsNullOrEmpty(filter))
                    model = model.Where(r => r.Name.Contains(filter) || r.Description.Contains(filter));

                int totalItems = model.Count();
                model = model.OrderBy(r => r.Name).Skip((pageIndex - 1) * pageSize).Take(pageSize);

                var viewModel = Mapper.Map<IEnumerable<AppRole>, IEnumerable<AppRoleDto>>(model);

                var pagedResult = new PagedResult<AppRoleDto>()
                {
                    Items = viewModel,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    TotalItems = totalItems
                };

                return Ok(pagedResult);
            });
        }

        [Route("{id}")]
        [HttpPut]
        //[Permission(Action = ActionName.CanUpdate)]
        public IHttpActionResult Edit(string id, [FromBody] AppRoleDto role)
        {
            return CreateResponse(() =>
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var model = RoleManager.FindById(id);
                if (model == null)
                    return Content(HttpStatusCode.NotFound, ApiMessage.RoleNotFound);

                Mapper.Map(role, model);
                RoleManager.Update(model);

                // update permisison for role
                foreach (var permission in role.Permissions)
                {
                    var permissionInDb = _permissionService.Get(permission.RoleId, permission.FunctionId);
                    permissionInDb.CanCreate = permission.CanCreate;
                    permissionInDb.CanDelete = permission.CanDelete;
                    permissionInDb.CanRead = permission.CanRead;
                    permissionInDb.CanUpdate = permission.CanUpdate;
                    _permissionService.Update(permissionInDb);
                }

                UnitOfWork.Commit();

                return StatusCode(HttpStatusCode.NoContent);
            });
        }

        /// <summary>
        /// Delete a specific role by id.
        /// </summary>
        /// <param name="id">The id of role.</param>
        [Route("{id}")]
        [HttpDelete]
        //[Permission(Action = ActionName.CanDelete)]
        public IHttpActionResult Delete(string id)
        {
            return CreateResponse(() =>
            {
                var model = RoleManager.FindById(id);
                if (model == null)
                    return Content(HttpStatusCode.NotFound, ApiMessage.RoleNotFound);

                RoleManager.Delete(model);

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
                    var model = RoleManager.FindById(id);
                    RoleManager.Delete(model);
                }

                return StatusCode(HttpStatusCode.NoContent);
            });
        }

        private AppRoleManager RoleManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().GetUserManager<AppRoleManager>();
            }
        }
    }
}
