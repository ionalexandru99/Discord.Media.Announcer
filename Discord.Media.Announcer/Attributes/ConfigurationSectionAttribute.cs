namespace Discord.Media.Announcer.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class ConfigurationSectionAttribute : Attribute
{
    public ConfigurationSectionAttribute(string section)
    {
        Section = section;
    }

    public string Section { get; }
}