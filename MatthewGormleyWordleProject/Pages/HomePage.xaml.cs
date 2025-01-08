namespace MatthewGormleyWordleProject.Pages;

public partial class HomePage : ContentPage
{
    //Initialise Pages Methods for future use
    public PagesMethods pagesMethods = new PagesMethods();

    //Player Name
    public string PlayerName;

    public HomePage(string playerName)
	{
		InitializeComponent();
        PlayerName = playerName;
        BindingContext = this;
        CheckUser();
	}

    public void CheckUser()
    {
        string playerFile = PlayerName + ".txt";
        string path = FileSystem.Current.AppDataDirectory;
        string fullPath = Path.Combine(path, playerFile);

        if(!File.Exists(fullPath))
        {
            //Create Player File if it does not exist
            File.Create(fullPath);
            
        }
    }

    public async void OpenGamePage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Pages.GamePage(PlayerName));
    }

    public async void OpenResultsPage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Pages.ResultsPage(PlayerName));
    }

    public async void OpenSettingsPage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Pages.ResultsPage(PlayerName));
    }

    //Do not pass the Player Name as you are resetting
    public async void OpenLogInPage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Pages.LogInPage());
    }
}