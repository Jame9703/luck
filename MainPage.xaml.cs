using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace luck
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int FirstPrizeCount = (Application.Current as App).FirstPrizeCount,
            SecondPrizeCount = (Application.Current as App).SecondPrizeCount,
            ThirdPrizeCount = (Application.Current as App).ThirdPrizeCount;
        public MainPage()
        {
            this.InitializeComponent();


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
            // 隐藏标题栏
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
                int.TryParse(thisClickedButton.Name, out int name_to_int);
                (Application.Current as App).Award.store_inputnum(name_to_int);
                InputTextBox.Text = (Application.Current as App).Award.get_inputnum().ToString();
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
            (Application.Current as App).Award.renew(FirstPrizeCount, SecondPrizeCount, ThirdPrizeCount);
            InputTextBox.Text = (Application.Current as App).Award.get_inputnum().ToString();
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
