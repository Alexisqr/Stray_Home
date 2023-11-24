using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Queries.GetAllShopItem;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetAllUser
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IEnumerable<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllUser();
        }
    }
}

