using System.Collections.Generic;

using AZK.AutoAnalytics.DesktopClient.ExcelReader.DataTypes;

namespace AZK.AutoAnalytics.DesktopClient.Model
{
    public interface IDetailSelectorModel
    {
        IEnumerable<string> ReadDetailsContains(string pattern = "");
    }
}
