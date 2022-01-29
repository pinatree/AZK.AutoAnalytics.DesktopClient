using System;
using System.Collections.Generic;

#nullable disable

namespace AZK.AutoAnalytics.DesktopClient.Repository.LocalStorage.DataTypes.DetailAnalysis
{ 
    public partial class TAssocRule
    {
        public long Id { get; set; }
        public long ReasonDetailId { get; set; }
        public long ConsequenceDetailId { get; set; }

        public DateTime CCalcDate { get; set; }
        public long CSupportCount { get; set; }
        public decimal CSupportPerc { get; set; }
        public decimal CReliability { get; set; }
        public decimal CLift { get; set; }

        public TDetail ReasonDetail { get; set; }
        public TDetail ConsequenceDetail { get; set; }
    }
}
