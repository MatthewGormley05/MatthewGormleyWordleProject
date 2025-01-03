using Microsoft.Maui;

namespace MatthewGormleyWordleProject.Pages;

public partial class GamePage : ContentPage
{
    //Variables
    public int i = 0, j = 0, selectedBox = 0, currentRow = 0, roundNumber = 1;
    public string chosenWord = string.Empty, userWord = string.Empty;
    public string[] userInputs = { string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
    //public int resultsTracker[][] = { 0 }{ 0 };
    public bool gameWon = false, resultChecked = false, validInput = false;

    //Initialise Pages Methods for future use
    public PagesMethods pagesMethods = new PagesMethods();
    public GamePage()
    {
        InitializeComponent();
        MakeGrid();

        //Start the game

        //Make Popup that explains the game

        //Ensure row is set to 0
        currentRow = 0;

        //For loop that ends in a loss if completed
        for (i = 0; i < 6; i++)
        {
            //Ensure values are set
            resultChecked = false;
            gameWon = false;
            validInput = false;
            selectedBox = 0;

            //While loop that runs until user uses the enter button
            while (resultChecked == false)
            {
                //Reset the textbox

                //User Enters 1 letter that is auto-capitalised

                //Validation check is done
                InputValidation();

                //If its one of the letters, fill out the current input with it
                if(i == 0)
                {
                    //Set the current box input

                    //Go to the next box
                    selectedBox++;
                }
                
                //If its "enter" and all 5 boxes are filled, validate it
                else if(i == 1)
                {
                    //For loop that goes through each of the boxes comparing the inputs to the chosen word
                    //If input is correct give it value of 1
                    //If input is correct but in wrong place give it value of 2
                    //If input is incorrect give it a value of 3

                    //If all are correct then victory
                    if(i == 5 && j == 6)
                    {
                        gameWon = true;
                    }

                    //If not all are correct then
                    resultChecked = true;
                }

                //If its "delete", reset previous box
                else if(i == 2)
                {
                    //Clear Current Box

                    //Go back a box

                    //Clear that Box
                }    
            }

            //Check if game was won at end of round, if so break the for loop
            if(gameWon == true)
            {
                break;
            }

            currentRow++;
        }
    }

    public void MakeGrid()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                //Create the rows and columns of buttons
                Button button = new Button()
                {
                    BackgroundColor = Colors.Black,
                    BorderColor = Colors.LightGrey,
                    BorderWidth = 2,
                    HeightRequest = 40,
                    WidthRequest = 40
                };

                GameGrid.Add(button, i, j);
            }
        }
    }

    public void InputValidation()
    {
        //Check the textbox to see if it is valid

        //If valid set to true

        //If invalid set to false
    }

    public async void OpenResultsPage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Pages.ResultsPage());
    }

    public async void OpenHomePage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Pages.HomePage());
    }
}