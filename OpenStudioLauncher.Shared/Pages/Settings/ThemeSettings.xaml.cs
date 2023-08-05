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


namespace OpenStudioLauncher.Pages.Settings;

public sealed partial class ThemeSettingsPage : Page
{

    public ThemeSettingsPage()
    {
        this.InitializeComponent();
    }

}