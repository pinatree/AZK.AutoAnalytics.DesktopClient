using System.Collections.Generic;

using System.Linq;

using AZK.AutoAnalytics.DesktopClient.ExcelReader.DataTypes;

namespace AZK.AutoAnalytics.DesktopClient.Model
{
    public class DetailSelectorModel : IDetailSelectorModel
    {
        public IEnumerable<string> ReadDetailsContains(string pattern = "")
        {
            return InMemoryAssocRulesRepository.
                Instance.
                AssocRules.
                Where(ar => ar.DetailReason.Contains(pattern)).
                Select(ar => ar.DetailReason).
                Distinct().
                OrderBy(x => x);
        }
    }
}
