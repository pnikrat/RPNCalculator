using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RPNCalculator.View;
using RPNCalculator.Presenter;
using System.Threading;

namespace RPNCalculator
{
    public partial class CalcView : Form, ICalcView
    {
        public event EventHandler<EventArgs<String>> NumberInsert;
        public event EventHandler<EventArgs<String>> StackPush;
        public event EventHandler Addition;
        public event EventHandler Subtraction;
        public event EventHandler Multiplication;
        public event EventHandler Division;
        public event EventHandler Drop;
        public event EventHandler Power;
        public event EventHandler SquareRoot;
        public event EventHandler Inversion;
        public event EventHandler TimeAddition;
        public event EventHandler TimeSubtraction;
        public event EventHandler DecimalMark;
        public event EventHandler PlusMinus;
        public event EventHandler Correction;
        public event EventHandler DateAddition;
        public event EventHandler DateSubtraction;

        public CalcView()
        {
            InitializeComponent();
            InitializeView();
        }

        private void InitializeView()
        {
            SetTextCurrentNumber("0");
            SetTextStatusLabel("");
            ClearStackValues();
        }

        public void DisplayCurrentNumber(String value)
        {
            CurrentNumber.Text += value;
        }

        public void SetTextCurrentNumber(String value)
        {
            CurrentNumber.Text = value;
        }

        public String GetTextCurrentNumber()
        {
            return CurrentNumber.Text;
        }

        public void SetTextStatusLabel(String value)
        {
            StatusLabel.Text = value;
        }

        public void ClearStackValues()
        {
            SetTextL1StackValue("");
            SetTextL2StackValue("");
            SetTextL3StackValue("");
            SetTextL4StackValue("");
        }

        public void SetStackValues(String[] values)
        {
            SetTextL1StackValue(values[0]);
            SetTextL2StackValue(values[1]);
            SetTextL3StackValue(values[2]);
            SetTextL4StackValue(values[3]);
        }

        private void SetTextL1StackValue(String value)
        {
            L1StackValue.Text = value;
        }

        private void SetTextL2StackValue(String value)
        {
            L2StackValue.Text = value;
        }

        private void SetTextL3StackValue(String value)
        {
            L3StackValue.Text = value;
        }

        private void SetTextL4StackValue(String value)
        {
            L4StackValue.Text = value;
        }

        /*
         * Metody wywołujące zdarzenia odnoszące się do poszczególnych akcji użytkownika na widoku
         */
        protected virtual void OnNumberInsert(EventArgs<String> args)
        {
            var eventHandler = this.NumberInsert;
            if (eventHandler != null)
                eventHandler.Invoke(this, args);
        }

        protected virtual void OnStackPush(EventArgs<String> args)
        {
            var eventHandler = this.StackPush;
            if (eventHandler != null)
                eventHandler.Invoke(this, args);
        }

        protected virtual void OnAddition()
        {
            var eventHandler = this.Addition;
            if (eventHandler != null)
                eventHandler.Invoke(this, null);
        }

        protected virtual void OnSubtraction()
        {
            var eventHandler = this.Subtraction;
            if (eventHandler != null)
                eventHandler.Invoke(this, null);
        }

        protected virtual void OnMultiplication()
        {
            var eventHandler = this.Multiplication;
            if (eventHandler != null)
                eventHandler.Invoke(this, null);
        }

        protected virtual void OnDivision()
        {
            var eventHandler = this.Division;
            if (eventHandler != null)
                eventHandler.Invoke(this, null);
        }

        protected virtual void OnDrop()
        {
            var eventHandler = this.Drop;
            if (eventHandler != null)
                eventHandler.Invoke(this, null);
        }
        
        protected virtual void OnPower()
        {
            var eventHandler = this.Power;
            if (eventHandler != null)
                eventHandler.Invoke(this, null);
        }

        protected virtual void OnSquareRoot()
        {
            var eventHandler = this.SquareRoot;
            if (eventHandler != null)
                eventHandler.Invoke(this, null);
        }

        protected virtual void OnInversion()
        {
            var eventHandler = this.Inversion;
            if (eventHandler != null)
                eventHandler.Invoke(this, null);
        }

        protected virtual void OnTimeAdd()
        {
            var eventHandler = this.TimeAddition;
            if (eventHandler != null)
                eventHandler.Invoke(this, null);
        }

        protected virtual void OnTimeSubtract()
        {
            var eventHandler = this.TimeSubtraction;
            if (eventHandler != null)
                eventHandler.Invoke(this, null);
        }

        protected virtual void OnDecimalMark()
        {
            var eventHandler = this.DecimalMark;
            if (eventHandler != null)
                eventHandler.Invoke(this, null);
        }

        protected virtual void OnPlusMinus()
        {
            var eventHandler = this.PlusMinus;
            if (eventHandler != null)
                eventHandler.Invoke(this, null);
        }

        protected virtual void OnCorrection()
        {
            var eventHandler = this.Correction;
            if (eventHandler != null)
                eventHandler.Invoke(this, null);
        }

        protected virtual void OnDateAdd()
        {
            var eventHandler = this.DateAddition;
            if (eventHandler != null)
                eventHandler.Invoke(this, null);
        }

        protected virtual void OnDateSubtract()
        {
            var eventHandler = this.DateSubtraction;
            if (eventHandler != null)
                eventHandler.Invoke(this, null);
        }

        /*
         * Metoda umożliwiająca wywołanie poszczególnych metod "wciskających przycisk" interfejsu 
         * w zależności od wciśniętego przez użytkownika klawisza na klawiaturze
         */
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.D1 || keyData == Keys.NumPad1)
            {
                OneButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.D2 || keyData == Keys.NumPad2)
            {
                TwoButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.D0 || keyData == Keys.NumPad0)
            {
                ZeroButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.D3 || keyData == Keys.NumPad3)
            {
                ThreeButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.D4 || keyData == Keys.NumPad4)
            {
                FourButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.D5 || keyData == Keys.NumPad5)
            {
                FiveButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.D6 || keyData == Keys.NumPad6)
            {
                SixButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.D7 || keyData == Keys.NumPad7)
            {
                SevenButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.D8 || keyData == Keys.NumPad8)
            {
                EightButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.D9 || keyData == Keys.NumPad9)
            {
                NineButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.OemPeriod || keyData == Keys.Decimal || keyData == Keys.Oemcomma)
            {
                DecimalMarkButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.Enter)
            {
                EnterButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.Add || keyData == (Keys.Shift | Keys.Oemplus))
            {
                AddButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.Subtract || keyData == Keys.OemMinus)
            {
                SubtractButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.Multiply || keyData == (Keys.Shift | Keys.D8))
            {
                MultiplyButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.Divide || keyData == Keys.OemQuestion)
            {
                DivideButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.D || keyData == Keys.Delete)
            {
                DropButton_Click(this, null);
                return true;
            }
            else if (keyData == (Keys.Shift | Keys.D6))
            {
                PowerButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.S)
            {
                SqrtButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.I)
            {
                InvButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.N)
            {
                PlusMinusButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.T)
            {
                TimeAddButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.Y)
            {
                TimeSubtractButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.Back)
            {
                OnCorrection();
                return true;
            }
            else if (keyData == Keys.G)
            {
                DayAddButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.H)
            {
                DaySubtractButton_Click(this, null);
                return true;
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /*
         * Metody WinForms wywoływane po wciśnięciu odpowiedniego elementu interfejsu
         * Każda z nich wywołuje osobną metodę odpowiedzialną za 'Invoke' zdarzenia przekazywanego później do prezentera
         */
        private void OneButton_Click(object sender, EventArgs e)
        {
            OnNumberInsert(new EventArgs<String>("1"));
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            OnStackPush(new EventArgs<String>(CurrentNumber.Text));
        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            OnNumberInsert(new EventArgs<String>("2"));
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            OnAddition();
        }

        private void ZeroButton_Click(object sender, EventArgs e)
        {
            OnNumberInsert(new EventArgs<String>("0"));
        }

        private void ThreeButton_Click(object sender, EventArgs e)
        {
            OnNumberInsert(new EventArgs<String>("3"));
        }

        private void FourButton_Click(object sender, EventArgs e)
        {
            OnNumberInsert(new EventArgs<String>("4"));
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {
            OnNumberInsert(new EventArgs<String>("5"));
        }

        private void SixButton_Click(object sender, EventArgs e)
        {
            OnNumberInsert(new EventArgs<String>("6"));
        }

        private void SevenButton_Click(object sender, EventArgs e)
        {
            OnNumberInsert(new EventArgs<String>("7"));
        }

        private void EightButton_Click(object sender, EventArgs e)
        {
            OnNumberInsert(new EventArgs<String>("8"));
        }

        private void NineButton_Click(object sender, EventArgs e)
        {
            OnNumberInsert(new EventArgs<String>("9"));
        }

        private void DecimalMarkButton_Click(object sender, EventArgs e)
        {
            OnDecimalMark();
        }

        private void SubtractButton_Click(object sender, EventArgs e)
        {
            OnSubtraction();
        }

        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            OnMultiplication();
        }

        private void DivideButton_Click(object sender, EventArgs e)
        {
            OnDivision();
        }

        private void DropButton_Click(object sender, EventArgs e)
        {
            OnDrop();
        }

        private void PowerButton_Click(object sender, EventArgs e)
        {
            OnPower();
        }

        private void SqrtButton_Click(object sender, EventArgs e)
        {
            OnSquareRoot();
        }

        private void InvButton_Click(object sender, EventArgs e)
        {
            OnInversion();
        }

        private void PlusMinusButton_Click(object sender, EventArgs e)
        {
            OnPlusMinus();
        }

        private void TimeAddButton_Click(object sender, EventArgs e)
        {
            OnTimeAdd();
        }

        private void TimeSubtractButton_Click(object sender, EventArgs e)
        {
            OnTimeSubtract();
        }

        private void DayAddButton_Click(object sender, EventArgs e)
        {
            OnDateAdd();
        }

        private void DaySubtractButton_Click(object sender, EventArgs e)
        {
            OnDateSubtract();
        }
    }
}
