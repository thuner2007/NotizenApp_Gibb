namespace NotizenApp;

public partial class NotePage : ContentPage
{
    public NotePage(Note note = null)
    {
        InitializeComponent();

        if (note != null)
        {
            TitleEntry.Text = note.Title;
            ContentEditor.Text = note.Content;
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void OnBoldClicked(object sender, EventArgs e)
    {
        // Implement text formatting
    }

    private void OnItalicClicked(object sender, EventArgs e)
    {
        // Implement text formatting
    }

    private void OnUnderlineClicked(object sender, EventArgs e)
    {
        // Implement text formatting
    }
}