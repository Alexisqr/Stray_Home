using Microsoft.AspNetCore.Authorization;

namespace StrayHome.API.Authorization
{
    public class AdminRequirementAuthorizationHandler
        : AuthorizationHandler<AdminRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            AdminRequirement requirement)
        {
            if (!context.User.HasClaim(x => x.Type == CustomClaimTypes.IS_ADMIN))
                return Task.CompletedTask;

            var isUserAdminClaim = context.User.Claims.First(x => x.Type == CustomClaimTypes.IS_ADMIN).Value;

            if (isUserAdminClaim == "Admin") 
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
