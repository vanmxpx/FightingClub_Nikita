using GameProcess;
using System;
using System.Windows.Forms;

namespace FightingClub_Nikita
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm form = new MainForm();
            LogManager log = new LogManager();

            Presenter presenter = new Presenter(form, log);

            Application.Run(form);
        }
    }
}
