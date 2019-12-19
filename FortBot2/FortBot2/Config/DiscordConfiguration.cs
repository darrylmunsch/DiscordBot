using Discord;
using Discord.Commands;
using Discord.WebSocket;
using FortBot2.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace FortBot2.Config
{
    public static class DiscordConfiguration
    {
        public static async Task ConfigureAndRun(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            var discordToken = configuration["discordToken"];
            if (string.IsNullOrEmpty(discordToken))
            {
                throw new Exception("Please verify your token is correct and supplied in appsettings.json or appsettings.dev.json.");
            }

            var discord = serviceProvider.GetRequiredService<DiscordSocketClient>();
            await discord.LoginAsync(TokenType.Bot, discordToken);
            await discord.StartAsync();

            var commands = serviceProvider.GetRequiredService<CommandService>();
            await commands.AddModulesAsync(Assembly.GetEntryAssembly(), serviceProvider);
        }
    }
}
