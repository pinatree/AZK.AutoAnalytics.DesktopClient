using System;
using System.Windows;
using Autofac;
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

            this.DataContext = new MainWindow_ViewModel(new MainWindowModel(), getDetailFunc, Close);
        }
    }
}
