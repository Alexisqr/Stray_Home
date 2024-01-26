using Microsoft.AspNetCore.Authorization;

namespace StrayHome.Infrastructure.Authorization
{
    public class AdminRequirement : IAuthorizationRequirement
    {
        public AdminRequirement()
        {
        }
    }
}