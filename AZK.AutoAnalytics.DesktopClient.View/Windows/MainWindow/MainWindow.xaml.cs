using System;
using System.Windows;
using Autofac;
using AZK.AutoAnalytics.DesktopClient.DI;
using AZK.AutoAnalytics.DesktopClient.Model;
using AZK.AutoAnalytics.DesktopClient.View.Windows;
using AZK.AutoAnalytics.DesktopClient.ViewModel.Windows.MainWindow;

namespace AZK.AutoAnalytics.DesktopClient.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Func<string> getDetailFunc = () =>
            {
                var detailSelector = new DetailSelector();
                detailSelector.ShowDialog();
                return detailSelector.SelectedDetail;
            };

            var builder = new ContainerBuilder();

            // Register individual components
            builder.RegisterInstance(new MainWindow_ViewModel(new MainWindowModel(), getDetailFunc))
                   .As<IMainWindow_ViewModel>();

            DIManager.AppDIContainer = builder.Build();

            this.DataContext = DIManager.AppDIContainer.Resolve<IMainWindow_ViewModel>();
        }
    }
}
