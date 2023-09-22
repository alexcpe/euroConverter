using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLourd.Views;

public partial class EuroConverter : ContentPage
{
    public EuroConverter()
    {
        InitializeComponent();
        this.BindingContext = ((App)Application.Current).EuroConverterViewModel;
    }
}