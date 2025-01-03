using Microsoft.Maui;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;

namespace MatthewGormleyWordleProject
{
    public partial class MainPage : ContentPage
    {
        public string FileUrl = "https://raw.githubusercontent.com/DonH-ITS/jsonfiles/main/words.txt";
        public string localPath = "test.txt";
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

            //Checking or downloading list of words
            //Main Page is only opened once to make sure that the application doesn't crash when downloading
            Test.Text = "Not successful";
            //DownloadList();
            OpenHomePage();
        }

        public async void DownloadList()
        {
            //Change for Phone
            //Create http client to interact with internet
            HttpClient client = new HttpClient();

            //Using File.Exists to check if the file exists
            if (!File.Exists(localPath))
            {
                //Test: PlayButton.Text = "File does not exist";
                var response = await client.GetAsync("https://raw.githubusercontent.com/DonH-ITS/jsonfiles/main/words.txt");//Lab 9 content template

                if (response.IsSuccessStatusCode)
                {
                    string fileContent = await response.Content.ReadAsStringAsync(); //"= await response.Content.ReadAsStringAsync();" was auto filled out when I wrote fileContent
                    //use localPath to place the file, write using "WriteAllTextAsync" method
                    await File.WriteAllTextAsync(localPath, fileContent);//Originally used WriteAllLinesAsync but that did not work with the input type
                }
            }

            else if(File.Exists(localPath))
            {
                Test.Text = "File Exists";
            }
            //Read from the file and grab a word
        }

        public async void OpenHomePage()
        {
            await Navigation.PushModalAsync(new Pages.HomePage());
        }
    }

}
