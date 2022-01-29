using System;
using System.Collections.Generic;
using System.IO;
using AZK.AutoAnalytics.DesktopClient.ExcelReader.DataTypes;
using OfficeOpenXml;

namespace AZK.AutoAnalytics.DesktopClient.ExcelReader
{
    public class ExcelRulesReader
    {
        public string FileLocation
        {
            get
            {
                return _fs.Name;
            }
        }

        private FileStream _fs;

        public ExcelRulesReader(string filePath)
        {
            //Проверяем наличие файла
            if (File.Exists(filePath) == false)
                throw new FileNotFoundException("Файл по пути " + filePath + " не найден. Открытие невозможно.");

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            _fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        }

        public List<AssocRule> ReadAssocRules(int sheet = 0, bool hasHeader = true, bool skipUncorrectRecords = false)
        {
            if (sheet < 0)
                throw new ArgumentException("Отрицательное значение листа Excel недопустимо. Значение: " + sheet);

            int startPos = hasHeader ? 2 : 1;

            ExcelPackage package = new ExcelPackage(_fs);

            ExcelWorksheet workSheet = package.Workbook.Worksheets[sheet];

            List<AssocRule> readRecords = new List<AssocRule>(workSheet.Dimension.End.Row - 1);

            //Проходимся по всем строкам
            for (int rowNumber = startPos; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
            {
                AssocRule record = new AssocRule();

                int ruleId;
                if (int.TryParse(workSheet.Cells[rowNumber, 1].Value?.ToString(), out ruleId))
                {
                    record.RuleId = ruleId;
                }
                else if (skipUncorrectRecords)
                {
                    continue;
                }

                int elementNum;
                if (int.TryParse(workSheet.Cells[rowNumber, 2].Value?.ToString(), out elementNum))
                {
                    record.ElementNum = elementNum;
                }
                else if (skipUncorrectRecords)
                {
                    continue;
                }

                record.DetailReason = workSheet.Cells[rowNumber, 3].Value?.ToString();

                record.DetailConsequence = workSheet.Cells[rowNumber, 4].Value?.ToString();  

                if (workSheet.Cells[rowNumber, 5].Value != null)
                {
                    int supportCount;
                    if (int.TryParse(workSheet.Cells[rowNumber, 5].Value?.ToString(), out supportCount))
                    {
                        record.SupportCount = supportCount;
                    }
                    else if (skipUncorrectRecords)
                    {
                        continue;
                    }
                }

                if (workSheet.Cells[rowNumber, 6].Value != null)
                {
                    double supportPerc;
                    if (double.TryParse(workSheet.Cells[rowNumber, 6].Value?.ToString(), out supportPerc))
                    {
                        record.SupportPerc = supportPerc;
                    }
                    else if (skipUncorrectRecords)
                    {
                        continue;
                    }
                }

                if (workSheet.Cells[rowNumber, 7].Value != null)
                {
                    double reliability;
                    if (double.TryParse(workSheet.Cells[rowNumber, 7].Value?.ToString(), out reliability))
                    {
                        record.Reliability = reliability;
                    }
                    else if (skipUncorrectRecords)
                    {
                        continue;
                    }
                }

                if (workSheet.Cells[rowNumber, 8].Value != null)
                {
                    double lift;
                    if (double.TryParse(workSheet.Cells[rowNumber, 8].Value?.ToString(), out lift))
                    {
                        record.Lift = lift;
                    }
                    else if (skipUncorrectRecords)
                    {
                        continue;
                    }
                }

                readRecords.Add(record);
            }

            return readRecords;
        }
    }
}
