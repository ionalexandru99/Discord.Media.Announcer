using Discord.Media.Announcer;
using Discord.Media.Announcer.DependencyInjection;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var configuration = context.Configuration;
        
        services.AddHostedService<Worker>();
        services.AddConfigurations(configuration);
    })
    .Build();



await host.RunAsync();