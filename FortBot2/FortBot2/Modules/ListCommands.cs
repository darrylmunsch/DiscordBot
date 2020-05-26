using Discord.Commands;
using Discord;
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
        [Command("help")]
        [Summary("Lists all available commands.")]
        public async Task ListCommandsAsync()
        {
            //var embed = new EmbedBuilder();
            //embed.WithTitle("[!lookup]")
            //    .AddField("Looks up stats of a specified Fortnite Player.","Example: !lookup \"Ninja\" pc")
            //    .WithTitle("[!shop]")
            //    .AddField("Displays Fortnite's daily item shop.", "Example: !shop")
            //    .WithTitle("!meme")
            //    .AddField("Posts a meme related to the search criteria.", "Example: !meme \"Donald Trump\"");

            string commands = 
               "All Commands:\n" +
                "\n**[!lookup]**\nLooks up stats of a specified Fortnite Player.\n" +
                "Type a fortnite name to look up in parenthesis followed by the platform they play on.\n" +
                "*Example:*\t!lookup \"Ninja\" pc\n" +
                "\n**[!whois]**\nGives Discord user information based on the user specified.\n" +
                "*Example:*\t!whois Rice\n" +
                "\n**[!meme]**\nResponds with a random gif meme based on search term.\n" +
                "*Example:*\t!meme \"Donald Trump\"\n" +
                "\n**[!shop]**\nRetrieves current fortnite item shop.\n" +  
                "\n**[!youtube]**\nSearch for a specific youtube video.\n" +
                "*Example:*\t!youtube grumbae\n" +
                "\n**[!RandomClip]**\tComing Soon..\n" +
                "\n**[!TrendingClip]**\tComing Soon..\n" +
                "\n**[!FortniteNews]**\tComing Soon..\n" +
                "\n**[!Competitive]**\tComing Soon..\n";

            await ReplyAsync(commands);
        }
    }
}
