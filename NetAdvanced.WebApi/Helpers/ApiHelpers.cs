using Microsoft.OpenApi.Models;
using NetAdvanced.WebApi.Api;

namespace NetAdvanced.WebApi.Helpers;

internal static class ApiHelpers
{
    internal static RouteHandlerBuilder CreateGetEndpoint<T>(this WebApplication app,
        EndpointInfo endpointInfo,
        Delegate endpointDelegate)
    {
        return app.MapGet(endpointInfo.Path, endpointDelegate)
            .WithName(endpointInfo.OperationName)
            .WithOpenApi(x => new OpenApiOperation(x)
            {
                Summary = endpointInfo.Summary,
                Description = endpointInfo.Description,
                Tags = new List<OpenApiTag> { new() { Name = endpointInfo.TagName } },
                Responses = new OpenApiResponses
                {
                    { StatusCodes.Status200OK.ToString(), new OpenApiResponse { Description = typeof(T).Name } },
                    {
                        StatusCodes.Status400BadRequest.ToString(),
                        new OpenApiResponse { Description = "Invalid request" }
                    },
                    {
                        StatusCodes.Status403Forbidden.ToString(),
                        new OpenApiResponse { Description = "Access forbidden" }
                    },
                    {
                        StatusCodes.Status500InternalServerError.ToString(),
                        new OpenApiResponse { Description = "Internal server error" }
                    }
                }
            }).Produces<T>();
    }
}