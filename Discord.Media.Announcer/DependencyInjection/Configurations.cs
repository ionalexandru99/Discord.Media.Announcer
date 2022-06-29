using Discord.Media.Announcer.Configuration;

namespace Discord.Media.Announcer.DependencyInjection;

public static class Configurations
{
    public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DiscordConfiguration>(configuration.GetSection(DiscordConfiguration.SectionName));

        return services;
    }
}