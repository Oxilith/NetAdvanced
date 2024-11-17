using NetAdvanced.Core.ApiClients;
using NetAdvanced.Core.ApiServices;
using NetAdvanced.Core.Interfaces;
using NetAdvanced.WebApi.Api;

namespace NetAdvanced.WebApi;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IStockApiClient,StockApiClient>();
        builder.Services.AddScoped<IApiClientConfiguration<StockApiClient>, StockApiClientConfiguration>();
        builder.Services.AddScoped<IApiService<StockApiClient>, ApiService<StockApiClient>>();
        
        builder.Services.AddScoped<StockApi>();

        AddLogging(builder);

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        MapApis(app);

        app.Run();
    }

    private static void AddLogging(WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder.Logging.AddConsole();
        webApplicationBuilder.Logging.AddDebug();
    }

    private static void MapApis(WebApplication webApplication)
    {
        using var scope = webApplication.Services.CreateAsyncScope();
        var stockApi = scope.ServiceProvider.GetRequiredService<StockApi>();
        stockApi.Map(webApplication);
    }
}