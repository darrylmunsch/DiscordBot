using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace FortBot2.Config
{
    public class CommandHandler
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;
        private readonly IServiceProvider _services;
        private readonly IConfigurationRoot _config;


        public CommandHandler(
            DiscordSocketClient client, 
            CommandService commands,
            IServiceProvider service,
            IConfigurationRoot config)
        {
            _commands = commands;
            _client = client;
            _services = service;
            _config = config;

            _client.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage messageParam)
        {
            // Don't process if system message.
            var message = messageParam as SocketUserMessage; // Make sure message is from user/bot

            if (message == null) return;

            var context = new SocketCommandContext(_client, message); // Create context of command
            
            int argPos = 0; // Create a number to track where the prefix ends and the command begins

            if (!(message.HasCharPrefix('!', ref argPos) ||
                message.HasMentionPrefix(_client.CurrentUser, ref argPos)) ||
                message.Author.IsBot)
                return;

            var prefix = _config["prefix"];
            if (message.HasStringPrefix(prefix, ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var result = await _commands.ExecuteAsync(context, argPos, _services);     // Execute the command

                if (!result.IsSuccess)     // If not successful, reply with the error.
                    await context.Channel.SendMessageAsync(result.ToString());
            }

        }

    }
}
