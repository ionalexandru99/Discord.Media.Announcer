using Discord.Media.Announcer.Attributes;

namespace Discord.Media.Announcer.Configuration;

[ConfigurationSection("DiscordConfiguration")]
public class DiscordConfiguration : IReadFromConfiguration
{
    public string Token { get; set; }
}