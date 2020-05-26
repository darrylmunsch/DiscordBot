using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using ApiHandler = FortBot2.Config.ApiHandler;
using static FortBot2.Config.Models.YTVideoDTO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FortBot2.Modules
{
    public class YouTubeLookup : ModuleBase<SocketCommandContext>
    {


        //https://www.youtube.com/watch?v=
        [Command("youtube")]
        [Summary("Search youtube")]
        public async Task GetVideoAsync([Remainder][Summary("Query")] string args)
        {
            Console.WriteLine(args);

            string key = "AIzaSyABeXIVpaTxdoZMKySRAxyyFMpKhgToHo0";
            string query = args.Replace(" ", "%20");
            Console.WriteLine("query term: " + query);
            string apiUrl = 
                $"https://www.googleapis.com/youtube/v3/search?part=snippet&q={query}&key={key}";
            // replace whitespace in query with '%20'

            // Set up http Client
            HttpClient _httpClient = new HttpClient();
            _httpClient = ApiHandler.InitClient();
            HttpResponseMessage res = await _httpClient.GetAsync(apiUrl);

            // Create string from json response
            string json = res.Content.ReadAsStringAsync().Result;


            // Create results object from json (str) results
            Rootobject results = JsonConvert.DeserializeObject<Rootobject>(json);

            // Create Video object from first (most relevant) result
            Item Video = new Item();
            Video = Array.Find(results.items, f => f.id.kind == "youtube#video");

            var embed = new EmbedBuilder();
            embed.WithTitle(Video.snippet.title)
                .AddField("Channel", Video.snippet.channelTitle)
                .WithDescription(Video.snippet.description)
                .WithColor(Color.DarkTeal)
                .WithUrl($"https://www.youtube.com/watch?v={Video.id.videoId}")
                .WithImageUrl(Video.snippet.thumbnails.high.url);

            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }


    }
}
