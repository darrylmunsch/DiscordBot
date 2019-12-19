using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace FortBot2.Modules
{
    // Module with no prefix
    public class NoPrefixModule : ModuleBase<SocketCommandContext>
    {
        // ~echo back what i say
        [Command("echo")]
        [Summary("Repeats what you say.")]
        public Task SayAsync([Remainder] [Summary("The text to echo")] string echo)
            => ReplyAsync(echo);
        // replyAsync is a method on ModuleBase

        [Command("userinfo")]
        [Summary("Returns info about the current user, or the user specified.")]
        [Alias("user", "whois")]
        public async Task UserInfoAsync([Summary("The (optional) user to get info from.")] SocketUser user = null)
        {
            var userInfo = user ?? Context.Client.CurrentUser;
            await ReplyAsync($"{userInfo.Username}#{userInfo.Discriminator}");
        }
    }
}
