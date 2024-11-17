using NetAdvanced.Core.ApiClients;
using NetAdvanced.Core.Interfaces;

namespace NetAdvanced.WebApi.Api;

internal static class StockApiEndpointDelegates
{
    internal static Delegate TaskOf<T>(
        Func<IStockApiClient, string?, Task<T?>> endpointFunc, ILogger logger, string operationName)
    {
        return new
            Func<IStockApiClient, string?, Task<T?>>(
                async (client, id) =>
                {
                    logger.LogDebug(
                        $"Get {operationName} called - with parameters: id: {id}");

                    return await endpointFunc(client, id);
                });
    }

    internal static Delegate Task(
        Func<IStockApiClient, string?, Task> endpointFunc, ILogger logger, string operationName)
    {
        return new
            Func<IStockApiClient, string?, Task>(
                async (client, id) =>
                {
                    logger.LogDebug(
                        $"Get {operationName} called - with parameters: id: {id}");

                    await endpointFunc(client, id);
                });
    }
}