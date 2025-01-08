namespace MatthewGormleyWordleProject.Pages;

public partial class ResultsPage : ContentPage
{
    //Initialise Pages Methods for future use
    public PagesMethods pagesMethods = new PagesMethods();
    public int i = 1, Guesses = 0;
    public string Name = string.Empty, ChosenWord = string.Empty, fileName = string.Empty;
    public bool gameVictory = false;
    public double Time = 0;
    //make 2d array for emojis

    //Player Name
    public string PlayerName = string.Empty;


    public ResultsPage(string playerName)
	{
        InitializeComponent();
        PlayerName = playerName;
        BindingContext = this;

        //Print Player Name


        //LoadPlayerHistory();
    }

    public void LoadPlayerHistory()
    {
        //Reference file associated with player name
        fileName = PlayerName + ".txt";

        //Formatted as:
        //Game Word
        //Game Result
        //Guesses
        //Timer
        //Array

        //Load Attempt History
        while (i == 0) //While loop that runs until file end
        {
            //Start of loaded attempt

            //Reset Values
            Guesses = 0;
            ChosenWord = string.Empty;
            gameVictory = false;
            Time = 0;


            //Each Attempt is 10 lines, create a new grid row and entry for each attempt
            for(i = 0; i < 10; i++)
            {
                //If it's an empty line automatically skip 
                if (i == 100)
                {

                    break;
                }
                
                //If not empty make place save game data
                else
                {
                    //Chosen word
                    if(i == 0)
                    {
                        ChosenWord = "Testt";
                        //Print
                    }

                    //Game Result

                    //Guesses

                    //Time (if it = "!" then don't print)

                    //Emoji Array
                }
            }
        }

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