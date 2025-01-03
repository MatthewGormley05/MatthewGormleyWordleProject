namespace MatthewGormleyWordleProject.Pages;

public partial class ResultsPage : ContentPage
{
    //Initialise Pages Methods for future use
    public PagesMethods pagesMethods = new PagesMethods();

    public ResultsPage()
	{
		InitializeComponent();
	}

    public async void OpenGamePage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Pages.GamePage());
    }

    public async void OpenHomePage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Pages.HomePage());
    }
}