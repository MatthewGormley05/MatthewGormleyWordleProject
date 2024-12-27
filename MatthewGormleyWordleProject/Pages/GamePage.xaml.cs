namespace MatthewGormleyWordleProject.Pages;

public partial class GamePage : ContentPage
{
	public GamePage()
	{
		InitializeComponent();
	}

    public async void openResultsPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages.ResultsPage());
    }

    public async void openMainPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}