﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Org.BouncyCastle.Utilities.Encoders;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Domain.Entities;
using StrayHome.Domain.Enums;

namespace StrayHome.Infrastructure.ExcelService
{
    public class ExcelProcessingService : IExcelProcessingService
    {
        public string[,] ReadExcel(IFormFile filePath)
        {
            int startRow = 3;
            int startColumn = 2; 
            int endColumn = 10;

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
            // реалізувати перетворення змасива в обєкт animal dto
                workbook.Close();
                return data;
            }
            
            
        }

        public async Task<FileContentResult> WriteAnimalsInExcel(IEnumerable<Animal> animals)
        {
           
            var workbook = new XSSFWorkbook();
            var sheet = workbook.CreateSheet("Animals");

            var firstRow = sheet.CreateRow(0);
            firstRow.CreateCell(0).SetCellValue("Name");
            firstRow.CreateCell(1).SetCellValue("Description");
            firstRow.CreateCell(2).SetCellValue("Photos");
            firstRow.CreateCell(3).SetCellValue("IsAvailableForAdoption");
            firstRow.CreateCell(4).SetCellValue("Location");
            firstRow.CreateCell(5).SetCellValue("TypeAnimal");
            firstRow.CreateCell(6).SetCellValue("Sex");
            firstRow.CreateCell(7).SetCellValue("Sterilization");
            firstRow.CreateCell(8).SetCellValue("Age");


            int index = 1;
            foreach (var animal in animals)
            {
                var row = sheet.CreateRow(index++);
                row.CreateCell(0).SetCellValue(animal.Name);
                row.CreateCell(1).SetCellValue(animal.Description);
                row.CreateCell(2).SetCellValue(animal.Photos);
                row.CreateCell(3).SetCellValue(animal.IsAvailableForAdoption ? "1" : "0");
                row.CreateCell(4).SetCellValue(animal.Location);
                row.CreateCell(5).SetCellValue(animal.TypeAnimal.ToString());
                row.CreateCell(6).SetCellValue(animal.Sex.ToString());
                row.CreateCell(7).SetCellValue(animal.Sterilization);
                row.CreateCell(8).SetCellValue(animal.Age);
            }
                

            using (var filePath = new MemoryStream())
            {
                workbook.Write(filePath);
                var fileBytes = filePath.ToArray();

                var fileContentResult = new FileContentResult(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = "animals.xlsx"
                };

                return await Task.FromResult(fileContentResult);
            }

        }
    }
}
