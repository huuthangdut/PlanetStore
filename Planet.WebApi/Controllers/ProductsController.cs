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
using System.Web.Script.Serialization;
using Planet.WebApi.Dtos.ECommerce;

namespace Planet.WebApi.Controllers
{
    [RoutePrefix("api/products")]
    //    [Authorize]
    //    [Permission(Function = FunctionName.Product)]
    public class ProductsController : BaseApiController
    {
        private readonly IProductService _productService;
        private readonly IProductImageService _productImageService;

        public ProductsController(IProductService productService,
            IProductImageService productImageService,
            IErrorService errorService,
            IUnitOfWork unitOfWork) : base(errorService, unitOfWork)
        {
            _productService = productService;
            _productImageService = productImageService;
        }


        [Route("")]
        [HttpGet]
        //        [Permission(Action = ActionName.CanRead)]
        public IHttpActionResult GetAll(int pageIndex = 1, int pageSize = 20, string filter = "")
        {
            return CreateResponse(() =>
            {
                var model = _productService.GetAll(pageIndex, pageSize, out int totalItems, filter);

                var viewModel = Mapper.Map<IEnumerable<ProductDto>>(model);

                var pagedResult = new PagedResult<ProductDto>()
                {
                    Items = viewModel,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    TotalItems = totalItems
                };

                return Ok(pagedResult);
            });
        }

        [Route("{id:int:min(1)}")]
        [HttpGet]
        //        [Permission(Action = ActionName.CanRead)]
        public IHttpActionResult Get(int id)
        {
            return CreateResponse(() =>
            {
                var model = _productService.GetById(id);
                if (model == null)
                    return Content(HttpStatusCode.NotFound, ApiMessage.ProductNotFound);

                var viewModel = Mapper.Map<ProductDto>(model);

                return Ok(viewModel);
            });
        }

        [Route("")]
        [HttpPost]
        //        [Permission(Action = ActionName.CanCreate)]
        public IHttpActionResult Create([FromBody] ProductDto product)
        {
            return CreateResponse(() =>
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var model = Mapper.Map<Product>(product);
                // temp code
                model.SupplierId = 1;

                _productService.Add(model);
                UnitOfWork.Commit();

                product.Id = model.Id;
                product.DateCreated = model.DateCreated;

                return Created(new Uri(Request.RequestUri + "/" + product.Id), product);
            });
        }

        [Route("{id:int:min(1)}")]
        [HttpPut]
        //        [Permission(Action = ActionName.CanUpdate)]
        public IHttpActionResult Edit(int id, [FromBody] ProductDto product)
        {
            return CreateResponse(() =>
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var model = _productService.GetById(id);
                if (model == null)
                    return Content(HttpStatusCode.NotFound, ApiMessage.ProductNotFound);

                Mapper.Map(product, model);

                _productService.Update(model);
                UnitOfWork.Commit();

                product.DateUpdated = model.DateUpdated;

                return Ok(product);
            });
        }

        [Route("{id:int:min(1)}")]
        [HttpDelete]
        //        [Permission(Action = ActionName.CanDelete)]
        public IHttpActionResult Delete(int id)
        {
            return CreateResponse(() =>
            {
                var model = _productService.GetById(id);
                if (model == null)
                    return Content(HttpStatusCode.NotFound, ApiMessage.ProductNotFound);

                _productService.Delete(id);

                UnitOfWork.Commit();

                return Ok();
            });
        }

        [Route("")]
        [HttpDelete]
        //        [Permission(Action = ActionName.CanDelete)]
        public IHttpActionResult Delete(string ids)
        {
            return CreateResponse(() =>
            {
                var checkedIds = new JavaScriptSerializer().Deserialize<List<int>>(ids);

                foreach (var id in checkedIds)
                {
                    _productService.Delete(id);
                }

                UnitOfWork.Commit();

                return StatusCode(HttpStatusCode.NoContent);
            });
        }

        [Route("{id:int}/images")]
        [HttpGet]
        //        [Permission(Action = ActionName.CanRead)]
        public IHttpActionResult GetAllImages(int id)
        {
            return CreateResponse(() =>
            {
                var model = _productImageService.GetAll(id);

                var viewModel = Mapper.Map<IEnumerable<ProductImageDto>>(model);

                return Ok(viewModel);
            });
        }

        [Route("images")]
        [HttpPost]
        //        [Permission(Action = ActionName.CanCreate)]
        public IHttpActionResult CreateProductImage([FromBody] ProductImageDto productImage)
        {
            return CreateResponse(() =>
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var model = Mapper.Map<ProductImage>(productImage);

                _productImageService.Add(model);
                UnitOfWork.Commit();

                productImage.Id = model.Id;

                return Created(new Uri(Request.RequestUri + "/" + productImage.Id), productImage);
            });
        }

        [Route("images/{id:int}")]
        [HttpDelete]
        //        [Permission(Action = ActionName.CanDelete)]
        public IHttpActionResult DeleteProductImage(int id)
        {
            return CreateResponse(() =>
            {
                _productImageService.Delete(id);
                UnitOfWork.Commit();

                return StatusCode(HttpStatusCode.NoContent);
            });
        }
    }
}