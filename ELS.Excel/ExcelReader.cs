using ELS.UseCase.PluginInterfaces.Common;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace ELS.Excel
{
    public class ExcelReader : IExcelReader
    {
        public List<T> ReadExcel<T>(string filePath) where T : new()
        {
            List<T> list = new();
            using (FileStream file = new(filePath, FileMode.Open, FileAccess.Read))
            {
                XSSFWorkbook workbook = new(file);
                ISheet sheet = workbook.GetSheetAt(0);
                IRow headerRow = sheet.GetRow(0);
                int cellCount = headerRow.LastCellNum;
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;
                    T obj = new();
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                        if (row.GetCell(j) != null)
                            obj.GetType().GetProperty(headerRow.GetCell(j).StringCellValue)?.SetValue(obj, row.GetCell(j).ToString(), null);
                    list.Add(obj);
                }
            }
            return list;
        }

        public List<T> ReadExcel<T>(byte[] content) where T : new()
        {
            List<T> list = new();
            using (MemoryStream file = new (content))
            {
                XSSFWorkbook workbook = new(file);
                ISheet sheet = workbook.GetSheetAt(0);
                IRow headerRow = sheet.GetRow(0);
                int cellCount = headerRow.LastCellNum;
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;
                    T obj = new();
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                        if (row.GetCell(j) != null)
                            obj.GetType().GetProperty(headerRow.GetCell(j).StringCellValue)?.SetValue(obj, row.GetCell(j).ToString(), null);
                    list.Add(obj);
                }
            }

            return list;
        }
    }
}