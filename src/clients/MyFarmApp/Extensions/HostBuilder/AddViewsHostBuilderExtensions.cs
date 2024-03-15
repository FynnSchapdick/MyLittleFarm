using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyFarmApp.ViewModels;
using MyFarmApp.Views;

namespace MyFarmApp.Extensions.HostBuilder;

public static class AddViewsHostBuilderExtensions
{
    public static IHostBuilder AddViews(this IHostBuilder host)
    {
        host.ConfigureServices(services =>
        {
            services.AddSingleton<MainWindow>(s => new MainWindow(s.GetRequiredService<MainWindowViewModel>()));
        });

        return host;
    }
}