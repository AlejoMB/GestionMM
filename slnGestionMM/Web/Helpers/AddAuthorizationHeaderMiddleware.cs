using System.Security.Claims;

namespace Web.Helpers
{
    public class AddAuthorizationHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public AddAuthorizationHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            var user = context.User;

            // Check if the user is authenticated and has a valid JWT token
            if (user.Identity.IsAuthenticated && user.Identity.AuthenticationType == "Bearer")
            {
                // Get the JWT token from the user's claims
                var token = user.Claims.FirstOrDefault(c => c.Type == "token")?.Value;

                // Add the JWT token to the request headers
                context.Request.Headers.Add("Authorization", "Bearer " + token);
            }

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }
}
