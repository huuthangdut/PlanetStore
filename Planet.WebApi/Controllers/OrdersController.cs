using Planet.Data.Core;
using Planet.Infrastructure.Core;
using Planet.Services.Core;
using System.Web.Http;

namespace Planet.WebApi.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : BaseApiController
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService, IErrorService errorService, IUnitOfWork unitOfWork) : base(errorService, unitOfWork)
        {
            _orderService = orderService;
        }

        //        [Route("")]
        //        [HttpGet]
        //        public IHttpActionResult GetAll(string dateStart, string dateEnd, string customerName, int paymentStatus,
        //            int page, int pageSize, string filter)
        //        {
        //            return CreateResponse(() =>
        //            {
        //
        //            });
        //        }
        //
        //        [Route("{id}")]
        //        [HttpGet]
        //        public IHttpActionResult GetOrder(int id)
        //        {
        //            return CreateResponse(() =>
        //            {
        //
        //            });
        //        }
        //
        //        [Route("")]
        //        [HttpPost]
        //        public IHttpActionResult Create(OrderDto order)
        //        {
        //            return CreateResponse(() =>
        //            {
        //
        //            });
        //        }




    }
}
