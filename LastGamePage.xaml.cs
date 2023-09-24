using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace MauiApp2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LastGamePage : ContentPage
    {
        public LastGamePage()
        {
            InitializeComponent();
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            // Save the last game played
            string gameName = GameNameEntry.Text;
            int score = int.Parse(ScoreEntry.Text);
            // TODO: Save the last game played
        }
    }
}