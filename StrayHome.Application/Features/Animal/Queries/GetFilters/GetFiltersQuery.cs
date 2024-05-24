using MediatR;
using StrayHome.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetFilters
{
    public class GetFiltersQuery : IRequest<FilterDto>
    {

    }
}
