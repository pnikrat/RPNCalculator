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
            _rpnStack.Push(new Number(args.value));
            StackDisplay();
        }

        private void Addition(object sender, EventArgs args)
        {
            Number n1 = _rpnStack.Pop();
            Number n2 = _rpnStack.Pop();
            _rpnStack.Push(n1 + n2);
            StackDisplay();
        }

        private void StackDisplay()
        {
            Number[] stackRepresentation = _rpnStack.ToArray();
            //stackRepresentation.Reverse<Number>();
            _calcView.ClearStackValues();
            if (stackRepresentation.Length >= 1)
                _calcView.SetTextL1StackValue(stackRepresentation[0].ToString());
            if (stackRepresentation.Length >= 2)
                _calcView.SetTextL2StackValue(stackRepresentation[1].ToString());
            if (stackRepresentation.Length >= 3)
                _calcView.SetTextL3StackValue(stackRepresentation[2].ToString());
            if (stackRepresentation.Length >= 4)
                _calcView.SetTextL4StackValue(stackRepresentation[3].ToString());
        }

    }
}
