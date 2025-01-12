namespace NotizenApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage(string userName)
        {
            InitializeComponent();
            WelcomeLabel.Text = $"Hello, {userName}";

            // Add sample notes
            NotesCollection.ItemsSource = new[]
            {
                new Note { Title = "Title 1", Content = "This is a text blabla bla..." },
                new Note { Title = "Title 2", Content = "This is a text blabla bla..." },
                new Note { Title = "Title 3", Content = "This is a text blabla bla..." },
                new Note { Title = "Title 4", Content = "This is a text blabla bla..." },
                new Note { Title = "Title 5", Content = "This is a text blabla bla..." }
            };
        }

        private async void OnSettingsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }

        private async void OnNoteSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Note note)
            {
                await Navigation.PushAsync(new NotePage(note));
                NotesCollection.SelectedItem = null;
            }
        }
    }

    public class Note
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }

}
