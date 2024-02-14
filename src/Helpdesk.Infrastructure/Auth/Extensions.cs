using Microsoft.AspNetCore.Authorization;

namespace Helpdesk.Infrastructure.Auth;

public static class Extensions
{
    public static void AddPolicies(this AuthorizationOptions options)
    {
        options.AddPolicy("is-admin", policy =>
        {
            policy.RequireRole("Admin");
        });
        
        options.AddPolicy("is-agent", policy =>
        {
            policy.RequireRole("Agent");
        });
        
        options.AddPolicy("is-user", policy =>
        {
            policy.RequireRole("User");
        });
    }
}