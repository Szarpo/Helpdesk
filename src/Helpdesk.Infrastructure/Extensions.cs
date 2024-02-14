using System.Reflection;
using Helpdesk.Application.Auth;
using Helpdesk.Core.Abstractions;
using Helpdesk.Core.Repositories;
using Helpdesk.Infrastructure.Auth;
using Helpdesk.Infrastructure.DAL;
using Helpdesk.Infrastructure.DAL.Repositories;
using Helpdesk.Infrastructure.Secure;
using Helpdesk.Infrastructure.Time;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Helpdesk.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddHttpContextAccessor()
            .AddPostgres(configuration)
            .AddSecure();
        
        services.AddControllers();
        services.AddAuthorization(x=> x.AddPolicies());
        
        var cookieOptions = configuration.GetSection(CookiesOptions.SectionName).Get<CookiesOptions>();
            
        services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                if (!string.IsNullOrEmpty(cookieOptions!.Domain)) 
                   options.Cookie.Domain = cookieOptions!.Domain;
                
                options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
                options.SlidingExpiration = true;
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Events.OnRedirectToAccessDenied = context =>
                {
                    context.Response.StatusCode = 403;
                    return Task.CompletedTask;
                };

                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            }); 
        
        
        services.AddHttpContextAccessor();
        services.AddPostgres(configuration);
        services.AddSecure();
        services.AddSingleton<IClock, Clock>();
        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICookieAuthorizationService, CookieAuthorizationService>();

    
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
    
        app.UseReDoc(reDoc =>
        {
            reDoc.RoutePrefix = "docs";
            reDoc.SpecUrl("/swagger/v1/swagger.json");
        });
        
        return app;
    }

    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var options = new T();
        var section = configuration.GetRequiredSection(sectionName);
        section.Bind(options);

        return options;
    }
    
}