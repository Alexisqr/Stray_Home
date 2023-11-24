using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Queries.GetShopItemById;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetByIdUser
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetByIdUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserById(request.ID);
        }


    }
   
}
