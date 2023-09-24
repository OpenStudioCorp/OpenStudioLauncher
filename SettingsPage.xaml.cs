using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
namespace MauiApp2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage()
		{
			InitializeComponent();

			// Load the sound and notifications settings
			string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "settings.txt");
			if (File.Exists(filePath))
			{
				using (StreamReader reader = new StreamReader(filePath))
				{
					string line;
					while ((line = reader.ReadLine()) != null)
					{
						string[] parts = line.Split('=');
						if (parts.Length == 2)
						{
							
							NotificationsSwitch.IsToggled = parts[0] == "NotificationsEnabled" ? bool.Parse(parts[1]) : NotificationsSwitch.IsToggled;
							AppSoundsSwitch.IsToggled = parts[0] == "AppSoundsEnabled" ? bool.Parse(parts[1]) : AppSoundsSwitch.IsToggled;
							UpdateNotificationsSwitch.IsToggled = parts[0] == "UpdateNotificationsEnabled" ? bool.Parse(parts[1]) : UpdateNotificationsSwitch.IsToggled;
							LanguagePicker.SelectedItem = parts[0] == "SelectedLanguage" ? parts[1] : LanguagePicker.SelectedItem;
						}
					}
				}
			}
		}

		private void OnSaveClicked(object sender, EventArgs e)
		{
			// Save the sound and notifications settings
			bool soundEnabled = AppSoundsSwitch.IsToggled;
			bool notificationsEnabled = NotificationsSwitch.IsToggled;
            bool appSoundsEnabled = AppSoundsSwitch.IsToggled;
            bool updateNotificationsEnabled = UpdateNotificationsSwitch.IsToggled;
            string selectedLanguage = LanguagePicker.SelectedItem.ToString();
			

			// Save the settings to a file
			string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "settings.txt");
			using (StreamWriter writer = new StreamWriter(filePath))
			{
				writer.WriteLine($"SoundEnabled={soundEnabled}");
				writer.WriteLine($"NotificationsEnabled={notificationsEnabled}");
				writer.WriteLine($"AppSoundsEnabled={appSoundsEnabled}");
				writer.WriteLine($"UpdateNotificationsEnabled={updateNotificationsEnabled}");
				writer.WriteLine($"SelectedLanguage={selectedLanguage}");
			}
		}
	}
}