using System;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void CloseBtn_OnClick(object sender, RoutedEventArgs e) => Close();

        private void MaximizeBtn_OnClick(object sender, RoutedEventArgs e) => WindowState = this.WindowState==WindowState.Normal ? WindowState.Maximized : WindowState.Normal;

        private void HideBtn_OnClick(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        private void Connect(string style)
        {
            var uri = new Uri(style, UriKind.Relative);
            var resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void GrayRB_Checked(object sender, RoutedEventArgs e) => Connect("Gray.xaml");
        private void DefaultRB_Checked(object sender, RoutedEventArgs e) => Connect("Default.xaml");
    }
}