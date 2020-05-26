using Discord.Commands;
using FortBot2.Config;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FortBot2.Modules
{
    public class GifLookup : ModuleBase<SocketCommandContext>
    {
        [Command("meme")]
        [Summary("Grab a random GIF based on search.")]
        public async Task GetMemeAsync([Remainder][Summary("Search terms")]string args)
        {

            // Initialize variables
            string url, json, query;

            //api key 	2HLXH8I1JZAM

            // Set up variables
            query = args;
            url = $"https://api.tenor.com/v1/search?q={query}&key=2HLXH8I1JZAM&limit=1&media_filter=minimal";
            
            // Set up http client
            HttpClient _httpClient = new HttpClient();
            _httpClient = ApiHandler.InitClient();
            HttpResponseMessage res = await _httpClient.GetAsync(url);

            // Create string from json response
            json = res.Content.ReadAsStringAsync().Result;

            // Create JObject from result and get url string
            JObject gifResults = JObject.Parse(json);
            string gifUrl = gifResults["results"][0]["url"].ToString();

            // Post Gif in channel via bot
            await Context.Channel.SendMessageAsync(gifUrl);
        }
    }
}
