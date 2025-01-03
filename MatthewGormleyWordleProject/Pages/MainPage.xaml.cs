using Microsoft.Maui;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;

namespace MatthewGormleyWordleProject
{
    public partial class MainPage : ContentPage
    {
        public string FileUrl = "https://raw.githubusercontent.com/DonH-ITS/jsonfiles/main/words.txt";
        public string localPath = "C:\\Users\\kelpi\\source\\repos\\MatthewGormleyWordleProject\\MatthewGormleyWordleProject";
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

            //Checking or downloading list of words
            //DownloadList(); //This is crashing the application //Randomly the loading will appear and then stop

        }

        public async void DownloadList()
        {
            //Using File.Exists to check if it exists
            if (!File.Exists(localPath))
            {
                //Test: PlayButton.Text = "File does not exist";
                //Create http client to interact with internet
                HttpClient client = new HttpClient();
                var response = await client.GetAsync("https://raw.githubusercontent.com/DonH-ITS/jsonfiles/main/words.txt");//Lab 9 content template

                if (response.IsSuccessStatusCode)
                {
                    string fileContent = await response.Content.ReadAsStringAsync(); //"= await response.Content.ReadAsStringAsync();" was auto filled out when I wrote fileContent
                    //use localPath to place the file, write using "WriteAllTextAsync" method
                    await File.WriteAllTextAsync(localPath, fileContent);//Originally used WriteAllLinesAsync but that did not work with the input type
                }
            }

            //Read from the file and grab a word
        }


        public async void OpenGamePage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Pages.GamePage());
        }

        public async void OpenResultsPage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Pages.ResultsPage());
        }
    }

}
