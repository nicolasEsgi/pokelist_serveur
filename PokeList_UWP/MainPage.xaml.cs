using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PokeList_UWP
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = false;
            var applicationView = ApplicationView.GetForCurrentView();
            var brush = (Brush)this.Resources["appColorPressed"];
            var brush2 = (Brush)this.Resources["appColorDark"];
            var brush3 = (Brush)this.Resources["appColorHover"];
            var brushInactive = (Brush)this.Resources["appColor"];
            applicationView.SetPreferredMinSize(new Size(330, 400));
            var titleBar = applicationView.TitleBar;
            titleBar.ButtonBackgroundColor = (brush2 as SolidColorBrush).Color;
            titleBar.ButtonHoverBackgroundColor = (brush3 as SolidColorBrush).Color;
            titleBar.ButtonHoverForegroundColor = Colors.White;
            titleBar.ButtonInactiveBackgroundColor = (brushInactive as SolidColorBrush).Color;
            titleBar.ButtonInactiveForegroundColor = Colors.White;
            titleBar.ButtonPressedBackgroundColor = (brush as SolidColorBrush).Color;
            titleBar.ButtonPressedForegroundColor = Colors.White;
            titleBar.ButtonForegroundColor = Colors.White;
            titleBar.BackgroundColor = (brush2 as SolidColorBrush).Color;
            titleBar.InactiveBackgroundColor = (brushInactive as SolidColorBrush).Color;
            titleBar.InactiveForegroundColor = Colors.White;
            titleBar.ForegroundColor = Colors.White;
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                StatusBar statusBar = StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = (brush as SolidColorBrush).Color;
                statusBar.BackgroundOpacity = 100;
                statusBar.ForegroundColor = Colors.White;
                var iasync = statusBar.ShowAsync();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RootPage));
        }
    }
}
