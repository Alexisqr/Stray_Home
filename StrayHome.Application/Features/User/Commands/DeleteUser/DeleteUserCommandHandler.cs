using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Featuresb.Commands.DeleteUser;
using StrayHome.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {

        private readonly IStrayHomeContext _context;

        public DeleteUserCommandHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {

            var toDelete = await _context.Users.FirstAsync(p => p.ID == request.ID);

            if (toDelete == null)
            {
                throw new Exception();
            }

            var userAnimals = _context.UserAnimals.Where(a => a.UserID == request.ID);
            _context.UserAnimals.RemoveRange(userAnimals);
            var userComments = _context.Comments.Where(a => a.UserID == request.ID);
            _context.Comments.RemoveRange(userComments);
            var userShopItem = _context.UserShopItems.Where(a => a.UserID == request.ID);
            _context.UserShopItems.RemoveRange(userShopItem);

            //if (toDelete.Role == UserRole.Admin)
            //{
            //    throw new Exception($"It is not possible to delete a user who is the administrator of the shelter");
            //}

            var hopItem = _context.Users
                .FirstOrDefault(p => p.ID == toDelete.ID);

            _context.Users.Remove(hopItem);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }

    }
}

