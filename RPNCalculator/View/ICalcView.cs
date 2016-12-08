using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPNCalculator.Presenter;

namespace RPNCalculator.View
{
    public interface ICalcView
    {
        void SetTextCurrentNumber(String value);
        void SetTextStatusLabel(String value);
        void ClearStackValues();
        void SetStackValues(String[] values);
        //CalcPresenter _presenter
        //{ set; }

        event EventHandler<EventArgs<String>> StackPush;
        event EventHandler Addition;
        event EventHandler Subtraction;
        event EventHandler Multiplication;
        event EventHandler Division;
        event EventHandler Drop;
        event EventHandler Power;
        event EventHandler SquareRoot;
        event EventHandler Inversion;
        event EventHandler TimeAddition;
        event EventHandler TimeSubtraction;


    }
}
