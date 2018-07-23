using Planet.Data.Core;
using Planet.Data.Core.Domain;
using Planet.Services.Core;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Web.Http;

namespace Planet.Infrastructure.Core
{
    public class BaseApiController : ApiController
    {
        private readonly IErrorService _errorService;
        protected readonly IUnitOfWork UnitOfWork;

        public BaseApiController(IErrorService errorService, IUnitOfWork unitOfWork)
        {
            _errorService = errorService;
            UnitOfWork = unitOfWork;
        }

        protected IHttpActionResult CreateResponse(Func<IHttpActionResult> function)
        {
            IHttpActionResult result;
            try
            {
                result = function.Invoke();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                LogError(ex);

                result = BadRequest(ex.InnerException?.Message);
            }
            catch (DbUpdateException dbEx)
            {
                LogError(dbEx);
                result = BadRequest(dbEx.InnerException?.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                result = InternalServerError(ex);
            }

            return result;
        }

        private void LogError(Exception ex)
        {
            var error = new Error
            {
                DateCreated = DateTime.Now,
                Message = ex.Message,
                StackTrace = ex.StackTrace
            };

            _errorService.Add(error);

            UnitOfWork.Commit();
        }
    }
}