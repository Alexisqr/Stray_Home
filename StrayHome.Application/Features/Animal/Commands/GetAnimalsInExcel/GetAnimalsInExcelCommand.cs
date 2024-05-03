using MediatR;
using Microsoft.AspNetCore.Mvc;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.GetAnimalInExcel
{
    public class GetAnimalsInExcelCommand : IRequest<FileContentResult>
    {
        public Guid ID { get; set; }
    }
}
