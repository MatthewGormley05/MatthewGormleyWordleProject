namespace MatthewGormleyWordleProject.Pages;

public partial class LogInPage : ContentPage
{
    //Player Name
    public string PlayerName;

    public LogInPage()
	{
        InitializeComponent();
        BindingContext = this;
	}

    public async void OpenHomePage(object sender, EventArgs e)
    {
        //User Name has to be set
        if(!string.IsNullOrWhiteSpace(PlayerName))
        {
            await Navigation.PushModalAsync(new Pages.HomePage(PlayerName));
        }

        //Make user enter name
        else
        {
            await DisplayAlert("Error", "Please enter a player name.", "OK");
        }
    }
}