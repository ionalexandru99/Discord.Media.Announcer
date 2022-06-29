using Discord.Media.Announcer.Constants;
using DSharpPlus;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Options;
using DiscordConfiguration = Discord.Media.Announcer.Configuration.DiscordConfiguration;

namespace Discord.Media.Announcer;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly DiscordConfiguration _discordConfiguration;
    
    private DiscordClient? _discordClient;

    public Worker(ILogger<Worker> logger, IOptions<DiscordConfiguration> discordConfiguration)
    {
        _logger = logger;
        _discordConfiguration = discordConfiguration.Value;
    }

    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting Discord Bot with the name {BotName}", DiscordBotConstants.DiscordBotName);

        _discordClient = new DiscordClient(new DSharpPlus.DiscordConfiguration
        {
            Token = _discordConfiguration.Token,
            TokenType = TokenType.Bot,
            Intents = DiscordIntents.AllUnprivileged
        });

        _discordClient.MessageCreated += OnMessageCreated;
        await _discordClient.ConnectAsync();
    }
    
    protected override Task ExecuteAsync(CancellationToken stoppingToken) => Task.CompletedTask;

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        if (_discordClient != null)
        {
            _discordClient.MessageCreated -= OnMessageCreated;
            await _discordClient.DisconnectAsync();
            _discordClient.Dispose();
        }

        _logger.LogInformation("Discord bot with name {BotName} has stopped", DiscordBotConstants.DiscordBotName);
    }

    private async Task OnMessageCreated(DiscordClient client, MessageCreateEventArgs e)
    {
        if (e.Message.Content.StartsWith("ping", StringComparison.OrdinalIgnoreCase))
        {
            _logger.LogInformation("pinged, responding with pong!");
            await e.Message.RespondAsync("pong!");
        }
    }
}