using Microsoft.AspNetCore.Authorization;

namespace Helpdesk.Infrastructure.Auth;

public static class Extensions
{
    public static void AddPolicies(this AuthorizationOptions options)
    {
        options.AddPolicy("is-admin", policy =>
        {
            policy.RequireRole("admin");
        });
    }
}