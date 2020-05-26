using Discord;
using Discord.Commands;
using Discord.WebSocket;
using FortBot2.Config.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ApiHandler = FortBot2.Config.ApiHandler;


namespace FortBot2.Modules
{
    public class FNItemShop : ModuleBase<SocketCommandContext>
    {
        [Command("shop")]
        [Summary("Retrieves the current items in the Fortnite item shop.")]
        public async Task GetShopAsync()
        {
            string url = "https://fortnite-api.theapinetwork.com/store/get";

            // Set up http client
            HttpClient _httpClient = new HttpClient();
            _httpClient = ApiHandler.InitClient();

            string json;
            HttpResponseMessage res = await _httpClient.GetAsync(url);
            json = res.Content.ReadAsStringAsync().Result;
           
            Rootobject shop = JsonConvert.DeserializeObject<Rootobject>(json);

            for (int i = 0; i < shop.data.Length; i++)
            {
                var embed = new EmbedBuilder();
                embed.WithTitle(shop.data[i].item.name)
                    .AddField("VBucks", shop.data[i].store.cost)
                    .WithDescription(shop.data[i].item.description)
                    .WithColor(Color.Magenta)
                    .ThumbnailUrl = shop.data[i].item.images.icon;
                await Context.Channel.SendMessageAsync(embed: embed.Build());

            }
        }
    }
}
