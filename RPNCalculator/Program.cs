using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RPNCalculator.Presenter;

namespace RPNCalculator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CalcView view = new CalcView();
            CalcPresenter presenter = new CalcPresenter(view);

            Application.Run(view);
        }
    }
}
