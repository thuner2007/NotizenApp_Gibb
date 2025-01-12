namespace NotizenApp;

public partial class WelcomePage : ContentPage
{
    public WelcomePage()
    {
        InitializeComponent();
    }

    private async void OnFinishClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameEntry.Text))
        {
            await DisplayAlert("Error", "Please enter your name", "OK");
            return;
        }

        await Navigation.PushAsync(new MainPage(NameEntry.Text));
    }
}