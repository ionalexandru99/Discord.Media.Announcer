using Discord.Media.Announcer.Attributes;
using Discord.Media.Announcer.Configuration;

namespace Discord.Media.Announcer.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOptionsFromConfig<TClass>(this IServiceCollection serviceCollection, IConfiguration configuration)
        where TClass : class, IReadFromConfiguration, new()
    {
        var attribute = (ConfigurationSectionAttribute?) Attribute.GetCustomAttribute(typeof(TClass), typeof(ConfigurationSectionAttribute));

        if (attribute == null)
        {
            throw new NullReferenceException($"Cannot add options from configuration for class '{nameof(TClass)}' if attribute '{nameof(ConfigurationSectionAttribute)}' is not configured"); 
        }

        serviceCollection.Configure<TClass>(configuration.GetSection(attribute.Section));
        
        return serviceCollection;
    }
}