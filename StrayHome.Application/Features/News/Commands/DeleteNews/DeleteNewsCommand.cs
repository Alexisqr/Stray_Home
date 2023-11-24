﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.DeleteNews
{
    public class DeleteNewsCommand : IRequest
    {
        public Guid ID { get; set; }
    }
}
