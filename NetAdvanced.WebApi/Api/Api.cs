using NetAdvanced.Core.Interfaces;
using NetAdvanced.WebApi.Helpers;

namespace NetAdvanced.WebApi.Api;

internal class Api
{
    private static ILogger<Api> Logger { get; }
    private static int PageSize => 10 * 1000;
    private static TimeSpan UploadTimeout => TimeSpan.FromMinutes(3);

    static Api()
    {
        Logger = LoggerFactory.Create(
            builder => builder
                .AddConsole()
                .AddDebug()
        ).CreateLogger<Api>();
    }

    public static void Map(WebApplication app)
    {
        MapProcessingEndpoints(app);
    }

    #region ProcessingEndpoints

    private static void MapProcessingEndpoints(WebApplication app)
    {


        app.CreateGetEndpoint<dynamic>(DatasetEndpointInfo, EndpointDelegate<dynamic>(
            async (configuration, service, id) =>
            {
                Logger.LogDebug(
                    $"Get {DatasetEndpointInfo.OperationName} called");

                return await service.Get(id);


            },Logger,DatasetEndpointInfo.OperationName), typeof(void));
        
        app.CreateGetEndpoint<dynamic>(DatasetEndpointInfo2, VoidEndpointDelegate(
            async (configuration, service, id) =>
            {
                Logger.LogDebug(
                    $"Get {DatasetEndpointInfo2.OperationName} called");

                 await service.Void(id);

            },Logger,DatasetEndpointInfo2.OperationName), typeof(void));
    }

    #endregion

    #region ProcessingEndpointInfos

    private static EndpointInfo DatasetEndpointInfo =>
        new("/dataset",
            "GetProcessedDataset", "Get filtered dataset",
            "Returns filtered dataset",
            "Dataset");
    private static EndpointInfo DatasetEndpointInfo2 =>
        new("/dataset2",
            "GetProcessedDataset", "Get filtered dataset",
            "Returns filtered dataset",
            "Dataset");


    #endregion

    #region Delegates

    private static Delegate EndpointDelegate<T>(
        Func<IConfiguration, IApiService, string?, Task<T?>> endpointFunc, ILogger logger,
        string operationName)
    {
        return new
            Func<IConfiguration, IApiService, string?, Task<T?>>(
                async (configuration, service, id) =>
                {
                    logger.LogDebug(
                        $"Get {operationName} called - with parameters: id: {id}");
                    
                   return await endpointFunc(configuration, service, id);
                });
    }
    private static Delegate VoidEndpointDelegate(
        Func<IConfiguration, IApiService, string?, Task> endpointFunc, ILogger logger,
        string operationName)
    {
        return new
            Func<IConfiguration, IApiService, string?, Task>(
                async (configuration, service, id) =>
                {
                    logger.LogDebug(
                        $"Get {operationName} called - with parameters: id: {id}");
                    
                    await endpointFunc(configuration, service, id);
                });
    }

    #endregion
}