namespace NotizenApp;

public partial class FAQPage : ContentPage
{
    public FAQPage()
    {
        InitializeComponent();
        AddTapGestureRecognizers();
    }

    private void AddTapGestureRecognizers()
    {
        var tapGestureRecognizer1 = new TapGestureRecognizer();
        tapGestureRecognizer1.Tapped += (s, e) => ToggleAnswerVisibility(Answer1, BoxView1);
        Question1.GestureRecognizers.Add(tapGestureRecognizer1);

        var tapGestureRecognizer2 = new TapGestureRecognizer();
        tapGestureRecognizer2.Tapped += (s, e) => ToggleAnswerVisibility(Answer2, BoxView2);
        Question2.GestureRecognizers.Add(tapGestureRecognizer2);

        var tapGestureRecognizer3 = new TapGestureRecognizer();
        tapGestureRecognizer3.Tapped += (s, e) => ToggleAnswerVisibility(Answer3, BoxView3);
        Question3.GestureRecognizers.Add(tapGestureRecognizer3);
    }

    private void ToggleAnswerVisibility(Label answerLabel, BoxView boxView)
    {
        answerLabel.IsVisible = !answerLabel.IsVisible;
        boxView.IsVisible = answerLabel.IsVisible;
    }
}