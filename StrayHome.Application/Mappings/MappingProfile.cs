using AutoMapper;
using StrayHome.Application.Features.Commands.UpdateShopItem;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           // CreateMap<ShopItem, ShopItemVm>().ReverseMap();
           // CreateMap<ShopItem, CheckoutShopItemCommand>().ReverseMap();
           // CreateMap<ShopItem, GetShopItemByIdCommand>().ReverseMap();
        }
    }
}
