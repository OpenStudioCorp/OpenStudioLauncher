using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace MauiApp2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnLastGameClicked(object sender, EventArgs e)
        {
            // Navigate to the last game played page
            await Navigation.PushAsync(new LastGamePage());
        }

        private async void OnSettingsClicked(object sender, EventArgs e)
        {
            // Navigate to the settings page
            await Navigation.PushAsync(new SettingsPage());
        }
    }
}