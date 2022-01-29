using AZK.AutoAnalytics.DesktopClient.Model;
using AZK.AutoAnalytics.DesktopClient.ViewModel.Helpers.RelayCommand;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AZK.AutoAnalytics.DesktopClient.ViewModel.Windows.DetailSelector
{
    public sealed class DetailSelector_ViewModel : IDetailSelector_ViewModel, INotifyPropertyChanged
    {
        private IDetailSelectorModel _model;

        private string _selectedDetail;
        public string SelectedDetail
        {
            get => _selectedDetail;
            set
            {
                if(_selectedDetail != value)
                {
                    _selectedDetail = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _filter;
        public string Filter
        {
            private get => _filter;
            set
            {
                if (_filter != value)
                {
                    _filter = value;

                    UpdateFilteredDetails();
                }
            }
        }

        private ObservableCollection<string> _filteredDetails;
        public ObservableCollection<string> FilteredDetails
        {
            get => _filteredDetails;
            private set
            {
                if(_filteredDetails != value)
                {
                    _filteredDetails = value;
                    OnPropertyChanged();
                }
            }
        }

        public RelayCommand ConfirmDetailCommand { get; }

        public DetailSelector_ViewModel(IDetailSelectorModel model, Action onConfirm)
        {
            this._model = model;
            this.ConfirmDetailCommand = new RelayCommand(onConfirm);
        }

        private void UpdateFilteredDetails()
        {
            if ((Filter == null) || (Filter == ""))
            {
                FilteredDetails = new ObservableCollection<string>(_model.ReadDetailsContains());
            }
            else
            {
                IEnumerable<string> filteredDetails = new ObservableCollection<string>(_model.ReadDetailsContains(Filter));

                FilteredDetails = new ObservableCollection<string>(filteredDetails);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
