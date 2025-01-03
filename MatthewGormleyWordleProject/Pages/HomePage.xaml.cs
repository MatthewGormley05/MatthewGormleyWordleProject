namespace MatthewGormleyWordleProject.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    public async void OpenGamePage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Pages.GamePage());
    }

    public async void OpenResultsPage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Pages.ResultsPage());
    }
}