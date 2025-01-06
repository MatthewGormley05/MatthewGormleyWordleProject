namespace MatthewGormleyWordleProject.Pages;

public partial class ResultsPage : ContentPage
{
    //Initialise Pages Methods for future use
    public PagesMethods pagesMethods = new PagesMethods();
    public int i = 1, Guesses = 0;
    public string Name = string.Empty, ChosenWord = string.Empty;
    bool gameVictory = false;
    double Time = 0;
    //make 2d array for emojis

    //Player Name
    public string PlayerName = string.Empty;


    public ResultsPage(string playerName)
	{
        InitializeComponent();
        PlayerName = playerName;
        BindingContext = this;

        //Print Player Name

        //Print Previous Attempts
        //LoadPlayerHistory();
    }

    public void LoadPlayerHistory()
    {
        //Open file associated with player name

        //Load Attempt History
        while(i == 0) //While loop that runs until file end starting on the 3rd Line
        {
            //Reset Values
            Guesses = 0;
            ChosenWord = string.Empty;
            gameVictory = false;
            Time = 0;

            //Each Attempt is 10 lines
            for(i = 0; i < 10; i++)
            {
                //If it's an empty line automatically stop (failsafe)
                if(i == 100)
                {

                    break;
                }
                
                //Set and print
                else
                {
                    //Chosen word
                    if(i == 0)
                    {
                        ChosenWord = "Testt";
                        //Print
                    }

                    //Game Result

                    //Time (if it = "!" then don't print)

                    //Guesses

                    //Emoji Array
                }
            }
        }

        //Close File
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