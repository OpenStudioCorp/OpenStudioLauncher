using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IronPython.Hosting;
using IronPython.Runtime;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Windows;
using static IronPython.Modules.unicodedata;
using static OpenStudioLauncher.MainWindow;


namespace OpenStudioLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StringWriter consoleWriter;
        List<Project> projects;
        public MainWindow()
        {
            InitializeComponent();
            // Create a StringWriter to capture the console output.
            consoleWriter = new StringWriter();
            Console.SetOut(consoleWriter);

            // Start a timer to update the TextBox periodically (optional).
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500); // Update every 500 milliseconds
            timer.Tick += UpdateConsoleTextBox;
            timer.Start();

        }

        private void projectsButton_Click(object sender, RoutedEventArgs e)
        {
            //projectspage
        }

        private void aboutbutton_click(object sender, RoutedEventArgs e)
        {
            //about
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            Window1 newWindow = new Window1();
            newWindow.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //help
        }

        public async Task<string> FetchJsonData(string url)
        {
            using HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return null;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public static class JsonHelper
        {
            public static string GetJsonStringFromUrl(string url)
            {
                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        return webClient.DownloadString(url);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while fetching JSON data: {ex.Message}");
                    return null;
                }
            }
            
        }
        private void FetchAndPrintJsonButton_Click(object sender, RoutedEventArgs e)
        {
            // Replace 'your_url_here' with the actual URL of the JSON file on the web server
            string url = "http://127.0.0.1:3000/OpenStudioCorpProjects.json";

            string json = JsonHelper.GetJsonStringFromUrl(url);

            if (!string.IsNullOrEmpty(json))
            {
                // Deserialize the JSON data into a list of Project objects.
                projects = JsonConvert.DeserializeObject<List<Project>>(json);

                if (projects != null)
                {
                    // Output the projects to the console (emulated TextBox).
                    foreach (var project in projects)
                    {
                        Console.WriteLine($"Name: {project.Name}");
                        Console.WriteLine($"Description: {project.Description}");
                        Console.WriteLine($"Version: {project.Version}");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Unable to fetch or parse JSON data.");
                    MessageBox.Show("Unable to fetch or parse JSON data.");
                }
            }
        }
        public class Project
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Version { get; set; }
        }
        private void UpdateConsoleTextBox(object sender, EventArgs e)
        {
            consoleTextBox.Text = consoleWriter.ToString();
            consoleTextBox.ScrollToEnd(); // Scroll to the end to show the latest content
        }
    }
}
