using Microsoft.AspNetCore.Authorization;

namespace StrayHome.API.Authorization
{
    public class AdminRequirement : IAuthorizationRequirement
    {
        public AdminRequirement()
        {
        }
    }
}