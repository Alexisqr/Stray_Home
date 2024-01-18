using Microsoft.AspNetCore.Authorization;

namespace StrayHome.API.Authorization
{
    public class AdminShelterRequirement : IAuthorizationRequirement
    {
        public AdminShelterRequirement()
        {
        }
    }
}
