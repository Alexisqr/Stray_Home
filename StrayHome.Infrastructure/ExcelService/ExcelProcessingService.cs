using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
namespace StrayHome.Infrastructure.ExcelService
{
    public class ExcelProcessingService : IExcelProcessingService
    {
        public string[,] ReadExcel(IFormFile filePath)
        {
            int startRow = 3;
            int startColumn = 2; 
            int endColumn = 5;

            using (var stream = new MemoryStream())
            {
                filePath.CopyTo(stream);
                stream.Position = 0;
                XSSFWorkbook workbook = new XSSFWorkbook(stream);
            ISheet sheet = workbook.GetSheetAt(0);

            int count = sheet.LastRowNum + 1;
            int columnCount = endColumn - startColumn + 1;
            string[,] data = new string[count - startRow, columnCount];

            for (int row = startRow; row < count; row++)
            {
                for (int col = startColumn; col <= endColumn; col++)
                {
                    var cell = sheet.GetRow(row).GetCell(col);
                     
                    if (cell != null)
                    {
                        data[row - startRow, col - startColumn] = cell.ToString();
                    }
                    else
                    {
                        data[row - startRow, col - startColumn] = string.Empty;
                    }
                }
            }
                workbook.Close();
                return data;
            }
            
            
        }
    }
}
