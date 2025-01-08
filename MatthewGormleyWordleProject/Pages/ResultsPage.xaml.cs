using System;

namespace MatthewGormleyWordleProject.Pages;

public partial class ResultsPage : ContentPage
{
    //Initialise Pages Methods for future use
    public PagesMethods pagesMethods = new PagesMethods();
    public int i = 1, Guesses = 0;
    public string Name = string.Empty, ChosenWord = string.Empty;
    public bool gameVictory = false;
    public double Time = 0;
    //make 2d array for emojis

    //Player Name
    public string PlayerName = string.Empty;


    public ResultsPage(string playerName)
	{
        InitializeComponent();
        PlayerName = playerName;

        //Print Player Name
        DisplayName.Text = "Player Name: " + PlayerName;

        LoadPlayerHistory();
    }

    public void LoadPlayerHistory()
    {
        //Get Player Name File Path
        string playerFile = PlayerName + ".txt";
        string path = FileSystem.Current.AppDataDirectory;
        string fullPath = Path.Combine(path, playerFile);

        //Formatted as:
        //Game Word
        //Game Result
        //Guesses
        //Array

        
        //Read in file as array value
        string fileContent = File.ReadAllText(fullPath);

        PlayerHistoryView.Text = fileContent;
        



        //Load Attempt History

        //End of loaded attempt
    }

    public async void OpenGamePage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Pages.GamePage(PlayerName));
    }

    public async void OpenHomePage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Pages.HomePage(PlayerName));
    }
}