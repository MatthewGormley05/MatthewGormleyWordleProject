namespace MatthewGormleyWordleProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void openGamePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.GamePage());
        }

        public async void openResultsPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.ResultsPage());
        }
    }

}
