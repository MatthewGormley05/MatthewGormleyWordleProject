//using Android.Text;
//using Java.Lang;
//using GameKit;
using Microsoft.Maui;

namespace MatthewGormleyWordleProject.Pages;

public partial class GamePage : ContentPage
{
    //Variables
    public int i = 0, j = 0, k = 0, selectedColumn = 0, selectedRow = 0, roundNumber = 1, inputType = 0, randomLineNumber = 0, Guesses;
    public string chosenWord = string.Empty, userWord = string.Empty, currentInput = string.Empty, saveFileName = string.Empty, saveFileData = string.Empty, validationInput = string.Empty;
    public string[] userInputs = { string.Empty, string.Empty, string.Empty, string.Empty, string.Empty }, wordLetters = { string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
    public int[,] attemptsGrid = { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
    public bool gameWon = false, resultChecked = false, validInput = false, processingTextChange = false;
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
        MakeGrid();
        RandomWord();

        //Break down word into letters to be compared to user inputs
        for (int i = 0; i < 5; i++)
        {
            wordLetters[i] = chosenWord.Substring(i, 1);
        }

        GameStarted();

        //Testing
        //SaveGame();
    }

    public async void GameStarted()
    {
        //Popup that explains the game
        StartAlert();

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

                //Testing
                //resultChecked = true;
            }

            //Check if game was won at end of round, if so break the for loop
            if (gameWon == true)
            {
                break;
            }

            //Move to next row
            if(selectedRow < 5)
            {
                selectedRow++;
            }
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
            chosenWord = chosenWord.ToUpper();

            //Testing Word
            //WordTest.Text = chosenWord;
        }
    }
    
    
    public void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        //Validation check is done on text change
        InputValidation();
        
        //If its one of the letters, fill out the current input with it
        if (validInput == true)
        {
            //Set current input
            currentInput = validationInput;
            validationInput = string.Empty;

            //Change box text by making new box
            Label label = new Label()
            {
                Text = currentInput,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 20,
                TextColor = Colors.White
                //Change Font Family
            };
            GameGrid.Add(label, selectedColumn, selectedRow);
            

            //Set the store array value
            userInputs[selectedColumn] = currentInput;

            //Clear input
            currentInput = string.Empty;

            //Go to the next box
            if (selectedColumn < 4)
            {
                selectedColumn++;
            }

            //Testing
            //resultChecked = true;
        }

        //Reset
        validInput = false;
        userInput.Text = "";
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

                    //Change Border
                    Border border = new Border()
                    {
                        BackgroundColor = Colors.Green,
                        HeightRequest = 38,
                        WidthRequest = 38
                    };

                    GameGrid.Add(border, selectedColumn, selectedRow);

                    //Change Label
                    Label label = new Label()
                    {
                        Text = userInputs[j],
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        FontSize = 20,
                        TextColor = Colors.White,
                        //Change Font Family
                    };
                    GameGrid.Add(label, selectedColumn, selectedRow);
                }

                //If input is correct but in wrong place give it value of 2 and make it yellow
                else if (userInputs[j] != wordLetters[j] && (userInputs[j] == wordLetters[0] || userInputs[j] == wordLetters[1] || userInputs[j] == wordLetters[2] || userInputs[j] == wordLetters[3] || userInputs[j] == wordLetters[4]))
                {
                    //Set Result
                    attemptsGrid[selectedRow, selectedColumn] = 2;

                    //Change Border
                    Border border = new Border()
                    {
                        BackgroundColor = Colors.YellowGreen,
                        HeightRequest = 38,
                        WidthRequest = 38
                    };

                    GameGrid.Add(border, selectedColumn, selectedRow);

                    //Change Label
                    Label label = new Label()
                    {
                        Text = userInputs[j],
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        FontSize = 20,
                        TextColor = Colors.White
                        //Change Font Family
                    };
                    GameGrid.Add(label, selectedColumn, selectedRow);
                }

                //If input is incorrect give it a value of 3 and make it grey
                else
                {
                    //Change Border
                    Border border = new Border()
                    {
                        BackgroundColor = Colors.Grey,
                        HeightRequest = 38,
                        WidthRequest = 38
                    };

                    GameGrid.Add(border, selectedColumn, selectedRow);

                    //Change Label
                    Label label = new Label()
                    {
                        Text = userInputs[j],
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        FontSize = 20,
                        TextColor = Colors.White
                        //Change Font Family
                    };
                    GameGrid.Add(label, selectedColumn, selectedRow);
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

                
                //Reset user inputs
                for(j = 0; j < 5; j++)
                {
                    userInputs[j] = string.Empty;
                }
                
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
                Border border = new Border()
                {
                    BackgroundColor = Colors.Gray,
                    HeightRequest = 38,
                    WidthRequest = 38
                };

                GameGrid.Add(border, i, j);
            }
        } 
    }//End of MakeGrid

    public void StartAlert()
    {
        string alertContent = "* You have 6 attempts to guess the right word\n* Click on the Text Box and type to enter Letters\n* Press Delete to remove an entry\n* Press enter to confirm your guess!";
        DisplayAlert("Wordle: How to play", alertContent, "OK");
    }
    
    public void InputValidation()
    {
        //False by default
        validInput = false;

        //Check to see if the entry is text
        if (userInput.Text != string.Empty && userInput.Text != " " && userInput.Text != "" && userInputs[4] == string.Empty)
        {
            //ValidInput = true;
            validationInput = userInput.Text;
            validationInput = validationInput.ToUpper();

            //DisplayAlert("INFO", validationInput, "CLOSE");
            
            
            //Check to see if the entry is a letter
            for (int j = 0; j < Letters.Length; j++)
            {
                if (validationInput == Letters[j])
                {
                    inputType = 1;
                    validInput = true;
                    break;
                }
            }
            
        }
        
    }

    public void GameResult()
    {
        SaveGame();

        string gameDoneContent = "The word was: " + chosenWord + "\nGo to the results page to view your stats";
        if(gameWon == true) //Victory
        {
            DisplayAlert("You won!", gameDoneContent, "OK");
            userInput.IsVisible = false;
            ResultsButton.IsVisible = true;
        }

        else if(gameWon == false) //Loss
        {
            DisplayAlert("You lost!", gameDoneContent, "OK");
            userInput.IsVisible = false;
            ResultsButton.IsVisible = true;
        }
    }

    public void SaveGame()
    {
        //Testing Different Values
        /*
        PlayerName = "Melissa"; //Will be used to make file name, not saved in file
        chosenWord = "Fishy";
        gameWon = true;
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
        //End of testing*/

        //Pathing
        string playerFile = PlayerName + ".txt";
        string path = FileSystem.Current.AppDataDirectory;
        string fullPath = Path.Combine(path, playerFile);

        //Formatted as:
        //Game Word
        //Game Result
        //Guesses
        //Array

        //Game word
        saveFileData = "Winning Word: " + chosenWord;

        //Win or loss
        saveFileData += "\n";
        if (gameWon == true)
        {
            saveFileData += "Game Result: Win";
        }
        else
        {
            saveFileData += "Game Result: Loss";
        }

        //Guesses
        Guesses = selectedRow + 1;
        saveFileData += "\n";
        saveGameGuesses = Guesses.ToString();
        saveFileData += "Guesses: " + saveGameGuesses;

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

        //Save to file
        File.AppendAllText(fullPath, saveFileData);
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