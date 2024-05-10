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
        //public MainWindow()
        //{
        //    InitializeComponent();
        //    //_numberFormatInfo = NumberFormatInfo.InvariantInfo;
        //}

//        private bool _IsCalculationDone;
//        private bool _hasError;
//        NumberFormatInfo _numberFormatInfo;

//        private void OperandInput(object sender, RoutedEventArgs e)
//        {
//            if (_IsCalculationDone || _hasError)
//                ClearAll(sender, e);

//            Button btn = (Button)sender;
//            if (Operand.Text == "0") Operand.Text = btn.Content.ToString();
//            else Operand.Text += btn.Content.ToString();
//        }

//        private void ClearAll(object sender, RoutedEventArgs e)
//        {
//            UpperTextBlock.Text = string.Empty;
//            _IsCalculationDone = _hasError = false;
//            Clear(sender, e);
//        }

//        private void DeleteChar(object sender, RoutedEventArgs e)
//        {
//            if (_IsCalculationDone || _hasError)
//                ClearAll(sender, e);

//            Operand.Text = Operand.Text.Length > 1 ? Operand.Text.Remove(Operand.Text.Length - 1) : "0";
//        }

//        private void Clear(object sender, RoutedEventArgs e) => Operand.Text = "0";

//        private void PointInput(object sender, RoutedEventArgs e)
//        {
//            if (_IsCalculationDone || _hasError)
//                ClearAll(sender, e);

//            if (Operand.Text.Contains(_numberFormatInfo.NumberDecimalSeparator)) return;
//            Operand.Text += _numberFormatInfo.NumberDecimalSeparator;
//        }

//        private void Operation_Click(object sender, RoutedEventArgs e)
//        {
//            Button btn = (Button)sender;
//            if (UpperTextBlock.Text.Length == 0)
//            {
//                UpperTextBlock.Text = Operand.Text + btn.Content;
//                Operand.Text = "0";           
//            }
//        }

//        private void Equals_Click(object sender, RoutedEventArgs e)
//        {
//            double y = double.Parse(Operand.Text, _numberFormatInfo);
//            double x = double.Parse(UpperTextBlock.Text.Remove(UpperTextBlock.Text.Length - 1), _numberFormatInfo);
//            char operation = UpperTextBlock.Text[UpperTextBlock.Text.Length - 1];
//            string result;
//            switch (operation)
//            {
//                case '+':
//                    result = (x + y).ToString(_numberFormatInfo); break;
//                case '-':
//                    result = (x - y).ToString(_numberFormatInfo); break;
//                case '*':
//                    result = (x * y).ToString(_numberFormatInfo); break;
//                case '/':
//                    result = y != 0 ? (x / y).ToString(_numberFormatInfo) : "Zero error division";
//                    if(result == "Zero error division")
//                        _hasError = true;
//                    break;
//                default:
//                    result = "Incorrect operation";
//                    break;
//            }
//            UpperTextBlock.Text = string.Empty;
//            Operand.Text = result;


//            _IsCalculationDone = true;
//        }
    }
}