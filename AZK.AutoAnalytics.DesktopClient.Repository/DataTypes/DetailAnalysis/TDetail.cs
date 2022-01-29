using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AZK.AutoAnalytics.DesktopClient.Repository.LocalStorage.DataTypes.DetailAnalysis
{
    [Table("TDETAIL", Schema = "DETAIL_ANALYTICS")]
    public partial class TDetail
    {
        public long Id { get; set; }
        public long SubgroupId { get; set; }
        public string CName { get; set; }

        public virtual TSubgroup Subgroup { get; set; }
        //public virtual ICollection<TCrash> TCrashes { get; set; }
    }
}
