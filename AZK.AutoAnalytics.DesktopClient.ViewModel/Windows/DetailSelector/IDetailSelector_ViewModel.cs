using System.Collections.ObjectModel;

using AZK.AutoAnalytics.DesktopClient.ViewModel.Helpers.RelayCommand;


namespace AZK.AutoAnalytics.DesktopClient.ViewModel.Windows.DetailSelector
{
    public interface IDetailSelector_ViewModel
    {
        string SelectedDetail { get; set; }

        string Filter { set; }

        ObservableCollection<string> FilteredDetails { get; }

        RelayCommand ConfirmDetailCommand { get; }
    }
}
