//using Android.Text;
//using Java.Lang;
//using GameKit;
using Microsoft.Maui;

namespace MatthewGormleyWordleProject.Pages;

public partial class GamePage : ContentPage
{
    //Variables
    public int i = 0, j = 0, k = 0, selectedBoxCounter = 0, selectedRow = 0, roundNumber = 1, inputType = 0;
    public string chosenWord = string.Empty, userWord = string.Empty, currentInput = string.Empty;
    public string[] userInputs = { string.Empty, string.Empty, string.Empty, string.Empty, string.Empty }, wordLetters = { string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
    public int[,] attemptsGrid = { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
    public bool gameWon = false, resultChecked = false, validInput = false;
    public string[] Letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
    public double Time = 0;

    //Player Name
    public string PlayerName = string.Empty;

    //Initialise Pages Methods for future use
    public PagesMethods pagesMethods = new PagesMethods();
    public GamePage(string playerName)
    {
        InitializeComponent();
        PlayerName = playerName;
        BindingContext = this;
        MakeGrid();
        GameStarted();
    }

    public async void GameStarted()
    {
        //Choose Word from file
        //Set random number
        //Go to that line in the file
        //Take that word and set it to chosen word
        chosenWord = "FISHY";

        //Break down word into letters to be compared to user inputs
        for (int i = 0; i < 5; i++)
        {
            wordLetters[i] = chosenWord.Substring(i);
        }

        //Popup that explains the game


        //Ensure row is set to 0
        selectedRow = 0;

        //Loop for round
        for (i = 0; i < 6; i++)
        {
            //Ensure values are set
            resultChecked = false;
            gameWon = false;
            validInput = false;
            selectedBoxCounter = 0;
            currentInput = string.Empty;
            userInput.Text = string.Empty;

            //While loop that runs until user uses the enter button
            while (resultChecked == false)
            {
                //Continously pause the for loop until the user hits the enter button
                await Task.Delay(10);

                //Timer based on Task.Delay loop
                Time += 0.1;

                //Testing
                resultChecked = true;
            }

            //Check if game was won at end of round, if so break the for loop
            if (gameWon == true)
            {
                break;
            }

            //Move to next row
            selectedRow++;
        }

        //Check the game result
        GameResult();
    }

    public void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        //User Enters 1 letter that is auto-capitalised
        userInput.Text = userInput.Text.ToUpper();


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
            userInput.Text = string.Empty;

            //Go to the next box
            //selectedBox.unfocus();
            selectedBoxCounter++;
            //selectedBox.focus();
        }

        //If its "delete", reset previous box
        else if (validInput == true && inputType == 3)
        {
            //Clear Current Box

            //Go back a box

            //Clear that Box
        }

        //Testing
        //resultChecked = true;

        //Reset the textbox
        validInput = false;
        userInput.Text = string.Empty;
    }

    public void CheckResult(object sender, EventArgs e)
    {
        //Check to see if all 5 boxes are fillout out
        if (userInputs[0] != string.Empty && userInputs[1] != string.Empty && userInputs[2] != string.Empty && userInputs[3] != string.Empty && userInputs[4] != string.Empty)
        {
            //For loop that goes through each of the boxes comparing the inputs to the chosen word
            for (j = 0; j < 5; j++)
            {
                //If input is correct give it value of 1 and make it green
                if (userInputs[j] == wordLetters[j])
                {

                }

                //If input is correct but in wrong place give it value of 2 and make it yellow
                else if (userInputs[j] != wordLetters[j] && (userInputs[j] == wordLetters[0] || userInputs[j] == wordLetters[1] || userInputs[j] == wordLetters[2] || userInputs[j] == wordLetters[3] || userInputs[j] == wordLetters[4]))
                {

                }

                //If input is incorrect give it a value of 3 and make it grey
                else
                {

                }
            }

            //If all are correct then victory
            if (userInputs[0] == wordLetters[0] && userInputs[1] == wordLetters[1] && userInputs[2] == wordLetters[2] && userInputs[3] == wordLetters[3] && userInputs[4] == wordLetters[4])
            {
                gameWon = true;
                resultChecked = true;
            }

            //If not all are correct then continue to next round
            else
            {
                resultChecked = true;
            }
        }

        else
        {
            userInput.Text = string.Empty;
        }
    }//End of Check Result
    
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
        inputType = 0;
        //Check to see if the entry is a letter

        for(int j = 0; j < Letters.Length; j++)
        {
            if(userInput.Text == Letters[i])
            {
                inputType = 1;
                validInput = true;
            }
        }

        //Check to see if the entry is Delete
        if(j == 15)
        {
            inputType = 3;
            validInput = true;
        }

        //If invalid set to false
        else
        {
            inputType = 0;
            validInput = false;
        }
    }

    public async void GameResult()
    {
        if(gameWon == true) //Victory
        {

        }

        else if(gameWon == false) //Loss
        {

        }

        //Display Game Results

        //Save Results to TxT File
        SaveGame();
    }

    public void SaveGame()
    {
        //Testing Player Name
        PlayerName = "Melissa";
    }

    public async void OpenResultsPage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Pages.ResultsPage(PlayerName));
    }

    public async void OpenHomePage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Pages.HomePage(PlayerName));
    }
}