using System.Net.Mime;
using System.Net;
using System.Text.Json;
using GameShop.EntityLayer.Exceptions;

namespace GameShop.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            // Category Exceptions //
            catch(CategoryAlreadyExistsException ex)
            {
                await HandleCustomExceptionResponseAsync(context, ex, HttpStatusCode.Conflict);
            }
            catch(CategoryDeleteException ex)
            {
                await HandleCustomExceptionResponseAsync(context, ex, HttpStatusCode.Conflict);
            }
            catch (CategoryNotFoundException ex)
            {
                await HandleCustomExceptionResponseAsync(context, ex, HttpStatusCode.NotFound);
            }
            // GameCompany Exceptions //
            catch (CompanyDeleteException ex)
            {
                await HandleCustomExceptionResponseAsync(context, ex, HttpStatusCode.Conflict);
            }
            catch (GameCompanyAlreadyExistsException ex)
            {
                await HandleCustomExceptionResponseAsync(context, ex, HttpStatusCode.Conflict);
            }
            catch (GameCompanyNotFoundException ex)
            {
                await HandleCustomExceptionResponseAsync(context, ex, HttpStatusCode.NotFound);
            }
            // Game Exceptions //
            catch (GameAlreadyExistsException ex)
            {
                await HandleCustomExceptionResponseAsync(context, ex, HttpStatusCode.Conflict);
            }
            catch (GameNotFoundException ex)
            {
                await HandleCustomExceptionResponseAsync(context, ex, HttpStatusCode.NotFound);
            }
            // Role Exceptions //
            catch (RoleAlreadyExistsException ex)
            {
                await HandleCustomExceptionResponseAsync(context, ex, HttpStatusCode.Conflict);
            }
            catch (RoleDeleteException ex)
            {
                await HandleCustomExceptionResponseAsync(context, ex, HttpStatusCode.Conflict);
            }
            catch (RoleNotFoundException ex)
            {
                await HandleCustomExceptionResponseAsync(context, ex, HttpStatusCode.NotFound);
            }
            // User Exceptions //
            catch (InvalidPasswordException ex)
            {
                await HandleCustomExceptionResponseAsync(context, ex, HttpStatusCode.BadRequest);
            }
            catch (UserAlreadyExistsException ex)
            {
                await HandleCustomExceptionResponseAsync(context, ex, HttpStatusCode.Conflict);
            }
            catch (UserNotFoundException ex)
            {
                await HandleCustomExceptionResponseAsync(context, ex, HttpStatusCode.NotFound);
            }
            // Server Exceptions //
            catch (Exception ex)
            {
                await HandleCustomExceptionResponseAsync(context, ex);
            }
        }

        private async Task HandleCustomExceptionResponseAsync(HttpContext context, Exception ex, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError)
        {
            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int)httpStatusCode;

            var response = new ErrorModel(context.Response.StatusCode, ex.Message);
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var json = JsonSerializer.Serialize(response, options);
            await context.Response.WriteAsync(json);
        }
    }
}
