using Microsoft.Maui;

namespace MatthewGormleyWordleProject.Pages;

public partial class GamePage : ContentPage
{
	public GamePage()
	{
		InitializeComponent();
        makeGrid();
	}

    public async void openResultsPage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Pages.ResultsPage());
    }

    public async void OpenHomePage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Pages.HomePage());
    }

    public void makeGrid()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 6; j++)
            {
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
}