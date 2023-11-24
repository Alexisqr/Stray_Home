using MediatR;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.CreateUserShopItem
{
    public class CreateUserShopItemCommand : IRequest<UserShopItem>
    {
        public Guid UserID { get; set; }
        public Guid ShopItemID { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
