namespace MatthewGormleyWordleProject.Pages;

public partial class ResultsPage : ContentPage
{
	public ResultsPage()
	{
		InitializeComponent();
	}

    public async void openGamePage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Pages.GamePage());
    }

    public async void openMainPage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }
}