using System.Collections.Generic;
using System.Windows;
using AZK.AutoAnalytics.DesktopClient.ExcelReader;
using AZK.AutoAnalytics.DesktopClient.ExcelReader.DataTypes;
using AZK.AutoAnalytics.DesktopClient.Model;
using AZK.AutoAnalytics.DesktopClient.ViewModel.Windows.DetailSelector;

namespace AZK.AutoAnalytics.DesktopClient.View.Windows
{
    public partial class DetailSelector : Window
    {
        private DetailSelector_ViewModel _dataContext;
        public string SelectedDetail
        {
            get => _dataContext.SelectedDetail;
        }

        public DetailSelector()
        {
            InitializeComponent();

            _dataContext = new DetailSelector_ViewModel(new DetailSelectorModel(), Close);

            this.DataContext = _dataContext;
        }
    }
}
