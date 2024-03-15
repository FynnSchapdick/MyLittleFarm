using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyFarmApp.ViewModels;

namespace MyFarmApp.Extensions.HostBuilder;

public static class AddViewModelsHostBuilderExtensions
{
    public static IHostBuilder AddViewModels(this IHostBuilder host)
    {
        host.ConfigureServices(services =>
        {
            services.AddTransient<MainWindowViewModel>();
        });

        return host;
    }
}