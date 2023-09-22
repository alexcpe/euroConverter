using ClientLourd.ViewModels;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace ClientLourd;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        Ioc.Default.ConfigureServices( new ServiceCollection()
            .AddSingleton<ConvertisseurEuroViewModel>().AddSingleton<EuroConverterViewModel>() .BuildServiceProvider());
        MainPage = new AppShell();
    }
    public ConvertisseurEuroViewModel ConvertisseurEuroVM {
 
        get { return Ioc.Default.GetService<ConvertisseurEuroViewModel>(); } }
    public EuroConverterViewModel EuroConverterViewModel {
 
        get { return Ioc.Default.GetService<EuroConverterViewModel>(); } }
}