using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Navigation.Models;
using Navigation.Pages;

namespace Navigation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool IsMenuExpanded = true; // 导航栏初始状态为展开
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new HomePage());
        }

        private void PLC_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new PLCPage());
        }

        private void Database_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new DatabasePage());
        }

        private void Embedded_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new EmbeddedPage());
        }

        private void OS_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new OSPage());
        }

        private void RealTime_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new RealTimePage());
        }

        private void DataBoard_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new DataBoardPage());
        }

        private void SystemLog_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new SystemLogPage());
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Themes_Click(object sender, RoutedEventArgs e)
        {
            if (Themes.IsChecked == true)
                ThemesController.SetTheme(ThemesController.ThemeTypes.Dark);
            else
                ThemesController.SetTheme(ThemesController.ThemeTypes.Light);
        }


        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            var widthAnimation = new DoubleAnimation
            {
                From = menuBoard.Width,
                To = IsMenuExpanded ? 0 : 250,
                Duration = TimeSpan.FromMilliseconds(1000), // 增加动画持续时间
                EasingFunction = new SineEase { EasingMode = EasingMode.EaseOut } // 使用 SineEase 使动画更平滑
            };

            Storyboard.SetTarget(widthAnimation, menuBoard);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(FrameworkElement.WidthProperty));

            var storyboard = new Storyboard();
            storyboard.Children.Add(widthAnimation);
            storyboard.Begin();

            IsMenuExpanded = !IsMenuExpanded; // 切换状态
        }

    }
}