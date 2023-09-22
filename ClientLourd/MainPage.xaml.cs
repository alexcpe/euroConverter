using ClientLourd.ViewModels;

namespace ClientLourd;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
       this.BindingContext = ((App)Application.Current).ConvertisseurEuroVM;
    }
}