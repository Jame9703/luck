﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace luck
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ResultPage : Page
    {
        public ResultPage()
        {
            this.InitializeComponent();
            MainPage mainPage = new MainPage();
            //if ((Application.Current as App).C <= 50) (Application.Current as App).Award.setup(15, 20, 65);
            //(Application.Current as App).Award.setup(5, 15, 80);

            
            I1.Visibility = Visibility.Collapsed;
            I3.Visibility = Visibility.Collapsed;
            I2.Visibility = Visibility.Collapsed;
            int rt = (Application.Current as App).Award.judge_one();
            switch (rt)
            {
                case 1:
                    //一等奖
                    (Application.Current as App).FirstPrizeCount--;
                    I1.Visibility = Visibility.Visible;
                    break;
                case 2:
                    //二等奖
                    (Application.Current as App).SecondPrizeCount--;
                    I2.Visibility = Visibility.Visible;
                    break;
                case 3:
                    //三等奖
                    (Application.Current as App).ThirdPrizeCount--;
                    I3.Visibility = Visibility.Visible;
                    break;
                default:
                    //没中奖，默认三等奖
                    (Application.Current as App).ThirdPrizeCount--;
                    I3.Visibility = Visibility.Visible;
                    break;
            }
        
            ResultTextBox3.Text = String.Empty;
            ResultTextBox3.Text += "剩余一等奖个数:" + (Application.Current as App).FirstPrizeCount.ToString();
            ResultTextBox3.Text += "\n剩余二等奖个数:" + (Application.Current as App).SecondPrizeCount.ToString();
            ResultTextBox3.Text += "\n剩余三等奖个数:" + (Application.Current as App).ThirdPrizeCount.ToString();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).Award.renew((Application.Current as App).FirstPrizeCount, (Application.Current as App).SecondPrizeCount, (Application.Current as App).ThirdPrizeCount);
            Frame.Navigate(typeof(MainPage));
        }

        
    }
}
