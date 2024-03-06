using GfuQotd.Service;
using GfuQotd.Service.Handler;
using GfuQotd.Shared;

namespace GfuQotd.Web.Blazor.Client.Configuration;

public static class ServiceExtensionsWasm
{
    public static IServiceCollection AddQotdConfig(this IServiceCollection services, IConfiguration configuration)
    {
        //AppSettings OptionsPattern
        services.Configure<QotdAppSettings>(configuration.GetSection(nameof(QotdAppSettings)));

        return services;
    }

    public static IServiceCollection AddHttpClientsConfig(this IServiceCollection services, IConfiguration configuration)
    {
        //AppSettings
        var appSettings = configuration.GetSection(nameof(QotdAppSettings)).Get<QotdAppSettings>();

        //Named Client
        //services.AddHttpClient("externalapiservice", opt =>
        //{
        //    opt.BaseAddress = new Uri(appSettings?.ExternalQotdServiceUri);
        //    opt.DefaultRequestHeaders.Add("Accept", "application/json");
        //});

        //TypedClient
        services.AddTransient<ApiKeyDelegationHandler>();
        services.AddHttpClient<IQotdService, QotdService>(opt =>
        {
            opt.BaseAddress = new Uri(appSettings?.ExternalQotdServiceUri);
            opt.DefaultRequestHeaders.Add("Accept", "application/json");
        }).AddHttpMessageHandler<ApiKeyDelegationHandler>();

        return services;
    }

    public static IServiceCollection AddApiServicesConfig(this IServiceCollection services)
    {
        services.AddScoped<IQotdService, QotdService>(); //MinimalApi
        services.AddKeyedScoped<IQotdService, FakeQotdService>("fakeservice"); //FakeService

        return services;
    }
}