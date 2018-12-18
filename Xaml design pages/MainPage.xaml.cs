using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using App8;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App8
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            
            App.Current.Resources["ButtonBackgroundPointerOver"] = new SolidColorBrush(Colors.LightGray);
            App.Current.Resources["ButtonForegroundPointerOver"] = new SolidColorBrush(Colors.DarkSlateGray);
            App.Current.Resources["ButtonBorderBrushPointerOver"] = new SolidColorBrush(Colors.DarkSlateGray);

            Login_Box.Visibility = Visibility.Collapsed;
            Register_Box.Visibility = Visibility.Collapsed;

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            // Opens Login Box
            Login_Box.Visibility = Visibility.Visible;
            Welcome_Box.Visibility = Visibility.Collapsed;
            Register_Box.Visibility = Visibility.Collapsed;
        }

        private void ButtonBase_Movie_OnClick(object sender, RoutedEventArgs e)
        {
            Frame CurrFrame = (Frame)Window.Current.Content;
            CurrFrame.Navigate(typeof(BookingView));
        }

        private void Close_Box_OnClick_OnClick(object sender, RoutedEventArgs e)
        {
            // Opens Welcome Box again
            Welcome_Box.Visibility = Visibility.Visible;
            Login_Box.Visibility = Visibility.Collapsed;
            Register_Box.Visibility = Visibility.Collapsed;
        }

        private void ButtonBase_OnClick2(object sender, RoutedEventArgs e)
        {
            // Opens Register Box
            Register_Box.Visibility = Visibility.Visible;
            Welcome_Box.Visibility = Visibility.Collapsed;
            Login_Box.Visibility = Visibility.Collapsed;
        }
    }
}
