namespace NotizenApp;

public partial class NotePage : ContentPage
{
    private FontAttributes currentFontAttributes = FontAttributes.None;
    private TextDecorations currentTextDecorations = TextDecorations.None;
    private string unformattedText = string.Empty; // Keeps track of raw text

    public NotePage(Note note = null)
    {
        InitializeComponent();

        if (note != null)
        {
            TitleEntry.Text = note.Title;
            unformattedText = note.Content;
            UpdateFormattedContent();
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void OnBoldClicked(object sender, EventArgs e)
    {
        currentFontAttributes ^= FontAttributes.Bold;
    }

    private void OnItalicClicked(object sender, EventArgs e)
    {
        currentFontAttributes ^= FontAttributes.Italic;
    }

    private void OnUnderlineClicked(object sender, EventArgs e)
    {
        currentTextDecorations ^= TextDecorations.Underline;
    }

    private void OnContentEditorTextChanged(object sender, TextChangedEventArgs e)
    {
        unformattedText = e.NewTextValue;
        UpdateFormattedContent();
    }

    private void UpdateFormattedContent()
    {
        var formattedString = new FormattedString();
        if (string.IsNullOrEmpty(unformattedText)) return;

        // Break text into spans and apply styles
        var words = unformattedText.Split(' '); // Example split by space for formatting
        foreach (var word in words)
        {
            formattedString.Spans.Add(new Span
            {
                Text = word + " ", // Add space back
                FontAttributes = currentFontAttributes,
                TextDecorations = currentTextDecorations
            });
        }

        FormattedContentLabel.FormattedText = formattedString;
    }
}
