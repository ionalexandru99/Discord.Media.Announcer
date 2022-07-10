using System.Reflection;
using Discord.Media.Announcer;
using Discord.Media.Announcer.DependencyInjection;
using MediatR;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var configuration = context.Configuration;
        
        services.AddHostedService<Worker>();
        services.AddConfigurations(configuration);
        services.AddMediatR(Assembly.GetExecutingAssembly());
    })
    .Build();



await host.RunAsync();