using System.Net;
using Microsoft.AspNetCore.Http.Extensions;
using HepsiYemekApi.Common.ResponsesModel;
using Microsoft.AspNetCore.Mvc;

namespace HepsiYemekApi.Common.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult GetResponse(this ControllerBase controller, IResponse response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.NotFound:
                {
                    return new NotFoundObjectResult(response);
                }
                case HttpStatusCode.Forbidden:
                {
                    return new ForbidResult();
                }
                case HttpStatusCode.Unauthorized:
                {
                    return new UnauthorizedObjectResult(response);
                }
                case HttpStatusCode.BadGateway:
                {
                    return new BadRequestObjectResult(response);
                }
                case HttpStatusCode.InternalServerError:
                {
                    return new BadRequestObjectResult(response);
                }
                case HttpStatusCode.MethodNotAllowed:
                {
                    return new BadRequestObjectResult(response);
                }
                case HttpStatusCode.UnsupportedMediaType:
                {
                    return new BadRequestObjectResult(response);
                }
                case HttpStatusCode.RequestUriTooLong:
                {
                    return new BadRequestObjectResult(response);
                }
                case HttpStatusCode.NoContent:
                {
                    return new NoContentResult();
                }
                case HttpStatusCode.BadRequest:
                {
                    return new BadRequestObjectResult(response);
                }
                case HttpStatusCode.Conflict:
                {
                    return new ConflictObjectResult(response);
                }
                case HttpStatusCode.Created:
                {
                    var uri = controller.HttpContext.Request.GetDisplayUrl();
                    return new CreatedResult(uri, response);
                }
                default:
                {
                    return new OkObjectResult(response);
                }
            }
        }
    }
}