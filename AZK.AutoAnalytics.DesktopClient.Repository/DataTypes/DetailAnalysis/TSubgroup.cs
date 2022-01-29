using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AZK.AutoAnalytics.DesktopClient.Repository.LocalStorage.DataTypes.DetailAnalysis
{
    [Table("TSUBGROUP", Schema = "DETAIL_ANALYTICS")]
    public partial class TSubgroup
    {
        public long Id { get; set; }
        public long GroupId { get; set; }
        public string CName { get; set; }

        public virtual TGroup Group { get; set; }
        public virtual ICollection<TDetail> TDetails { get; set; }
    }
}
