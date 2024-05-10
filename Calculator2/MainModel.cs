using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2
{
    public class MainModel
    {
        public static readonly NumberFormatInfo numberFormatInfo = NumberFormatInfo.InvariantInfo;
        public double? Operand1 { get; set; }
        public double? Operand2 { get; set; }
        public char? Operator { get; set; }
        public double? Calculate()
        {
            switch (Operator)
            {
                case '+': return Operand1 + Operand2;
                case '-': return Operand1 - Operand2;
                case '*': return Operand1 * Operand2;
                case '/': return (Operand2 == 0) ? null : Operand1 / Operand2;
                default: return null;
            }
        }
        public void Reset() => Operand1 = Operand2 = Operator = null;
    }
}
