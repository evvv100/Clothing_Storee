using Ninject;
using Logic;

namespace WinForms
{
    internal static class Program
    {
        /// <summary>
        /// DI контейнер
        /// </summary>
        public static IKernel Kernel { get; private set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Kernel = new StandardKernel(new SimpleConfigModule());
            var mainForm = Kernel.Get<MainForm>();
            Application.Run(mainForm);
        }
    }
}