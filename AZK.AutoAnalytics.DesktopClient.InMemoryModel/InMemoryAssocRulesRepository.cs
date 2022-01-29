using AZK.AutoAnalytics.DesktopClient.ExcelReader.DataTypes;
using System.Collections.Generic;
using System.Linq;

namespace AZK.AutoAnalytics.DesktopClient.Model
{
    public class InMemoryAssocRulesRepository
    {
        public static InMemoryAssocRulesRepository Instance;

        public List<AssocRule> AssocRules
        {
            get;
            private set;
        }

        public List<string> AvailableDetails
        {
            get;
            private set;
        }

        public InMemoryAssocRulesRepository(List<AssocRule> rules)
        {
            this.AssocRules = rules;
            this.AvailableDetails = rules.Select(rule => rule.DetailReason).Distinct().OrderBy(x => x).ToList();
        }
    }
}
