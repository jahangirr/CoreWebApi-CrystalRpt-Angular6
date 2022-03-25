using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrystalFullFramework
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] argsPre = Environment.GetCommandLineArgs();
            string[] args = new string[3];
            if(argsPre.Length == 1)
            {
                args[0] = argsPre[0];
                args[1] = "Milton";
                args[2] = "Jahangir";

            }
            else
            {
                args = argsPre;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(args));
        }
    }
}
