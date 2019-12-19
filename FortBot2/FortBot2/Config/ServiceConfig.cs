using System;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FortBot2.Config
{
    public static class ServiceConfig
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(new DiscordSocketClient(new DiscordSocketConfig
            {                                               // Add discord to the collection
                LogLevel = LogSeverity.Verbose,             // Tell the logger to give verbose amount of info
                MessageCacheSize = 1000                     // Cache 1000 messages per channel
            }))
            .AddSingleton(new CommandService(new CommandServiceConfig
            {                                               // Add command service to the collection
                LogLevel = LogSeverity.Verbose,             // Tell the logger to give verbose amount of info
                DefaultRunMode = RunMode.Async              // Force all commands to run async by default
            }))
            .AddSingleton<CommandHandler>()                 // Add the command handler to the coolection
            .AddSingleton<EventHandler>()                   // Add the event handler to the collection
            .AddSingleton<Random>()                         // Add random to the collection
            .AddSingleton((IConfigurationRoot)configuration);   // Add the config to the collection
        }
    }
}
