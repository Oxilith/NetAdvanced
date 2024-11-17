using NetAdvanced.Core.ApiClients;
using NetAdvanced.Core.Interfaces;
using NetAdvanced.WebApi.Helpers;

namespace NetAdvanced.WebApi.Api;

internal class StockApi(ILogger<StockApi> logger)
{
    private ILogger<StockApi> Logger { get; } = logger;

    public void Map(WebApplication app)
    {
        MapProcessingEndpoints(app);
    }

    private void MapProcessingEndpoints(WebApplication app)
    {
        app.CreateGetEndpoint<int?>(StockApiEndpointInfo.GetEndpointInfo, StockApiEndpointDelegates.TaskOf(
            (client, param) => client.Get<int?>(param!),
            Logger, StockApiEndpointInfo.GetEndpointInfo.OperationName));

        app.CreateGetEndpoint<Task>(StockApiEndpointInfo.ActionEndpointInfo, StockApiEndpointDelegates.Task(
            (client, param) => client.Void(param!),
            Logger, StockApiEndpointInfo.ActionEndpointInfo.OperationName));
    }
}