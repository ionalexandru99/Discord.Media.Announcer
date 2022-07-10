using Discord.Media.Announcer.Configuration;
using Discord.Media.Announcer.Extensions;

namespace Discord.Media.Announcer.DependencyInjection;

public static class Configurations
{
    public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptionsFromConfig<DiscordConfiguration>(configuration);

        return services;
    }
}