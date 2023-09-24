using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


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
							if (parts[0] == "SoundEnabled")
							{
								SoundSwitch.IsToggled = bool.Parse(parts[1]);
							}
							else if (parts[0] == "NotificationsEnabled")
							{
								NotificationsSwitch.IsToggled = bool.Parse(parts[1]);
							}
						}
					}
				}
			}
		}

		private void OnSaveClicked(object sender, EventArgs e)
		{
			// Save the sound and notifications settings
			bool soundEnabled = SoundSwitch.IsToggled;
			bool notificationsEnabled = NotificationsSwitch.IsToggled;

			// Save the settings to a file
			string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "settings.txt");
			using (StreamWriter writer = new StreamWriter(filePath))
			{
				writer.WriteLine($"SoundEnabled={soundEnabled}");
				writer.WriteLine($"NotificationsEnabled={notificationsEnabled}");
			}
		}
	}
}