using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace FortBot2.Config
{
    public class EventHandler
    {
        private readonly DiscordSocketClient _client;

        public EventHandler(DiscordSocketClient client)
        {
            _client = client;
            _client.UserJoined += NewMemberPrompt;
        }

        private async Task NewMemberPrompt(SocketGuildUser user)
        {
            var guild = user.Guild;
            var channel = guild.DefaultChannel;
            await channel.SendMessageAsync($"Welcome, {user.Mention}!\nSet your nickname to your in-game name!");
        }
    }
}
