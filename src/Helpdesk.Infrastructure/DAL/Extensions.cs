using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Helpdesk.Infrastructure.DAL;

internal static class Extensions
{
    private const string OptionsSectionName = "postgres";
    
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {

        services.Configure<Configurations.PostgresOptions>(configuration.GetRequiredSection(OptionsSectionName));
        var postgresOptions = configuration.GetOptions<Configurations.PostgresOptions>(OptionsSectionName);
        services.AddDbContext<HelpdeskDbContext>(x => x.UseNpgsql(postgresOptions.ConnectionString));
        
        return services;
    }
}