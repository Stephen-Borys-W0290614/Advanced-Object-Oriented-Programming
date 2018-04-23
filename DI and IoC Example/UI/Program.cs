using System;
using System.Windows.Forms;
using TaskExecutors;
using Logger;
using Unity;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //configure our IoC container
            UnityContainer container = new UnityContainer();

            container.RegisterType<IDrink, BeerDrinker>();
            container.RegisterType<IComplicated, HeartSurgeon>();
            container.RegisterType<INoisy, RockBand>();
            container.RegisterType<ICharitable, DoGooder>();
            container.RegisterType<ILoggable, ConsoleLogger>();

            //Application.Run(new UIForm());
            Application.Run(container.Resolve<UIForm>());
        }
    }
}