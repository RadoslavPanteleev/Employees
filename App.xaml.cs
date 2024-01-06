using System.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Employees.Services;
using Employees.ViewModels;

namespace Employees
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                .AddSingleton(typeof(MainWindow))
                .AddTransient(typeof(MainViewModel))
                .AddTransient(typeof(ICsvParserService), typeof(CsvParserService))
                .AddTransient(typeof(ICalculatePairsService), typeof(CalculatePairsService))
                .BuildServiceProvider()
                );

            MainWindow = Ioc.Default.GetRequiredService<MainWindow>();
            MainWindow.Show();
        }
    }
}
