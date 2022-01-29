using System;
using System.Collections.Generic;

#nullable disable

namespace AZK.AutoAnalytics.DesktopClient.Repository.LocalStorage.DataTypes.DetailAnalysis
{
    public partial class TGroup
    {
        public long Id { get; set; }
        public string CName { get; set; }

        public virtual ICollection<TSubgroup> TSubgroups { get; set; }
    }
}
