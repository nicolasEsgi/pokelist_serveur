using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace PokeList_UWP
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class RootPage : Page
    {
        private bool isSplitViewPaneOpen;
        public RootPage()
        {
            this.InitializeComponent();
            // add entry animations
            var transitions = new TransitionCollection { };
            var transition = new NavigationThemeTransition { };
            transitions.Add(transition);
            this.mainFrame.ContentTransitions = transitions;

            bool isHardwareButtonsAPIPresent = Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons");
            var view = SystemNavigationManager.GetForCurrentView();
            view.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            view.BackRequested += View_BackRequested;
            if (isHardwareButtonsAPIPresent)
            {
                HardwareButtons.BackPressed +=
                    BackRequested;
            }
        }

        private void BackRequested(object sender, BackPressedEventArgs e)
        {
            if (this.mainFrame.CanGoBack)
            {
                //if (isPhoneVsActive.IsOn)
                //{

                //}

                this.mainFrame.GoBack();
                e.Handled = true;
            }
        }

        private void View_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (this.mainFrame.CanGoBack)
            {
                //if (isPhoneVsActive.IsOn)
                //{

                //}

                this.mainFrame.GoBack();
                e.Handled = true;
            }
        }

        public bool IsSplitViewPaneOpen
        {
            get { return this.isSplitViewPaneOpen; }
            set { this.isSplitViewPaneOpen = value; }
        }

        private void menuToggle_Click(object sender, RoutedEventArgs e)
        {
            this.mainSplitView.IsPaneOpen = !this.mainSplitView.IsPaneOpen;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.mainFrame.Navigate(typeof(HomePage));
        }
    }
}
