using System.Collections.Generic;

using System.Linq;

using AZK.AutoAnalytics.DesktopClient.ExcelReader.DataTypes;

namespace AZK.AutoAnalytics.DesktopClient.Model
{
    public class MainWindowModel : IMainWindowModel
    {
        public IEnumerable<AssocRule> GetRecommendationsForDetail(string detail)
        {
            return InMemoryAssocRulesRepository.Instance.AssocRules.Where(ar => ar.DetailReason == detail);
        }
    }
}
