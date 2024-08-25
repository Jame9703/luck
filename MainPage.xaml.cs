using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using System.Diagnostics;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace luck
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            // 隐藏标题栏

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button btn = new Button();
                    btn.Width = 90;
                    btn.Height = 60;  
                    btn.Background = new SolidColorBrush(Colors.LightBlue); 
                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);
                    btn.Name = (i * 10 + j + 1).ToString();
                    btn.Content = (i * 10 + j + 1).ToString();
                    btn.FontFamily = new FontFamily("ms-appx:///Assets/Fonts/HarmonyOS_Sans_SC_Medium.ttf#HarmonyOS Sans SC");
                    btn.FontSize = 30;
                    btn.Click += Button_Click_1;
                    select.Children.Add(btn);
                }
            }

            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            ApplicationViewTitleBar formattableTitleBar = ApplicationView.GetForCurrentView().TitleBar;
            formattableTitleBar.ButtonBackgroundColor = Colors.Transparent;
        }
        bool IsSelect = false;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!IsSelect)
            {
                IsSelect = true;
                Button thisClickedButton = sender as Button;
                string name = thisClickedButton.Name;
                (Application.Current as App).Award.store_inputnum(name);
                InputTextBox.Text = (Application.Current as App).Award.get_inputnum();
                thisClickedButton.Background = new SolidColorBrush(Colors.Green);

            }

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Frame.Navigate(typeof(ResultPage));
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            CoreApplication.Exit();
        }

        private void RenewButton_Click(object sender, RoutedEventArgs e)
        {
            IsSelect = false;
            (Application.Current as App).Award.renew();
            InputTextBox.Text = (Application.Current as App).Award.get_inputnum();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button btn = new Button();
                    btn.Width = 90;
                    btn.Height = 60;
                    btn.Background = new SolidColorBrush(Colors.LightBlue);
                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);
                    btn.Name = (i * 10 + j + 1).ToString();
                    btn.Content = (i * 10 + j + 1).ToString();
                    btn.FontFamily = new FontFamily("ms-appx:///Assets/Fonts/HarmonyOS_Sans_SC_Medium.ttf#HarmonyOS Sans SC");
                    btn.FontSize = 30;
                    btn.Click += Button_Click_1;
                    select.Children.Add(btn);
                }
            }
        }
    }
}
