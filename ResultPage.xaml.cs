using System;
using Windows.UI.Popups;
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
            //if ((Application.Current as App).C <= 50) (Application.Current as App).Award.ChangePrizeProbability(15, 20, 65);


            I1.Visibility = Visibility.Collapsed;
            I3.Visibility = Visibility.Collapsed;
            I2.Visibility = Visibility.Collapsed;
            int rt = (Application.Current as App).Award.JudgePrize();
            switch (rt)
            {
                case 0:
                    //未选择
                    MessageDialog messageDialog1 = new MessageDialog("请先选择您的幸运数字");
                    messageDialog1.ShowAsync();
                    break;
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
                    //所有奖项均已被抽完
                    MessageDialog messageDialog2 = new MessageDialog("所有奖项均已被抽完");
                    messageDialog2.ShowAsync();
                    break;
            }
        
            ResultTextBox3.Text = String.Empty;
            ResultTextBox3.Text += "剩余一等奖个数:" + (Application.Current as App).FirstPrizeCount.ToString();
            ResultTextBox3.Text += "\n剩余二等奖个数:" + (Application.Current as App).SecondPrizeCount.ToString();
            ResultTextBox3.Text += "\n剩余三等奖个数:" + (Application.Current as App).ThirdPrizeCount.ToString();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).Award.Renew((Application.Current as App).FirstPrizeCount, (Application.Current as App).SecondPrizeCount, (Application.Current as App).ThirdPrizeCount);
            Frame.Navigate(typeof(MainPage));
        }

        
    }
}
