using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Uno.Extensions;
using Uno.Extensions.Hosting;
using Uno.Extensions.Logging;
using Uno.Extensions.Navigation;
using Uno.Extensions.Navigation.Navigators;
using Uno.Extensions.Navigation.Regions;
using Uno.Extensions.Navigation.UI;
using Uno.Extensions.Navigation.UI.Controls;
using OpenStudioLauncher.Pages.Settings;

namespace OpenStudioLauncher.Pages;

public sealed partial class SettingsPage : Page
{

    public SettingsPage()
    {
        this.InitializeComponent();
    }

    private void btn_ideSettingsClick(object sender, RoutedEventArgs e)
    {
        this.NavigationFrame.Navigate(typeof(IdeSettingsPage));
    }

    private void btn_projectSettingsClick(object sender, RoutedEventArgs e)
    {
        this.NavigationFrame.Navigate(typeof(GeneralSettingsPage));
    }

    private void btn_themeSettingsClick(object sender, RoutedEventArgs e)
    {
        this.NavigationFrame.Navigate(typeof(ThemeSettingsPage));
    }

    private void btn_generalSettingsClick(object sender, RoutedEventArgs e)
    {
        this.NavigationFrame.Navigate(typeof(GeneralSettingsPage));
    }

    private void btn_backClick(object sender, RoutedEventArgs e)
    {
        this.Frame.GoBack();
    }

}