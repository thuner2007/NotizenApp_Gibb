namespace NotizenApp
{
    public partial class MainPage : ContentPage
    {
        string name = "Colin";
        public MainPage()
        {
            InitializeComponent();

            helloLabel.Text = "Hello, " + name;
        }
    }

}
