using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace luck
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ResultPage : Page
    {


        Luck luck1 = new Luck();



        public ResultPage()
        {
            this.InitializeComponent();
            MainPage mainPage = new MainPage();
            if((Application.Current as App).C <= 50) (Application.Current as App).Award.setup(15, 20, 65);
            (Application.Current as App).Award.setup(5, 15, 80);
            int rt = (Application.Current as App).Award.judge_one();
            
            I1.Visibility = Visibility.Collapsed;
            I3.Visibility = Visibility.Collapsed;
            I2.Visibility = Visibility.Collapsed;
            switch (rt)
            {
                case 1:
                    //一等奖
                    (Application.Current as App).A--;
                    I1.Visibility = Visibility.Visible;
                    break;
                case 2:
                    //二等奖
                    (Application.Current as App).B--;
                    I2.Visibility = Visibility.Visible;
                    break;
                case 3:
                    //三等奖
                    (Application.Current as App).C--;
                    I3.Visibility = Visibility.Visible;
                    break;

                default:
                    throw new Exception("ERROR_AWARD_NOT_EQUEL");
            }
        
        ResultTextBox3.Text = String.Empty;
            ResultTextBox3.Text += "剩余一等奖个数:" + (Application.Current as App).A.ToString();
            ResultTextBox3.Text += "\n剩余二等奖个数:" + (Application.Current as App).B.ToString();
            ResultTextBox3.Text += "\n剩余三等奖个数:" + (Application.Current as App).C.ToString();

            //ResultTextBox2.Text = String.Empty;
            //ResultTextBox2.Text += "一等奖:" + (Application.Current as App).Award.get_first_str();
            //ResultTextBox2.Text += "\n一等奖:" + (Application.Current as App).Award.get_first_win();
            //ResultTextBox2.Text += "\n二等奖:" + (Application.Current as App).Award.get_second_str();
            //ResultTextBox2.Text += "\n二等奖:" + (Application.Current as App).Award.get_second_win();
            //ResultTextBox2.Text += "\n三等奖:" + (Application.Current as App).Award.get_third_str();
            //ResultTextBox2.Text += "\n三等奖:" + (Application.Current as App).Award.get_third_win();



        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).Award.renew();
            Frame.Navigate(typeof(MainPage));
        }

        
    }
}
