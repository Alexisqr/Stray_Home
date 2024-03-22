using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Infrastructure.ExcelService
{
    public interface IExcelProcessingService
    {
        string[,] ReadExcel(IFormFile filePath);
    }
}
