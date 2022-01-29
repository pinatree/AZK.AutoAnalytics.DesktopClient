using System.Collections.ObjectModel;

using AZK.AutoAnalytics.DesktopClient.Model.DataTypes;
using AZK.AutoAnalytics.DesktopClient.ViewModel.Helpers.RelayCommand;

namespace AZK.AutoAnalytics.DesktopClient.ViewModel.Windows.MainWindow
{
    public interface IMainWindow_ViewModel
    {
        ObservableCollection<DetailPath> FoundDamagedDetails { get; }

        ObservableCollection<Recommendation> Recommendations { get; }

        RelayCommand SelectDetailCommand { get; }
    }
}
