using Discord.Commands;
using Discord.WebSocket;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FortBot2.Modules
{
    public class ListCommands : ModuleBase<SocketCommandContext>
    {
        [Command("commands")]
        [Summary("Lists all available commands.")]
        public async Task ListCommandsAsync()
        {
            string commands = 
                "All Commands:\n" +
                "\n**[!lookup]**\nLooks up stats of a specified Fortnite Player.\n" +
                "Type a fortnite name to look up in parenthesis followed by the platform they play on.\n" +
                "*Example:*\t!lookup \"Ninja\" pc\n" +
                "\n**[!whois]**Gives user information based on the user specified.\n" +
                "*Example:*\t!whois Rice\n" +
                "\n**[!meme]**\tComing Soon..\n" +
                "\n**[!itemshop]**\tComing Soon..\n" +
                "\n**[!RandomClip]**\tComing Soon..\n" +
                "\n**[!TrendingClip]**\tComing Soon..\n" +
                "\n**[!FortniteNews]**\tComing Soon..\n" +
                "\n**[!Competitive]**\tComing Soon..\n";

            await ReplyAsync(commands);
        }
    }
}
