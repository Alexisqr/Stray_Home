using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.DeleteShopItem
{
    public class DeleteShopItemCommand : IRequest
    {
        public Guid ID { get; set; }
    }
}
