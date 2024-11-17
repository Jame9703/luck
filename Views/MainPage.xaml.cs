using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace luck
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<int> buttonsList;
        private List<Button> buttons = new List<Button>();
        public MainPage()
        {
            this.InitializeComponent();
            buttonsList = new ObservableCollection<int>();
            for (int i = 1; i <= 100; i++)
            {
                buttonsList.Add(i);
            }
            SelectNumberGridView.ItemsSource = buttonsList;
            this.DataContext = this;

            //for (int i = 0; i < 10; i++)
            //{
            //    for (int j = 0; j < 10; j++)
            //    {
            //        Button btn = new Button();
            //        btn.Width = 90;
            //        btn.Height = 60;  
            //        btn.Background = new SolidColorBrush(Colors.LightBlue); 
            //        Grid.SetRow(btn, i);
            //        Grid.SetColumn(btn, j);
            //        btn.Name = (i * 10 + j + 1).ToString();
            //        btn.Content = (i * 10 + j + 1).ToString();
            //        btn.FontFamily = new FontFamily("ms-appx:///Assets/Fonts/HarmonyOS_Sans_SC_Medium.ttf#HarmonyOS Sans SC");
            //        btn.FontSize = 30;
            //        btn.Click += Button_Click_1;
            //        //select.Children.Add(btn);
            //    }
            //}
            // 隐藏标题栏
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            ApplicationViewTitleBar formattableTitleBar = ApplicationView.GetForCurrentView().TitleBar;
            formattableTitleBar.ButtonBackgroundColor = Colors.Transparent;
        }
        bool IsSelect = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            int number = (int)btn.Content;
            //int number = SelectNumberGridView.SelectedIndex + 1;
            Luck.SelectedNumber = number;
            InputTextBox.Text = number.ToString();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!IsSelect)
            {
                IsSelect = true;
                Button thisClickedButton = sender as Button;
                int.TryParse(thisClickedButton.Name, out int selectedNumber);
                Luck.SelectedNumber = selectedNumber;
                InputTextBox.Text = selectedNumber.ToString();
                thisClickedButton.Background = new SolidColorBrush(Colors.Green);

            }
            else
            {
                //foreach (var btn in select.Children.OfType<Button>().ToList())
                //{
                //    btn.Background = new SolidColorBrush(Colors.LightBlue);
                //}
                IsSelect = true;
                Button thisClickedButton = sender as Button;
                int.TryParse(thisClickedButton.Name, out int selectedNumber);
                Luck.SelectedNumber = selectedNumber;
                InputTextBox.Text = selectedNumber.ToString();
                thisClickedButton.Background = new SolidColorBrush(Colors.Green);
            }
        }


        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            
            Frame.Navigate(typeof(ResultPage), null, new DrillInNavigationTransitionInfo());
        }

        private void FullScreenModeButton_Click(object sender, RoutedEventArgs e)
        {
            ApplicationView view = ApplicationView.GetForCurrentView();
            if(view.IsFullScreenMode)
            {
                view.ExitFullScreenMode();
                FullScreenModeTextBlock.Text = "进入全屏";
                FullScreenModeSymbolIcon.Symbol = Symbol.SlideShow;
            }
            else
            {
                view.TryEnterFullScreenMode();
                FullScreenModeTextBlock.Text = "退出全屏";
                FullScreenModeSymbolIcon.Symbol = Symbol.NewWindow;
            }
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SettingsPage), null, new DrillInNavigationTransitionInfo());
        }
    }
}
