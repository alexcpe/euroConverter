using System.Collections.ObjectModel;
using System.Windows.Input;
using ClientLourd.Models;
using ClientLourd.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ClientLourd.ViewModels;

public class EuroConverterViewModel: ObservableObject
{
    public IRelayCommand BtnSetConversion { get;  }

    public ICommand GoBackCommand { get; private set; }
    private string amount;
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
    public string Amount
    {
        get { return amount; }
        set
        {
            amount = value;
            OnPropertyChanged(nameof(Amount));
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
    

    public EuroConverterViewModel()
    {
        ActionGetDataAsync();
        BtnSetConversion = new RelayCommand(ActionSetConversion);
        GoBackCommand = new Command(GoBack);
    }

    private async void ActionGetDataAsync()
    {
        var result = await DeviseService.Instance.GetAllDevisesAsync();
        Devises = new ObservableCollection<Devise>(result);
    }
    private void ActionSetConversion()
    {
            ConvertedValue = double.Parse(Amount) * selectedItem.Taux;
        

    }
    private bool IsDouble(string input)
    {
        return double.TryParse(input, out _);
    }

    private async void GoBack()
    {
        await Shell.Current.GoToAsync("///MainPage");
    }

}