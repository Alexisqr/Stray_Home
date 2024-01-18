using Microsoft.AspNetCore.Authorization;

namespace StrayHome.API.Authorization
{
   public class AdminShelterRequirementAuthorizationHandler
        : AuthorizationHandler<AdminRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            AdminRequirement requirement )
        {
            if (!context.User.HasClaim(x => x.Type == CustomClaimTypes.IS_ADMIN_SHELTER))
                return Task.CompletedTask;

            var isUserAdminClaim = context.User.Claims.First(x => x.Type == CustomClaimTypes.IS_ADMIN_SHELTER).Value;
            
            if (isUserAdminClaim == "AdminShelter")
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
