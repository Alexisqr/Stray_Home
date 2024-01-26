using Microsoft.AspNetCore.Authorization;

namespace StrayHome.Infrastructure.Authorization
{
    public class AdminShelterRequirement : IAuthorizationRequirement
    {
        public AdminShelterRequirement()
        {
        }
    }
}
