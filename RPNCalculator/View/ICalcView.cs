﻿using System;
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
        void ClearStackValues();
        void SetTextL1StackValue(String value);
        void SetTextL2StackValue(String value);
        void SetTextL3StackValue(String value);
        void SetTextL4StackValue(String value);
        //CalcPresenter _presenter
        //{ set; }

        event EventHandler<EventArgs<String>> StackPush;
        event EventHandler Addition;
    }
}