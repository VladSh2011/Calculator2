using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Calculator2
{
    public class ViewModel : BaseVM
    {
        #region PrivateFields
        private MainModel _model;
        private double _num;
        private string _operand = "0";
        private string _operation;
        private bool _hasError;
        private bool _IsCalculationDone;
        private bool _isCalculationRepeat;
        private RelayCommand _calculateCommand;
        private RelayCommand _inputCommand;
        private RelayCommand _clearCommand;
        private RelayCommand _clearAllCommand;
        private RelayCommand _pointInputCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _operationCommand;

        private NumberFormatInfo _numberFormatInfo;
        #endregion

        public string Operand { 
            get => _operand; 
            set
            {
                _operand = value;
                OnPropertyChanged(nameof(Operand));
            }
        }
        public string Operation
        {
            get => _operation;
            set
            {
                _operation = value;
                OnPropertyChanged(nameof(Operation));
            }
        }
        public bool HasError
        {
            get => _hasError;
            set
            {
                if (value == _hasError) return;
                _hasError = value;
                OnPropertyChanged(nameof(HasError));
            }
        }

        public ViewModel() 
        {
            _numberFormatInfo = NumberFormatInfo.InvariantInfo;
            _model = new MainModel();
            _operand = "0";
            _operation = String.Empty;
            _calculateCommand = new RelayCommand(Equals);
            _inputCommand = new RelayCommand(OperandInput);
            _clearCommand = new RelayCommand(Clear);
            _clearAllCommand = new RelayCommand(ClearAll);
            _pointInputCommand = new RelayCommand(PointInput);
            _deleteCommand = new RelayCommand(Delete);
            _operationCommand = new RelayCommand(OperationInput);
        }

        public ICommand CalculateCommand => _calculateCommand;
        public ICommand InputCommand => _inputCommand;
        public ICommand ClearCommand => _clearCommand;
        public ICommand ClearAllCommand => _clearAllCommand;
        public ICommand PointInputCommand => _pointInputCommand;
        public ICommand DeleteCommand => _deleteCommand;
        public ICommand OperationCommand => _operationCommand;


        public void OperandInput(object? o)
        {
            if (_IsCalculationDone || _hasError)
                ClearAll(o);

            if (Operand == "0") Operand = o.ToString();
            else Operand += o.ToString();
        }

        private void OperationInput(object? o)
        {
            if (_hasError)
                ClearAll(o);
            char operation = o.ToString()[0];
            _IsCalculationDone = false;
            if (!_isCalculationRepeat || Operand != null)
            {
                if (_isCalculationRepeat)
                {
                    Equals(o);
                    Operation = _model.Operand1.ToString()+operation;
                    _IsCalculationDone = false;
                }
                _model.Operand1 = double.Parse(Operand, _numberFormatInfo);
                Operand = null;
                _isCalculationRepeat = true;
            }
            Operation = _model.Operand1.ToString() + operation;
            _model.Operator = operation;

        }

        private void Clear(object o) => Operand = "0";

        private void ClearAll(object o)
        {
            Operation = null;
            _IsCalculationDone = HasError = _isCalculationRepeat = false;
            _model.Reset();
            Clear(o);
        }
        private void PointInput(object o)
        {
            if (_IsCalculationDone || _hasError)
                ClearAll(o);
            else if (Operand == null) Operand = "0";
            else if (Operand.Contains(MainModel.numberFormatInfo.NumberDecimalSeparator)) return;
            Operand += MainModel.numberFormatInfo.NumberDecimalSeparator;
        }

        private void Delete(object o)
        {
            if (_IsCalculationDone || _hasError)
                ClearAll(o);

            Operand = Operand.Length > 1 ? Operand.Remove(Operand.Length - 1) : "0";
        }


        public void Equals(object o)
        {
            if (Operation == null && !_IsCalculationDone)
                return;
            if (Operand != null)
            {
                double operandParsed = double.Parse(Operand, _numberFormatInfo);
                if (!_IsCalculationDone) _model.Operand2 = operandParsed;
                else _model.Operand1 = operandParsed;
            }
            else _model.Operand2 = null;
            double? result = _model.Calculate();
            if (result == null)
                HasError = true;
            else
                Operand = result?.ToString(MainModel.numberFormatInfo);
            Operation = null;
            _isCalculationRepeat = false;
            _IsCalculationDone = true;
        }
    }
}
