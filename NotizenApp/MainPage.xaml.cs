using Microsoft.UI.Composition;

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

                // Update the Last Edited section
                UpdateLastEdited(note);
            }
        }


        private void UpdateLastEdited(Note note)
        {
            LastEditedList.Children.Insert(0, new Frame
            {
                Content = new Label
                {
                    Text = note.Title,
                    FontSize = 18,
                    TextColor = (Color)Application.Current.Resources["TextPrimary"]
                },
                BackgroundColor = (Color)Application.Current.Resources["Background"],
                CornerRadius = 10,
                HasShadow = true,
                Margin = new Thickness(0, 0, 0, 10),
                Padding = new Thickness(10),
                HeightRequest = 50,
                WidthRequest = 200,
                Shadow = new Shadow
                {
                    Brush = Brush.Gray,
                    Opacity = 0.3F,
                    Offset = new Point(5, 5),
                    Radius = 10
                }
            });
        }
    }

    public class Note
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }

}
