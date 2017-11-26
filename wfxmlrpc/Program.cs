using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfxmlrpc
{
    static class Program
    {

        static public Form1 myform;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>

        [STAThread]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
             myform = new Form1();
            Application.Run(myform);
        }
    }
}
