using System.Reflection;
using Helpdesk.Core.Abstractions;
using Helpdesk.Core.Repositories;
using Helpdesk.Infrastructure.DAL;
using Helpdesk.Infrastructure.DAL.Repositories;
using Helpdesk.Infrastructure.Secure;
using Helpdesk.Infrastructure.Time;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Helpdesk.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<IClock, Clock>();
        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        
        
        services.AddPostgres(configuration);
        services.AddSecure();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
    
   
        
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