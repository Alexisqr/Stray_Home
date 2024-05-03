﻿using StrayHome.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Contracts.Persistence
{
    public interface ISeleniumService
    {
       Task<List<MissingAnimalSeleniumDto>> DataSearch();
    }
}
