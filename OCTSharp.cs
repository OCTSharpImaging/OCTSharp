using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCTSharp
{
    static class OCTSharpMainClass
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>   
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainDlg form = new MainDlg();
            if(!form.IsDisposed)
                Application.Run(form);
        }
    }
}
