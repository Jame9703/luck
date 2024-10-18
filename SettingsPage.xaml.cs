using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace luck
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        public SettingsPage()
        {
            this.InitializeComponent();
            FirstPrizeCountNumberBox.Text = Luck.FirstPrizeCount.ToString();
            SecondPrizeCountNumberBox.Text = Luck.SecondPrizeCount.ToString();
            ThirdPrizeCountNumberBox.Text = Luck.ThirdPrizeCount.ToString();
            FirstPrizeProbabilityNumberBox.Text = Luck.FirstPrizeProbability.ToString();
            SecondPrizeProbabilityNumberBox.Text = Luck.SecondPrizeProbability.ToString();
            ThirdPrizeProbabilityNumberBox.Text = Luck.ThirdPrizeProbability.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(FirstPrizeCountNumberBox.Text, out int firstPrizeCount)
                && int.TryParse(SecondPrizeCountNumberBox.Text, out int secondPrizeCount)
                && int.TryParse(ThirdPrizeCountNumberBox.Text, out int thirdPrizeCount))
            {
                Luck.FirstPrizeCount = firstPrizeCount;
                Luck.SecondPrizeCount = secondPrizeCount;
                Luck.ThirdPrizeCount = thirdPrizeCount;
                localSettings.Values["FirstPrizeCount"] = firstPrizeCount;
                localSettings.Values["SecondPrizeCount"] = secondPrizeCount;
                localSettings.Values["ThirdPrizeCount"] = thirdPrizeCount;
            }
            if (int.TryParse(FirstPrizeProbabilityNumberBox.Text, out int firstPrizeProbability)
                && int.TryParse(SecondPrizeProbabilityNumberBox.Text, out int secondPrizeProbability)
                && int.TryParse(ThirdPrizeProbabilityNumberBox.Text, out int thirdPrizeProbability))
            {
                Luck.FirstPrizeProbability = firstPrizeProbability;
                Luck.SecondPrizeProbability = secondPrizeProbability;
                Luck.ThirdPrizeProbability = thirdPrizeProbability;
                localSettings.Values["FirstPrizeProbability"] = firstPrizeProbability;
                localSettings.Values["SecondPrizeProbability"] = secondPrizeProbability;
                localSettings.Values["ThirdPrizeProbability"] = thirdPrizeProbability;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), null, new DrillInNavigationTransitionInfo());
        }

        private void FirstPrizeProbabilityNumberBox_ValueChanged(Microsoft.UI.Xaml.Controls.NumberBox sender, Microsoft.UI.Xaml.Controls.NumberBoxValueChangedEventArgs args)
        {
            while(FirstPrizeProbabilityNumberBox.Value + SecondPrizeProbabilityNumberBox.Value > 100)
            {
                FirstPrizeProbabilityNumberBox.Value--;
            }
            ThirdPrizeProbabilityNumberBox.Value = 100 - FirstPrizeProbabilityNumberBox.Value - SecondPrizeProbabilityNumberBox.Value;
        }
        private void SecondPrizeProbabilityNumberBox_ValueChanged(Microsoft.UI.Xaml.Controls.NumberBox sender, Microsoft.UI.Xaml.Controls.NumberBoxValueChangedEventArgs args)
        {
            while (FirstPrizeProbabilityNumberBox.Value + SecondPrizeProbabilityNumberBox.Value > 100)
            {
                SecondPrizeProbabilityNumberBox.Value--;
            }
            ThirdPrizeProbabilityNumberBox.Value = 100 - FirstPrizeProbabilityNumberBox.Value - SecondPrizeProbabilityNumberBox.Value;
        }
    }
}
