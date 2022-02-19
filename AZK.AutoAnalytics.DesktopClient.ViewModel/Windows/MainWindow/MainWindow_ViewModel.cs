using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

using AZK.AutoAnalytics.DesktopClient.ViewModel.Helpers.RelayCommand;
using AZK.AutoAnalytics.DesktopClient.Model.DataTypes;
using AZK.AutoAnalytics.DesktopClient.Model;
using AZK.AutoAnalytics.DesktopClient.ExcelReader.DataTypes;

namespace AZK.AutoAnalytics.DesktopClient.ViewModel.Windows.MainWindow
{
    public sealed class MainWindow_ViewModel : IMainWindow_ViewModel, INotifyPropertyChanged
    {
        private IMainWindowModel _model;

        //UI output
        private ObservableCollection<DetailPath> _foundDamagedDetails = new ObservableCollection<DetailPath>();
        public ObservableCollection<DetailPath> FoundDamagedDetails
        {
            get => _foundDamagedDetails;
            private set
            {
                _foundDamagedDetails = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Recommendation> _recommendations = new ObservableCollection<Recommendation>();
        public ObservableCollection<Recommendation> Recommendations
        {
            get => _recommendations;
            private set
            {
                _recommendations = value;
                OnPropertyChanged();
            }
        }

        //Commands
        public RelayCommand SelectDetailCommand { get; }
        public RelayCommand CloseWindowCommand { get; }

        private Action _closeCallback;

        public MainWindow_ViewModel(IMainWindowModel model, Func<string> selectDetailCallback, Action closeCallback)
        {
            this._closeCallback = closeCallback;

            this._model = model;

            SelectDetailCommand = new RelayCommand(() =>
            {
                var newDetail = selectDetailCallback.Invoke();

                if ((newDetail != null) && (newDetail != string.Empty))
                {
                    AddDetail(newDetail);
                }
            });

            CloseWindowCommand = new RelayCommand(() => _closeCallback.Invoke());
        }

        private void AddDetail(string newDetail)
        {
            //костыль
            Action<DetailPath> onRemoveFromList = new Action<DetailPath>((detPath) =>
            {
                FoundDamagedDetails.Remove(detPath);

                UpdateRecommendations();

                return;
            });

            DetailPath newPath = new DetailPath("-", "-", newDetail, onRemoveFromList);

            bool detailAlreadyFound = FoundDamagedDetails.Any(detPath => detPath.Equals(newPath));

            if(detailAlreadyFound == false)
            {
                FoundDamagedDetails.Add(newPath);

                UpdateRecommendations();
            }
        }

        private void UpdateRecommendations()
        {
            List<AssocRule> foundAssocRules = new List<AssocRule>();

            //Получаем рекоммендации к каждой детали
            foreach (var damadgedDetail in FoundDamagedDetails)
            {
                IEnumerable<AssocRule> rulesForDetail = _model.GetRecommendationsForDetail(damadgedDetail.Detail);

                foundAssocRules = foundAssocRules.Concat(rulesForDetail).ToList();
            }

            //Получаем правило с максимальной надежностью для каждой детали
            //Было бы неплохо это как-то обрабатывать... тип, вероятность "невыпадения" из раза в раз все меньше
            //Но пока обойдусь без хитрой логики
            List<AssocRule> foundAssocRulesliability =
                foundAssocRules.
                GroupBy(assocRule => assocRule.DetailConsequence).
                Select(assocRuleGroup => assocRuleGroup.OrderByDescending(x => x.Reliability).First()).
                ToList();

            //Генерим рекоммендации

            List<Recommendation> newRecommendations =
                foundAssocRulesliability.Select(
                assocRule => new Recommendation(detail: assocRule.DetailConsequence,
                                                supportCount: assocRule.SupportCount.Value,
                                                supportPerc: assocRule.SupportPerc.Value,
                                                reliability: assocRule.Reliability.Value,
                                                lift: assocRule.Lift.Value)).
                                                ToList();
            //Сортируем
            newRecommendations = newRecommendations.OrderByDescending(x => x.Reliability).ToList();

            //Присваиваем на UI
            Recommendations = new ObservableCollection<Recommendation>(newRecommendations);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }    
}
