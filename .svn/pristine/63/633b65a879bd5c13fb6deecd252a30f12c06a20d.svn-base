using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiamondLink
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        
        {
            if (System.IO.File.Exists(Application.StartupPath + "\\DiamondVersion.txt") == true)
            {
                string[] Str = System.IO.File.ReadAllLines(Application.StartupPath + "\\DiamondVersion.txt");
                if (Str.Length == 0)
                {
                    return;
                }
                if (Str[0].Length == 0)
                {
                    return;
                }

                System.Diagnostics.Process.Start(Application.StartupPath + "\\" + Str[0]);
                Application.Exit();
            }
        }
    }
}
