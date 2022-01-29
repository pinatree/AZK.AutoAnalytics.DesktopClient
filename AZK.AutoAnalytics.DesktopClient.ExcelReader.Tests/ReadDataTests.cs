//using NUnit.Framework;

//using System;
//using System.IO;
//using System.Collections.Generic;

//using AZK.AutoAnalytics.DesktopClient.ExcelReader.DataTypes;

//using System.Text.Json;
//using System.Linq;

//namespace AZK.AutoAnalytics.DesktopClient.ExcelReader.Tests
//{
//    public class ReadDataTests
//    {
//        [Test]
//        public void CanOpenExistsFile()
//        {
//            ExcelRulesReader excelRulesReader = new ExcelRulesReader(@".\TestFiles\FileWithHeader.xlsx");
//            Assert.Pass();
//        }

//        [Test]
//        public void CannotOpenNotExistsFile()
//        {
//            Assert.Throws(
//                typeof(FileNotFoundException),
//                () =>
//                {
//                    ExcelRulesReader excelRulesReader = new ExcelRulesReader(@".\TestFiles\dont_create_file_with_this_name_please_adsd1e.xlsx");
//                });
//        }

//        [Test]
//        public void FileLocationIsCorrect()
//        {
//            ExcelRulesReader excelRulesReader = new ExcelRulesReader(@".\TestFiles\FileWithHeader.xlsx");
//            string fileLocation = AppDomain.CurrentDomain.BaseDirectory;
//            Assert.AreEqual(excelRulesReader.FileLocation, fileLocation + @"TestFiles\FileWithHeader.xlsx");
//        }

//        [Test]
//        public void CanReadFileWithHeader()
//        {
//            ExcelRulesReader excelRulesReader = new ExcelRulesReader(@".\TestFiles\FileWithHeader.xlsx");
//            List<AssocRule> readedRules = excelRulesReader.ReadAssocRules(0, true, false);

//            List<AssocRule> compareRules = new List<AssocRule>()
//            {
//                new AssocRule()
//                {
//                    ReclamationId = "Рекламационный акт 000034431 от 07.05.2019 1:00:00",
//                    Detail = "6520-3501090-51 - колодка тормоза",
//                    IsConsequence = false
//                },
//                new AssocRule()
//                {
//                    ReclamationId = "Рекламационный акт 000034431 от 07.05.2019 1:00:00",
//                    Detail = "100.3522137 - кольцо уплотнительное",
//                    IsConsequence = true,
//                    RuleId = 9648,
//                    SupportCount = 82,
//                    SupportPerc = 0.105891164544539,
//                    Reliability = 23.768115942029,
//                    Lift = 204.50615136876
//                },
//                new AssocRule()
//                {
//                    ReclamationId = "Рекламационный акт 000116818 от 05.11.2019 5:00:00",
//                    Detail = "53205-3422011 - ремкомплект шарнира карданного",
//                    IsConsequence = false
//                }
//            };

//            Assert.NotNull(readedRules);
//            Assert.AreEqual(readedRules.Count, compareRules.Count);

//            //Проверяем, что все содержатся
//            foreach (var readed in readedRules)
//            {
//                //Содержится ли запись с точно такими же полями?
//                bool contains = compareRules.Any((compare) =>
//                {
//                    //Сравниваем все поля
//                    return
//                    (compare.ReclamationId == readed.ReclamationId) &&
//                    (compare.Detail == readed.Detail) &&
//                    (compare.IsConsequence == readed.IsConsequence) &&
//                    (compare.RuleId == readed.RuleId) &&
//                    (compare.SupportCount == readed.SupportCount) &&
//                    (compare.SupportPerc == readed.SupportPerc) &&
//                    (compare.Reliability == readed.Reliability) &&
//                    (compare.Lift == readed.Lift);
//                });

//                //Если нет - тест провален
//                if (contains == false)
//                {
//                    string serialized = JsonSerializer.Serialize(readed);
//                    Console.WriteLine("Doesnt contains: ");
//                    Console.WriteLine(serialized);

//                    Assert.Fail();
//                }
//            }
//        }

//        [Test]
//        public void CanReadFileWithoutHeader()
//        {
//            ExcelRulesReader excelRulesReader = new ExcelRulesReader(@".\TestFiles\FileWithoutHeader.xlsx");
//            List<AssocRule> readedRules = excelRulesReader.ReadAssocRules(0, false, false);

//            List<AssocRule> compareRules = new List<AssocRule>()
//            {
//                new AssocRule()
//                {
//                    ReclamationId = "Рекламационный акт 000034431 от 07.05.2019 1:00:00",
//                    Detail = "6520-3501090-51 - колодка тормоза",
//                    IsConsequence = false
//                },
//                new AssocRule()
//                {
//                    ReclamationId = "Рекламационный акт 000034431 от 07.05.2019 1:00:00",
//                    Detail = "100.3522137 - кольцо уплотнительное",
//                    IsConsequence = true,
//                    RuleId = 9648,
//                    SupportCount = 82,
//                    SupportPerc = 0.105891164544539,
//                    Reliability = 23.768115942029,
//                    Lift = 204.50615136876
//                },
//                new AssocRule()
//                {
//                    ReclamationId = "Рекламационный акт 000116818 от 05.11.2019 5:00:00",
//                    Detail = "53205-3422011 - ремкомплект шарнира карданного",
//                    IsConsequence = false
//                }
//            };

//            Assert.NotNull(readedRules);
//            Assert.AreEqual(readedRules.Count, compareRules.Count);

//            //Проверяем, что все содержатся
//            foreach (var readed in readedRules)
//            {
//                //Содержится ли запись с точно такими же полями?
//                bool contains = compareRules.Any((compare) =>
//                {
//                    //Сравниваем все поля
//                    return
//                    (compare.ReclamationId == readed.ReclamationId) &&
//                    (compare.Detail == readed.Detail) &&
//                    (compare.IsConsequence == readed.IsConsequence) &&
//                    (compare.RuleId == readed.RuleId) &&
//                    (compare.SupportCount == readed.SupportCount) &&
//                    (compare.SupportPerc == readed.SupportPerc) &&
//                    (compare.Reliability == readed.Reliability) &&
//                    (compare.Lift == readed.Lift);
//                });

//                //Если нет - тест провален
//                if (contains == false)
//                {
//                    string serialized = JsonSerializer.Serialize(readed);
//                    Console.WriteLine("Doesnt contains: ");
//                    Console.WriteLine(serialized);

//                    Assert.Fail();
//                }
//            }
//        }

//        [Test]
//        public void SkipUncorrectRecordsWorksCorrectly()
//        {
//            ExcelRulesReader excelRulesReader = new ExcelRulesReader(@".\TestFiles\FileWithoutHeader.xlsx");
//            List<AssocRule> readedRules = excelRulesReader.ReadAssocRules(0, false, true);

//            List<AssocRule> compareRules = new List<AssocRule>()
//            {
//                new AssocRule()
//                {
//                    ReclamationId = "Рекламационный акт 000034431 от 07.05.2019 1:00:00",
//                    Detail = "100.3522137 - кольцо уплотнительное",
//                    IsConsequence = true,
//                    RuleId = 9648,
//                    SupportCount = 82,
//                    SupportPerc = 0.105891164544539,
//                    Reliability = 23.768115942029,
//                    Lift = 204.50615136876
//                }
//            };

//            Assert.NotNull(readedRules);
//            Assert.AreEqual(readedRules.Count, compareRules.Count);

//            //Проверяем, что все содержатся
//            foreach (var readed in readedRules)
//            {
//                //Содержится ли запись с точно такими же полями?
//                bool contains = compareRules.Any((compare) =>
//                {
//                    //Сравниваем все поля
//                    return
//                    (compare.ReclamationId == readed.ReclamationId) &&
//                    (compare.Detail == readed.Detail) &&
//                    (compare.IsConsequence == readed.IsConsequence) &&
//                    (compare.RuleId == readed.RuleId) &&
//                    (compare.SupportCount == readed.SupportCount) &&
//                    (compare.SupportPerc == readed.SupportPerc) &&
//                    (compare.Reliability == readed.Reliability) &&
//                    (compare.Lift == readed.Lift);
//                });

//                //Если нет - тест провален
//                if (contains == false)
//                {
//                    string serialized = JsonSerializer.Serialize(readed);
//                    Console.WriteLine("Doesnt contains: ");
//                    Console.WriteLine(serialized);

//                    Assert.Fail();
//                }
//            }
//        }
//    }
//}