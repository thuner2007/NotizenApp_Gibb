using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NotizenApp;

public partial class SettingsPage : ContentPage, INotifyPropertyChanged
{
    private string _userName = string.Empty;

    public SettingsPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public string UserName
    {
        get => _userName;
        set
        {
            if (_userName != value)
            {
                _userName = value;
                OnPropertyChanged();
            }
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void OnUseNameToggled(object sender, ToggledEventArgs e)
    {
        // Handle the toggled event if needed
        bool isToggled = e.Value;
        NameEntry.IsEnabled = isToggled;
    }

    private void OnAgeStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
        AgeLabel.Text = e.NewValue.ToString();
    }

    public new event PropertyChangedEventHandler? PropertyChanged;

    protected new void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}