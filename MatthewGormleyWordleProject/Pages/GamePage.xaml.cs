//using Android.Text;
//using Java.Lang;
//using GameKit;
using Microsoft.Maui;

namespace MatthewGormleyWordleProject.Pages;

public partial class GamePage : ContentPage
{
    //Variables
    public int i = 0, j = 0, k = 0, selectedColumn = 0, selectedRow = 0, roundNumber = 1, inputType = 0, randomLineNumber = 0, Guesses;
    public string chosenWord = string.Empty, userWord = string.Empty, currentInput = string.Empty, saveFileName = string.Empty, saveFileData = string.Empty;
    public string[] userInputs = { string.Empty, string.Empty, string.Empty, string.Empty, string.Empty }, wordLetters = { string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
    public int[,] attemptsGrid = { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
    public bool gameWon = false, resultChecked = false, validInput = false;
    public string[] Letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
    public double Time = 0;
    public string saveGameResult, saveGameGuesses, saveGameTime, saveArray;

    //Player Name
    public string PlayerName;

    //Initialise Pages Methods for future use
    public PagesMethods pagesMethods = new PagesMethods();
    public GamePage(string playerName)
    {
        InitializeComponent();
        PlayerName = playerName;
        BindingContext = this;
        //MakeGrid();
        //GameStarted();

        //Testing
        //SaveGame();
        //RandomWord();
    }

    public async void GameStarted()
    {
        //Backup random word
        chosenWord = "FISHY";

        //Choose random word
        RandomWord();

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
            selectedColumn = 0;
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
                //resultChecked = true;
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

    public void RandomWord()
    {
        Random random = new Random();

        //Pathing
        string path = FileSystem.Current.AppDataDirectory;
        string fullPath = Path.Combine(path, "WordleWords.txt");

        //Check for file
        if (File.Exists(fullPath) == false)
        {
            DisplayAlert("Error", "File not found", "OK");
        }

        else
        {
            //Read in file as array value
            string[] lines = File.ReadAllLines(fullPath);

            //Choose Random Number
            randomLineNumber = random.Next(1, 3001);

            //Set string to the word on that random line
            chosenWord = lines[randomLineNumber - 1];

            //Testing Word
            //DisplayAlert("Success", chosenWord, "OK");
        }
    }
    
    public void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        //Validation check is done on text change
        InputValidation();

        //If its one of the letters, fill out the current input with it
        if (validInput == true && inputType == 1)
        {
            //Set current input
            currentInput = userInput.Text;

            //Change box text by making new box
            Entry entry = new Entry()
            {
                BackgroundColor = Colors.Black,
                HeightRequest = 38,
                WidthRequest = 38,
                IsReadOnly = true,
                Text = currentInput
            };

            GameGrid.Add(entry, selectedColumn, selectedRow);

            Frame frame = new Frame
            {
                BorderColor = Colors.LightGray,
                BackgroundColor = Colors.Black,
                Padding = 0,
                HeightRequest = 40,
                WidthRequest = 40,
                CornerRadius = 3
            };

            GameGrid.Add(frame, selectedColumn, selectedRow);

            //Set the store array value
            userInputs[selectedColumn] = currentInput;

            //Clear input
            currentInput = string.Empty;
            userInput.Text = string.Empty;

            //Go to the next box
            selectedColumn++;
        }

        //If its "delete", reset previous box
        else if (validInput == true && inputType == 2)
        {
            //Clear Current Box
            Entry entry = new Entry()
            {
                BackgroundColor = Colors.Black,
                HeightRequest = 38,
                WidthRequest = 38,
                IsReadOnly = true,
                Text = string.Empty
            };

            GameGrid.Add(entry, selectedColumn, selectedRow);

            Frame frame = new Frame
            {
                BorderColor = Colors.LightGray,
                BackgroundColor = Colors.Black,
                Padding = 0,
                HeightRequest = 40,
                WidthRequest = 40,
                CornerRadius = 3
            };

            GameGrid.Add(frame, selectedColumn, selectedRow);

            //Go back a box
            selectedColumn--;

            //Clear that Box
            GameGrid.Add(entry, selectedColumn, selectedRow);
            GameGrid.Add(frame, selectedColumn, selectedRow);

        }

        //Testing
        resultChecked = true;

        //Reset the textbox
        validInput = false;
        userInput.Text = " ";
    }

    public void CheckResult(object sender, EventArgs e)
    {
        //Check to see if all 5 boxes are fillout out
        if (userInputs[0] != string.Empty && userInputs[1] != string.Empty && userInputs[2] != string.Empty && userInputs[3] != string.Empty && userInputs[4] != string.Empty)
        {
            //For loop that goes through each of the boxes comparing the inputs to the chosen word
            for (j = 0; j < 5; j++)
            {
                selectedColumn = j;
                //If input is correct give it value of 1 and make it green
                if (userInputs[j] == wordLetters[j])
                {
                    //Set Result
                    attemptsGrid[selectedRow, selectedColumn] = 1;

                    //Change Grid Entry
                    Entry entry = new Entry()
                    {
                        BackgroundColor = Colors.Green,
                        HeightRequest = 38,
                        WidthRequest = 38,
                        IsReadOnly = true,
                        Text = userInputs[j]
                    };

                    GameGrid.Add(entry, selectedColumn, selectedRow);

                    Frame frame = new Frame
                    {
                        BorderColor = Colors.LightGray,
                        BackgroundColor = Colors.Green,
                        Padding = 0,
                        HeightRequest = 40,
                        WidthRequest = 40,
                        CornerRadius = 3,
                    };

                    GameGrid.Add(frame, selectedColumn, selectedRow);
                }

                //If input is correct but in wrong place give it value of 2 and make it yellow
                else if (userInputs[j] != wordLetters[j] && (userInputs[j] == wordLetters[0] || userInputs[j] == wordLetters[1] || userInputs[j] == wordLetters[2] || userInputs[j] == wordLetters[3] || userInputs[j] == wordLetters[4]))
                {
                    //Set Result
                    attemptsGrid[selectedRow, selectedColumn] = 2;

                    //Change Grid Entry
                    Entry entry = new Entry()
                    {
                        BackgroundColor = Colors.Yellow,
                        HeightRequest = 38,
                        WidthRequest = 38,
                        IsReadOnly = true,
                        Text = userInputs[j]
                    };

                    GameGrid.Add(entry, selectedColumn, selectedRow);

                    Frame frame = new Frame
                    {
                        BorderColor = Colors.LightGray,
                        BackgroundColor = Colors.Yellow,
                        Padding = 0,
                        HeightRequest = 40,
                        WidthRequest = 40,
                        CornerRadius = 3,
                    };

                    GameGrid.Add(frame, selectedColumn, selectedRow);
                }

                //If input is incorrect give it a value of 3 and make it grey
                else
                {
                    //Set Result
                    attemptsGrid[selectedRow, selectedColumn] = 3;

                    //Change Grid Entry
                    Entry entry = new Entry()
                    {
                        BackgroundColor = Colors.Gray,
                        HeightRequest = 38,
                        WidthRequest = 38,
                        IsReadOnly = true,
                        Text = userInputs[j]
                    };

                    GameGrid.Add(entry, selectedColumn, selectedRow);

                    Frame frame = new Frame
                    {
                        BorderColor = Colors.LightGray,
                        BackgroundColor = Colors.Gray,
                        Padding = 0,
                        HeightRequest = 40,
                        WidthRequest = 40,
                        CornerRadius = 3,
                    };

                    GameGrid.Add(frame, selectedColumn, selectedRow);
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
            DisplayAlert("Attention", "Please fill out all the boxes", "OK");
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
                    WidthRequest = 38,
                    IsReadOnly = true
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
        //Default input result
        inputType = 0;

        //Check to see if the entry is text
        if (userInput.Text != string.Empty)
        {
            userInput.Text = userInput.Text.ToUpper();

            //Check to see if the entry is a letter
            for (int j = 0; j < Letters.Length; j++)
            {
                if (userInput.Text == Letters[i])
                {
                    inputType = 1;
                    validInput = true;
                }
            }
        }

        //Check to see if the entry is Delete
        else if(j == 15)
        {
            inputType = 2;
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

        //Display Game Results with pop ups

        //Save Results to TxT File
        SaveGame();
    }

    public void SaveGame()
    {
        //Testing Different Values
        PlayerName = "Melissa"; //Will be used to make file name, not saved in file
        chosenWord = "Fishy";
        gameWon = true;
        Time = 59;
        Guesses = 5;
        saveFileData = "test";

        Random random = new Random();
        int randomResult;

        //Emoji Grid Tracker
        //1 = correct, 2 = half correct, 3 = wrong
        for(int i = 0; i < 6; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                randomResult = random.Next(1, 3);
                attemptsGrid[i, j] = randomResult;
            }
        }
        //End of testing

        //Pathing
        string playerFile = PlayerName + ".txt";
        string path = FileSystem.Current.AppDataDirectory;
        string fullPath = Path.Combine(path, playerFile);

        //Formatted as:
        //Game Word
        //Game Result
        //Guesses
        //Timer
        //Array

        saveFileData = "\n"; //Start new entry with new line

        //Game word
        saveFileData += "\n";
        saveFileData += chosenWord;

        //Win or loss
        saveFileData += "\n";
        if (gameWon == true)
        {
            saveGameResult = "1"; //1 is win
            saveFileData += saveGameResult;
        }
        else
        {
            saveGameResult = "0"; //0 is loss
            saveFileData += saveGameResult;
        }

        //Guesses
        saveFileData += "\n";
        saveGameGuesses = Guesses.ToString();
        saveFileData += saveGameGuesses;

        //Time
        saveFileData += "\n";
        saveGameTime = Time.ToString();
        saveFileData += saveGameTime;


        //Array
        for (i = 0; i < 6; i++)
        {
            //New Row
            saveFileData += "\n";
            for (j = 0; j < 5; j++)
            {
                //Win
                if(attemptsGrid[i, j] == 1)
                {
                    saveArray = "1";
                }

                //Half Win
                else if(attemptsGrid[i, j] == 2)
                {
                    saveArray = "2";
                }

                //Loss
                else if(attemptsGrid[i, j] == 0)
                {
                    saveArray = "0";
                }

                saveFileData += saveArray;
            }
        }
        //End of entry
        saveFileData += "\n";
        saveFileData += "\n";

        //Testing saveFileData
        DisplayAlert("Save Info", saveFileData, "CLOSE");

        //Save to file
        File.WriteAllText(fullPath, saveFileData); //Causing Crashes
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