using System.Collections.ObjectModel;
using System.Windows.Input;
using ClientLourd.Models;
using ClientLourd.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;

namespace ClientLourd.ViewModels;

public class ConvertisseurEuroViewModel : ObservableObject
{
    public IRelayCommand BtnSetConversion { get;  }
    private string _montantEuros;
    private double convertedValue;

    public double ConvertedValue
    {
        get { return convertedValue; }
        set
        {
            convertedValue = value;
            OnPropertyChanged();
        }
    }
    public string MontantEuros
    {
        get { return _montantEuros; }
        set
        {
            _montantEuros = value;
            OnPropertyChanged(nameof(MontantEuros));
        }
    }
    public Devise SelectedItem
    {
        get { return selectedItem; }
        set
        {
            selectedItem = value;
            OnPropertyChanged();
        }
    }
    private Devise selectedItem;

    private ObservableCollection<Devise> devises;
    public ObservableCollection<Devise> Devises {
        get { return devises; } set
        {
            devises = value;
            OnPropertyChanged();
            // Sélectionnez le premier élément par défaut
            if (devises != null && devises.Count > 0)
            {
                SelectedItem = devises[0];
            }
        } }
    public ICommand GoToEuroConverter { get; private set; }

    public ConvertisseurEuroViewModel() 
    {
        ActionGetDataAsync();
        BtnSetConversion = new RelayCommand(ActionSetConversion);
        GoToEuroConverter = new Command(GoToEuroConverterPage);
    }
    private async void ActionGetDataAsync()
    {
        var result = await DeviseService.Instance.GetAllDevisesAsync();
        Devises = new ObservableCollection<Devise>(result);
    }

    private void ActionSetConversion()
    {
        try
        {
            ConvertedValue = double.Parse(MontantEuros) / selectedItem.Taux;

        }
        catch (Exception e)
        {
            Application.Current.MainPage.DisplayAlert("Veuillez inscrire un montant s'il vous plaît", e.Message, "OK");
            throw;
        }

    }
    private async void GoToEuroConverterPage()
    {
        await Shell.Current.GoToAsync("///EuroConverter");
    }
 
}