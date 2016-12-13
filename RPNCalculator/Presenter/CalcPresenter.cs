using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPNCalculator.Model;
using RPNCalculator.View;
using System.Threading;

namespace RPNCalculator.Presenter
{
    public class CalcPresenter
    {
        private Stack<Number> _rpnStack = new Stack<Number>();
        private readonly ICalcView _calcView;
        private String decimalSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        public CalcPresenter(ICalcView calcView)
        {
            _calcView = calcView;
            SubscribeToViewEvents();
        }

        private void SubscribeToViewEvents()
        {
            _calcView.StackPush += this.StackPush;
            _calcView.Addition += this.Addition;
            _calcView.Subtraction += this.Subtraction;
            _calcView.Multiplication += this.Multiplication;
            _calcView.Division += this.Division;
            _calcView.Drop += this.Drop;
            _calcView.Power += this.Power;
            _calcView.SquareRoot += this.SquareRoot;
            _calcView.Inversion += this.Inversion;
            _calcView.TimeAddition += this.TimeAddition;
            _calcView.TimeSubtraction += this.TimeSubtraction;
            _calcView.DecimalMark += this.DecimalMark;
            _calcView.PlusMinus += this.PlusMinus;
            _calcView.Correction += this.Correction;
        }

        private void StackPush(object sender, EventArgs<String> args)
        {
            if (args.value.Length > 0)
            {
                _calcView.SetTextStatusLabel("");
                _rpnStack.Push(new Number(args.value));
                _calcView.SetTextCurrentNumber("");
                StackDisplay();
            }
        }

        private bool CheckUnaryOperators()
        {
            if (_rpnStack.Count < 1)
            {
                DisplayOperatorsErrorMessage();
                return false;
            }
            return true;
        }

        private bool CheckBinaryOperators()
        {
            if (_rpnStack.Count < 2)
            {
                DisplayOperatorsErrorMessage();
                return false;
            }
            return true;
        }

        private bool CheckZeroDivision()
        {
            if (_rpnStack.Peek().getDoubleValue() == 0.0)
            {
                DisplayZeroDivisionErrorMessage();
                return false;
            }
            return true;
        }

        private bool IsPositive()
        {
            if (_rpnStack.Peek().getDoubleValue() < 0.0)
            {
                DisplayNegativeRootErrorMessage();
                return false;
            }
            return true;
        }

        private bool CheckTimeValues()
        {
            if (_rpnStack.Peek().getDoubleValue() < 0.0 || _rpnStack.ElementAt<Number>(1).getDoubleValue() < 0.0)
            {
                DisplayNegativeTimeValuesMessage();
                return false;
            }
            return true;
        }

        private void DisplayOperatorsErrorMessage()
        {
            _calcView.SetTextStatusLabel("Not enough operands for this operation");
        }

        private void DisplayZeroDivisionErrorMessage()
        {
            _calcView.SetTextStatusLabel("Division by zero forbidden");
        }

        private void DisplayNegativeRootErrorMessage()
        {
            _calcView.SetTextStatusLabel("Square root of negative number forbidden");
        }

        private void DisplayNegativeTimeValuesMessage()
        {
            _calcView.SetTextStatusLabel("Time cannot be negative");
        }

        private void Addition(object sender, EventArgs args)
        {
            if (CheckBinaryOperators())
            {
                Number n1 = _rpnStack.Pop();
                Number n2 = _rpnStack.Pop();
                _rpnStack.Push(n2 + n1);
                StackDisplay();
            }
        }

        private void Subtraction(object sender, EventArgs args)
        {
            if (CheckBinaryOperators())
            {
                Number n1 = _rpnStack.Pop();
                Number n2 = _rpnStack.Pop();
                _rpnStack.Push(n2 - n1);
                StackDisplay();
            }
        }

        private void Multiplication(object sender, EventArgs args)
        {
            if (CheckBinaryOperators())
            {
                Number n1 = _rpnStack.Pop();
                Number n2 = _rpnStack.Pop();
                _rpnStack.Push(n2 * n1);
                StackDisplay();
            }
        }

        private void Division(object sender, EventArgs args)
        {
            if (CheckBinaryOperators() && CheckZeroDivision())
            {
                Number n1 = _rpnStack.Pop();
                Number n2 = _rpnStack.Pop();
                _rpnStack.Push(n2 / n1);
                StackDisplay();
            }
        }

        private void Drop(object sender, EventArgs args)
        {
            if (CheckUnaryOperators())
            {
                _calcView.SetTextStatusLabel("");
                _rpnStack.Pop();
                StackDisplay();
            }
        }

        private void Power(object sender, EventArgs args)
        {
            if (CheckBinaryOperators())
            {
                Number n1 = _rpnStack.Pop();
                Number n2 = _rpnStack.Pop();
                _rpnStack.Push(n2 ^ n1);
                StackDisplay();
            }
        }

        private void SquareRoot(object sender, EventArgs args)
        {
            if (CheckUnaryOperators() && IsPositive())
            {
                Number n1 = _rpnStack.Pop();
                _rpnStack.Push(++n1);
                StackDisplay();
            }
        }

        private void Inversion(object sender, EventArgs args)
        {
            if (CheckUnaryOperators() && CheckZeroDivision())
            {
                Number n1 = _rpnStack.Pop();
                _rpnStack.Push(~n1);
                StackDisplay();
            }
        }

        private void TimeAddition(object sender, EventArgs args)
        {
            if (CheckBinaryOperators() && CheckTimeValues())
            {
                Number n1 = _rpnStack.Pop();
                Number n2 = _rpnStack.Pop();
                _rpnStack.Push(n2.TimeAddition(n1));
                StackDisplay();
            }
        }

        private void TimeSubtraction(object sender, EventArgs args)
        {
            if (CheckBinaryOperators() && CheckTimeValues())
            {
                Number n1 = _rpnStack.Pop();
                Number n2 = _rpnStack.Pop();
                _rpnStack.Push(n2.TimeSubtraction(n1));
                StackDisplay();
            }
        }

        private void DecimalMark(object sender, EventArgs args)
        {
            if (!_calcView.GetTextCurrentNumber().Contains(decimalSeparator) && _calcView.GetTextCurrentNumber().Length > 0)
                _calcView.DisplayCurrentNumber(decimalSeparator);
        }

        private void PlusMinus(object sender, EventArgs args)
        {
            if (_calcView.GetTextCurrentNumber().Length != 0)
            {
                if (_calcView.GetTextCurrentNumber()[0] != '-')
                {
                    _calcView.SetTextCurrentNumber("-" + _calcView.GetTextCurrentNumber());
                }
                else if (_calcView.GetTextCurrentNumber()[0] == '-')
                {
                    _calcView.SetTextCurrentNumber(_calcView.GetTextCurrentNumber().TrimStart('-'));
                }
            }
        }

        private void Correction(object sender, EventArgs args)
        {
            if (_calcView.GetTextCurrentNumber().Length != 0)
            {
                _calcView.SetTextCurrentNumber(_calcView.GetTextCurrentNumber().Remove(_calcView.GetTextCurrentNumber().Length - 1));
            }
        }

        private void StackDisplay()
        {
            Number[] stackRepresentation = _rpnStack.ToArray();
            String[] stackDisplay = { "", "", "", "" };
            for (int i = 0; i < stackRepresentation.Length; i++)
            {
                if (i >= 4)
                    break;
                stackDisplay[i] = stackRepresentation[i].ToString();
            }
            _calcView.SetStackValues(stackDisplay);
        }

    }
}
