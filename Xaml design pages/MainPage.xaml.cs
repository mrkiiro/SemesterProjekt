﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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

            Button b = new Button();
            App.Current.Resources["ButtonBackgroundPointerOver"] = new SolidColorBrush(Colors.Aqua);
            App.Current.Resources["ButtonForegroundPointerOver"] = new SolidColorBrush(Colors.DarkBlue);
            App.Current.Resources["ButtonBorderBrushPointerOver"] = new SolidColorBrush(Colors.DarkBlue);

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Frame CurrFrame = (Frame)Window.Current.Content;
            CurrFrame.Navigate(typeof(BookingView));
        }
    }
}
