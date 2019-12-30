using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ApiHandler = FortBot2.Config.ApiHandler;
using FNStatsDTO = FortBot2.Config.Models.FNStatsDTO;

namespace FortBot2.Modules
{
    public class FNLookup : ModuleBase<SocketCommandContext>
    {
        [Command("lookup")]
        [Summary("Looks up Fortnite Stats of specified fortnite name")]
        public async Task GetStatsAsync([Remainder][Summary("Platform/User")] string args)
        {
            ////////
            Console.WriteLine(args);
            
            string platform = args.Split('"')[2].TrimStart();
            string user = args.Split('"')[1];
            string url = $"https://api.fortnitetracker.com/v1/profile/{platform}/{user}";
            string json;

            Console.WriteLine("User: " + user);
            Console.WriteLine("Platform: " + platform);

            Console.WriteLine("Retrieving Stats from API...");
            HttpClient _httpClient = new HttpClient();
            _httpClient = ApiHandler.InitClient();
            HttpResponseMessage res = await _httpClient.GetAsync(url);
            json = res.Content.ReadAsStringAsync().Result;

            JObject apiResults = JObject.Parse(json);
            JToken kills = apiResults["lifeTimeStats"][10]["value"];
            JToken wins = apiResults["lifeTimeStats"][8]["value"];
            JToken kd = apiResults["lifeTimeStats"][11]["value"];
            JToken winP = apiResults["lifeTimeStats"][9]["value"];

            FNStatsDTO stats = new FNStatsDTO();
            stats.kills = kills.ToObject<double>();
            stats.wins = wins.ToObject<double>();
            stats.kd = kd.ToObject<double>();
            stats.winP = winP.ToObject<string>();
            string _user = Regex.Replace(user, "[(/)]", "");

            var embed = new EmbedBuilder();
            embed.WithTitle(_user + "'s Lifetime Stats:")
                .AddField("Total Kills", stats.kills)
                .AddField("Total Wins", stats.wins)
                .AddField("Kill/Death Ratio", stats.kd)
                .AddField("Win Percentage", stats.winP)
                .WithColor(Color.Magenta);
            
            Console.WriteLine($"Stats Fetched..");
            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }
    }
}
