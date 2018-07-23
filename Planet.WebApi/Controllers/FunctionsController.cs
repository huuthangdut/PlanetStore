using AutoMapper;
using Planet.Data.Core;
using Planet.Infrastructure.Core;
using Planet.Services.Core;
using Planet.WebApi.Common;
using Planet.WebApi.Dtos.Auth;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace Planet.WebApi.Controllers
{
    [RoutePrefix("api/functions")]
    //    [Authorize]
    public class FunctionsController : BaseApiController
    {
        private readonly IFunctionService _functionService;

        public FunctionsController(IFunctionService functionService, IErrorService errorService, IUnitOfWork unitOfWork) : base(errorService, unitOfWork)
        {
            _functionService = functionService;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return CreateResponse(() =>
            {
                //                var model = User.IsInRole(RoleName.Admin)
                //                    ? _functionService.GetAll()
                //                    : _functionService.GetSpecifiedByUser(User.Identity.GetUserId());
                var model = _functionService.GetAll();

                return Ok(Mapper.Map<IEnumerable<FunctionDto>>(model));

            });
        }

        [Route("{id:alpha}")]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return CreateResponse(() =>
            {
                var model = _functionService.GetById(id);
                if (model == null)
                    return Content(HttpStatusCode.NotFound, ApiMessage.FunctionNotFound);

                return Ok(Mapper.Map<FunctionDto>(model));
            });
        }

    }
}
