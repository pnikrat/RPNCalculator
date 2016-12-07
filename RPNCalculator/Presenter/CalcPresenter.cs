using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPNCalculator.Model;
using RPNCalculator.View;

namespace RPNCalculator.Presenter
{
    public class CalcPresenter
    {
        private Stack<Number> _rpnStack = new Stack<Number>();
        private readonly ICalcView _calcView;


        public CalcPresenter(ICalcView calcView)
        {
            _calcView = calcView;
            _calcView.StackPush += this.StackPush;
            _calcView.Addition += this.Addition;
            _calcView.Subtraction += this.Subtraction;
            _calcView.Multiplication += this.Multiplication;
            _calcView.Division += this.Division;
            _calcView.Drop += this.Drop;
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

        private void DisplayOperatorsErrorMessage()
        {
            _calcView.SetTextStatusLabel("Not enough operands for this operation");
        }

        private void DisplayZeroDivisionErrorMessage()
        {
            _calcView.SetTextStatusLabel("Division by zero forbidden");
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
