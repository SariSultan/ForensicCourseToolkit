using System;
using System.Drawing;
using System.Windows.Forms;

namespace ForensicsCourseToolkit
{
    public static class Program
    {
        public static bool[] LoggingFlags =
        {
            true,
            true,
            true,
            true,
            true
        };

        public static Color[] Messages_Colors =
        {
            Color.Green,
            Color.Magenta,
            Color.Red,
            Color.Orange,
            Color.DarkRed
        };

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainFrm());
        }
    }
}