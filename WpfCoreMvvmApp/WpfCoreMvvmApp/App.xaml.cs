using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfCoreMvvmApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DispatcherUnhandledException += (sender, args) =>
            {
                args.Handled = true;

                MessageBox.Show(args.Exception.ToString(), "Error");
            };

            base.OnStartup(e);

            Bootstrapper.Run();
        }
    }
}
