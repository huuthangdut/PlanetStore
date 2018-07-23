using AutoMapper;
using Planet.Data.Core;
using Planet.Data.Core.Domain;
using Planet.Infrastructure.Core;
using Planet.Services.Core;
using Planet.WebApi.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Planet.WebApi.Dtos.ECommerce;

namespace Planet.WebApi.Controllers
{
    [RoutePrefix("api/categories")]
    //    [Authorize]
    //    [Permission(Function = FunctionName.ProductCategory)]
    public class ProductCategoriesController : BaseApiController
    {
        private readonly IProductCategoryService _categoryService;

        public ProductCategoriesController(IProductCategoryService categoryService, IErrorService errorService, IUnitOfWork unitOfWork) : base(errorService, unitOfWork)
        {
            _categoryService = categoryService;
        }

        [Route("paging")]
        [HttpGet]
        //        [Permission(Action = ActionName.CanRead)]
        public IHttpActionResult GetAllWithPaging(int pageIndex = 1, int pageSize = 20, string filter = null)
        {
            return CreateResponse(() =>
            {
                var model = _categoryService.GetAllWithPaging(pageIndex, pageSize, out int totalItems, filter);

                var viewModel = Mapper.Map<IEnumerable<ProductCategoryDto>>(model);

                var pagedResult = new PagedResult<ProductCategoryDto>()
                {
                    Items = viewModel,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    TotalItems = totalItems,
                };
                return Ok(pagedResult);
            });
        }

        [Route("")]
        [HttpGet]
        //        [Permission(Action = ActionName.CanRead)]
        public IHttpActionResult GetAll(string keyword = null)
        {
            return CreateResponse(() =>
            {
                var model = _categoryService.GetAll(keyword);
                var viewModel = Mapper.Map<IEnumerable<ProductCategoryDto>>(model);

                return Ok(viewModel);

            });
        }

        [Route("{id:int}")]
        [HttpGet]
        //        [Permission(Action = ActionName.CanRead)]
        public IHttpActionResult Get(int id)
        {
            return CreateResponse(() =>
            {
                var model = _categoryService.GetById(id);
                if (model == null)
                    return Content(HttpStatusCode.NotFound, ApiMessage.CategoryNotFound);

                var viewModel = Mapper.Map<ProductCategoryDto>(model);

                return Ok(viewModel);
            });
        }

        [Route("")]
        [HttpPost]
        //        [Permission(Action = ActionName.CanCreate)]
        public IHttpActionResult Create(ProductCategoryDto category)
        {
            return CreateResponse(() =>
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var model = Mapper.Map<ProductCategory>(category);

                _categoryService.Add(model);
                UnitOfWork.Commit();

                category.Id = model.Id;
                category.CreatedDate = model.DateCreated;

                return Created(new Uri(Request.RequestUri + "/" + category.Id), category);
            });
        }

        [Route("{id:int}")]
        [HttpPut]
        //        [Permission(Action = ActionName.CanUpdate)]
        public IHttpActionResult Edit(int id, [FromBody]ProductCategoryDto category)
        {
            return CreateResponse(() =>
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var model = _categoryService.GetById(id);
                if (model == null)
                    return Content(HttpStatusCode.NotFound, ApiMessage.CategoryNotFound);

                Mapper.Map(category, model);
                _categoryService.Update(model);

                UnitOfWork.Commit();

                category.DateUpdated = model.DateUpdated;

                return Ok();
            });
        }

        [Route("{id:int}")]
        [HttpDelete]
        //        [Permission(Action = ActionName.CanDelete)]
        public IHttpActionResult Delete(int id)
        {
            return CreateResponse(() =>
            {
                if (_categoryService.GetById(id) == null)
                    return NotFound();

                _categoryService.Delete(id);
                UnitOfWork.Commit();

                return Ok();
            });
        }



    }
};