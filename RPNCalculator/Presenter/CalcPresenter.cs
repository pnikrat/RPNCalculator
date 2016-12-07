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

        private bool CheckBinaryOperators()
        {
            if (_rpnStack.Count < 2)
            {
                DisplayOperatorsErrorMessage();
                return false;
            }
            return true;
        }

        private void DisplayOperatorsErrorMessage()
        {
            _calcView.SetTextStatusLabel("Not enough operands for this operation");
        }

        private void Addition(object sender, EventArgs args)
        {
            if (CheckBinaryOperators())
            {
                Number n1 = _rpnStack.Pop();
                Number n2 = _rpnStack.Pop();
                _rpnStack.Push(n1 + n2);
                StackDisplay();
            }
        }

        private void StackDisplay()
        {
            Number[] stackRepresentation = _rpnStack.ToArray();
            String[] stackDisplay = { "", "", "", "" };
            for (int i = 0; i < stackRepresentation.Length; i++)
            {
                stackDisplay[i] = stackRepresentation[i].ToString();
            }
            _calcView.SetStackValues(stackDisplay);
        }

    }
}
