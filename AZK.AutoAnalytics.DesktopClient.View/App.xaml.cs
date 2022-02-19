using AZK.AutoAnalytics.DesktopClient.ExcelReader;
using AZK.AutoAnalytics.DesktopClient.ExcelReader.DataTypes;
using AZK.AutoAnalytics.DesktopClient.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AZK.AutoAnalytics.DesktopClient.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var reader = new ExcelRulesReader(AppDomain.CurrentDomain.BaseDirectory + @"\AnalysisData\EXPORT_FROM_DEDUCTOR.xlsx");
            List<AssocRule> readed = reader.ReadAssocRules(0, true, true);

            InMemoryAssocRulesRepository.Instance = new InMemoryAssocRulesRepository(readed);
        }
    }
}
