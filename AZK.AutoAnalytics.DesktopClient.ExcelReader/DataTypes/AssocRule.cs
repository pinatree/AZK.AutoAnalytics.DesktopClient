using System;

namespace AZK.AutoAnalytics.DesktopClient.ExcelReader.DataTypes
{
    //Ассоциативное правило из файла excel
    [Serializable]
    public class AssocRule
    {
        //Номер правила
        public int RuleId { get; set; }

        public int ElementNum { get; set; }

        public string DetailReason { get; set; }

        public string DetailConsequence { get; set; }

        //Поддержка, шт.
        public int? SupportCount { get; set; }

        //Поддержка, %
        public double? SupportPerc { get; set; }

        //Достоверность, %
        public double? Reliability { get; set; }

        //Лифт
        public double? Lift { get; set; }
    }
}
