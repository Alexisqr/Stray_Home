using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.AddListOfAnimals;
using StrayHome.Application.Features.Commands.GetAnimalInExcel;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.GetAnimalsInExcel
{
    public class GetAnimalsInExcelCommandHandler : IRequestHandler<GetAnimalsInExcelCommand, FileContentResult>
    {
        private readonly IStrayHomeContext _context;
        private readonly IExcelProcessingService _excelProcessingService;
        public GetAnimalsInExcelCommandHandler(IStrayHomeContext context, IExcelProcessingService excelProcessingService)
        {
            _context = context;
            _excelProcessingService = excelProcessingService;
        }

        public async Task<FileContentResult> Handle(GetAnimalsInExcelCommand request, CancellationToken cancellationToken)
        {
            var shelterAdmins = await _context.ShelterAdmins.FirstAsync(p => p.AdministratorID == request.ID);

            var shelterAnimals = _context.Animals.Where(a => a.ShelterID == shelterAdmins.ShelterID);
            var excelFile = _excelProcessingService.WriteAnimalsInExcel(shelterAnimals);
            return await excelFile;
        }
    }
}
