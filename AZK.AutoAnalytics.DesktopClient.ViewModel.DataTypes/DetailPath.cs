namespace AZK.AutoAnalytics.DesktopClient.Model.DataTypes
{
    public class DetailPath
    {
        public string Group { get; set; }

        public string Subgroup { get; set; }

        public string Detail { get; set; }

        public DetailPath(string group, string subgroup, string detail)
        {
            this.Group = group;
            this.Subgroup = subgroup;
            this.Detail = detail;
        }

        //Переопределяем оператор Equals
        public bool Equals(DetailPath compare)
        {
            if (compare is null)
            {
                return false;
            }

            // Optimization for a common success case.
            if (object.ReferenceEquals(this, compare))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != compare.GetType())
            {
                return false;
            }

            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            return
                (this.Group == compare.Group) &&
                (this.Subgroup == compare.Subgroup) &&
                (this.Detail == compare.Detail);
        }
    }
}
