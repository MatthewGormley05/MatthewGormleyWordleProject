namespace MatthewGormleyWordleProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
        }

        public async void openGamePage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Pages.GamePage());
        }

        public async void openResultsPage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Pages.ResultsPage());
        }
    }

}
