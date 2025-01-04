//using Android.Text;
using Microsoft.Maui;

namespace MatthewGormleyWordleProject.Pages;

public partial class GamePage : ContentPage
{
    //Variables
    public int i = 0, j = 0, selectedBoxCounter = 0, selectedRow = 0, roundNumber = 1, inputType = 0;
    public string chosenWord = string.Empty, userWord = string.Empty, currentInput = string.Empty;
    public string[] userInputs = { string.Empty, string.Empty, string.Empty, string.Empty, string.Empty }, wordLetters = { string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
    //public int attemptsGrid[][] = { 0 }{ 0 };
    public bool gameWon = false, resultChecked = false, validInput = false;

    //Initialise Pages Methods for future use
    public PagesMethods pagesMethods = new PagesMethods();
    public GamePage()
    {
        InitializeComponent();
        MakeGrid();


        //Choose Word from file

        //Break down word into letters to be compared to user inputs
        for(int i = 0; i < 5; i++)
        {
            wordLetters[i] = " ";
        }

        //Start the game

        //Make Popup that explains the game

        //Ensure row is set to 0
        selectedRow = 0;

        //For loop that ends in a loss if completed
        for (i = 0; i < 6; i++)
        {
            //Ensure values are set
            resultChecked = false;
            gameWon = false;
            validInput = false;
            selectedBoxCounter = 0;
            currentInput = string.Empty;

            //While loop that runs until user uses the enter button
            while (resultChecked == false)
            {
                //Reset the textbox
                validInput = false;

                //User Enters 1 letter that is auto-capitalised
                //input.TextChanged

                //Validation check is done on text change
                InputValidation();

                //If its one of the letters, fill out the current input with it
                if (validInput == true && inputType == 1)
                {
                    //Set current input to the current box text
                    //currentInput = currentTextBox.Text;

                    //Set the store array value
                    userInputs[selectedBoxCounter] = currentInput;

                    //Clear input
                    currentInput = string.Empty;

                    //Go to the next box
                    //selectedBox.unfocus();
                    selectedBoxCounter++;
                    //selectedBox.focus();
                }
                
                //If its "enter" and all 5 boxes are filled, validate it
                else if(validInput == true && inputType == 2)
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
                else if(validInput == true && inputType == 3)
                {
                    //Clear Current Box

                    //Go back a box

                    //Clear that Box
                }

                //Testing
                resultChecked = true;
            }

            //Check if game was won at end of round, if so break the for loop
            if(gameWon == true)
            {
                break;
            }

            selectedRow++;
        }
    }

    
    public void MakeGrid()
    {
        
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                //Create the rows and columns of entries
                Entry entry = new Entry()
                {
                    BackgroundColor = Colors.Black,
                    HeightRequest = 38,
                    WidthRequest = 38
                };

                GameGrid.Add(entry, i, j);

                //Create frames around the entries
                Frame frame = new Frame
                {
                    BorderColor = Colors.LightGray,
                    BackgroundColor = Colors.Black,
                    Padding = 0,
                    HeightRequest = 40,
                    WidthRequest = 40,
                    CornerRadius = 3
                };

                GameGrid.Add(frame, i, j);
            }
        }
        
    }

    public void InputValidation()
    {
        //Check the textbox to see if it is valid
        if(i == 0)
        {

        }

        //If invalid set to false
        else
        {
            validInput = false;
        }
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