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

namespace Calculator
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (LowerTextBlock.Text == "0" || LowerTextBlock.Text == "Zero error division")
            {
                LowerTextBlock.Text = btn.Content.ToString();
            }
            else
            {
                LowerTextBlock.Text += btn.Content.ToString();
            }
        }

        private void Button_C_Click(object sender, RoutedEventArgs e)
        {
            UpperTextBlock.Text = String.Empty;
            LowerTextBlock.Text = "0";
        }

        private void Dell_Click(object sender, RoutedEventArgs e)
        {
            if(LowerTextBlock.Text.Length == 1)
            {
                LowerTextBlock.Text = "0";
            }
            else
            {
                LowerTextBlock.Text = LowerTextBlock.Text.Remove(LowerTextBlock.Text.Length-1);
            }
        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            LowerTextBlock.Text = "0";
        }

        private void Point_Click(object sender, RoutedEventArgs e)
        {
            if(LowerTextBlock.Text.Contains("."))
            {
                return;
            }
            LowerTextBlock.Text += ".";
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (UpperTextBlock.Text.Length == 0)
            {
                UpperTextBlock.Text = LowerTextBlock.Text + btn.Content.ToString();
                LowerTextBlock.Text = "0";
            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(LowerTextBlock.Text, out double y);
            double.TryParse(UpperTextBlock.Text.Remove(UpperTextBlock.Text.Length - 1), out double x);
            char operation = UpperTextBlock.Text[UpperTextBlock.Text.Length - 1];
            string result;
            switch (operation)
            {
                case '+':
                    result = (x + y).ToString(); break;
                case '-':
                    result = (x - y).ToString(); break;
                case '*':
                    result = (x * y).ToString(); break;
                case '/':
                    result = y != 0 ? (x / y).ToString() : "Zero error division";
                    break;
                default:
                    result = "Incorrect operation";
                    break;
            }
            UpperTextBlock.Text = string.Empty;
            LowerTextBlock.Text = result;
        }
    }
}