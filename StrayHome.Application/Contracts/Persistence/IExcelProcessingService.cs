using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Contracts.Persistence
{
    public interface IExcelProcessingService
    {
        string[,] ReadExcel(IFormFile filePath);
        Task<FileContentResult> WriteAnimalsInExcel(IEnumerable<Animal> animals);
    }
}

