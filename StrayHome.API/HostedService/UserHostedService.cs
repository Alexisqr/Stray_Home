using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.CreateUser;
using StrayHome.Application.Features.Queries.GetAllUser;
using StrayHome.Domain.Entities;
using StrayHome.Domain.Enums;
using StrayHome.Infrastructure.Data;

namespace StrayHome.API.HostedService
{
    public class UserHostedService : IHostedService
    {
        public IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;
        // private readonly IPasswordHasher _passwordHasher;
        public UserHostedService(IConfiguration configuration, IServiceProvider serviceProvider, IPasswordHasher passwordHasher)
        {
            _configuration = configuration;
            _serviceProvider = serviceProvider;
            //_passwordHasher = passwordHasher;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // Перший варіант(через медіатор)
            // Створює звичайний User для Admin треба продумати логіку отримання та створити команду

            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                var users = await mediator.Send(new GetAllUserQuery());

                if (!users.Any())
                {
                    await mediator.Send(new CreateUserCommand() { Username = _configuration["ReserveUser:Username"],
                       Email = _configuration["ReserveUser:Email"],
                       Password = _configuration["ReserveUser:Password"]});
                }
            }

            // Другий варіант(через "Context")
            // Створює звичайний Admin але хешування пароля не працює тому що IPasswordHasher є службою scoped service,
            // поки не знаю як це вирішити

            //using (var scope = _serviceProvider.CreateScope())
            //{
            //    var dbContext = scope.ServiceProvider.GetRequiredService<StrayHomeContext>();

            //    if (!dbContext.Users.Any())
            //    {
            //        byte[] salt;
            //        var password = _passwordHasher.Hash(_configuration["ReserveUser:Username"], out salt);
            //        dbContext.Users.Add(new User {
            //            Username = _configuration["ReserveUser:Username"],
            //            Password = password,
            //            Salt = Convert.ToBase64String(salt),
            //            Role = UserRole.Admin,
            //            Email = _configuration["ReserveUser:Email"],
            //            CreationDate = DateTime.UtcNow,
            //        });
            //        dbContext.SaveChanges();
            //    }
            //}

        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
