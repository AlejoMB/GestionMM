using Microsoft.AspNetCore.Authorization;
using Services.Authentication;
using System.Security.Claims;

namespace WebAPI.Authentication
{
    public class AuthorizationHandler //: AuthorizationHandler<RoleBaseRequirement>, IAuthorizationRequirement
    {
        /*public AuthorizationHandler()
        {
            
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleBaseRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Role) || !context.User.HasClaim(c => c.Type == ClaimTypes.NameIdentifier))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            //var roles = context.User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);

            context.Succeed(requirement);
            return Task.CompletedTask;
        }*/
    }
}
