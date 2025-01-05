namespace MatthewGormleyWordleProject.Pages;

public partial class LogInPage : ContentPage
{
	public LogInPage()
	{
        InitializeComponent();
	}

    public async void OpenHomePage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Pages.HomePage());
    }
}