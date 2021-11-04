using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AZK.AutoAnalytics.DesktopClient.View.Configuration
{
    public class FontConfiguration : INotifyPropertyChanged
    {
        public static FontConfiguration Instance { get; set; } = new FontConfiguration();

        public double MainFontSize { get; set; } = 26;
        public double ElementsFontSize { get; set; } = 22;
        public double AdditionalFontSize { get; set; } = 24;
        public double TableFontSize { get; set; } = 22;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
