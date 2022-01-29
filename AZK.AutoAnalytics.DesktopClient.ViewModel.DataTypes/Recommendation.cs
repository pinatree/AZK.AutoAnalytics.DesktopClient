namespace AZK.AutoAnalytics.DesktopClient.Model.DataTypes
{
    public class Recommendation
    {
        //Рекомендуемая деталь
        public string Detail { get; set; }

        //Поддержка, шт.
        public int SupportCount { get; set; }

        //Поддержка, %
        public double SupportPerc { get; set; }

        //Достоверность, %
        public double Reliability { get; set; }

        //Лифт
        public double Lift { get; set; }

        public Recommendation(string detail, int supportCount, double supportPerc, double reliability, double lift)
        {
            this.Detail = detail;
            this.SupportCount = supportCount;
            this.SupportPerc = supportPerc;
            this.Reliability = reliability;
            this.Lift = lift;
        }
    }
}
