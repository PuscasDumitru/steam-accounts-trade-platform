using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        readonly HttpClient _httpClient;
        public GameController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IEnumerable<object>> GetAllGames()
        {
            var response = await _httpClient.GetAsync("https://api.steampowered.com/IPlayerService/GetOwnedGames/v1/?key=56BCB7894CB0F62A35F2E142C9DCE54D&steamid=76561198089935196&include_appinfo=true&include_played_free_games=true");
            var apiRes = await response.Content.ReadAsStringAsync();


            JObject obj = JObject.Parse(apiRes);

            var qry = //obj["response"]["games"].Select(res => new { name = res["name"], playtime_forever = res["playtime_forever"] }).ToList();

                from p in obj["response"]["games"]
                select new
                {
                    name = (string)p["name"],
                    playtime_forever = (int)p["playtime_forever"]
                };

            return qry;
        }

        [HttpGet("User/{id}")]
        public async Task<IEnumerable<object>> GetUserGames(string id)
        {
            var response = await _httpClient.GetAsync(
                $"https://api.steampowered.com/IPlayerService/GetOwnedGames/v1/?key=56BCB7894CB0F62A35F2E142C9DCE54D&steamid=" +
                $"{id}" +
                $"&include_appinfo=true&include_played_free_games=true" 
                );
            
            var apiRes = await response.Content.ReadAsStringAsync();
            
            JObject obj = JObject.Parse(apiRes);

            var qry = //obj["response"]["games"].Select(res => new { name = res["name"], playtime_forever = res["playtime_forever"] }).ToList();

                from p in obj["response"]["games"]
                select new
                {
                    name = (string)p["name"],
                    playtime_forever = (int)p["playtime_forever"]
                };

            return qry;
        }

    }
}
