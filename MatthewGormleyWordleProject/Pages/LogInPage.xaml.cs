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
        if(PlayerName != null)
        {
            await Navigation.PushModalAsync(new Pages.HomePage(PlayerName));
        }

        //Make user enter name
        else
        {
            //await Navigation.PushModalAsync(new Pages.HomePage(PlayerName));
            await DisplayAlert("Error", "Please enter a player name.", "OK");
        }
        
    }

    public void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        PlayerName = LoginBox.Text;
    }
}