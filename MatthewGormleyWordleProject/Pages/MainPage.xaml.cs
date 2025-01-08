using Microsoft.Maui;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;
using MatthewGormleyWordleProject.Pages;

namespace MatthewGormleyWordleProject
{
    public partial class MainPage : ContentPage
    {
        //Initialise Pages Methods for future use
        public PagesMethods pagesMethods = new PagesMethods();

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

            //Checking or downloading list of words
            //Main Page is only opened once to make sure that the application doesn't crash when downloading
            Test.Text = "Not successful";
            //DownloadList();
            PagesMethods pagesMethods = new PagesMethods();
            OpenLogInPage();
        }

        public async void DownloadList()
        {
            //Pathing
            string localPath = FileSystem.Current.AppDataDirectory;
            string fileName = "DownloadedWordleWords.txt";
            string fullPath = Path.Combine(localPath, fileName);

            //Create http client to interact with internet
            HttpClient client = new HttpClient();

            //Using File.Exists to check if the file exists
            if (!File.Exists(fullPath))
            {
                //Test: PlayButton.Text = "File does not exist";
                var response = await client.GetAsync("https://raw.githubusercontent.com/DonH-ITS/jsonfiles/main/words.txt");//Lab 9 content template

                if (response.IsSuccessStatusCode)
                {
                    string fileContent = await response.Content.ReadAsStringAsync(); //"= await response.Content.ReadAsStringAsync();" was auto filled out when I wrote fileContent
                    //use fullPath to place the file, write using "WriteAllTextAsync" method
                    await File.WriteAllTextAsync(fullPath, fileContent);//Originally used WriteAllLinesAsync but that did not work with the input type
                    await DisplayAlert("File Created", "File was created", "OK");
                }
            }

            else if(File.Exists(fullPath))
            {
                await DisplayAlert("File Exists", "File already exists", "OK");
            }
            //Read from the file and grab a word
        }

        public async void OpenLogInPage()
        {
            await Navigation.PushModalAsync(new Pages.LogInPage());
        }
    }

}
