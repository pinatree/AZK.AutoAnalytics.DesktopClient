using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AZK.AutoAnalytics.DesktopClient.View.Configuration
{
    public class FontConfiguration : INotifyPropertyChanged
    {
        public static FontConfiguration Instance { get; set; } = new FontConfiguration();

        private double _mainFontSize = 22;
        public double MainFontSize
        {
            get => _mainFontSize;
            private set
            {
                if(_mainFontSize != value)
                {
                    _mainFontSize = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
