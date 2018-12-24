using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NumberOne.API.Models;
using Web.BFF.Config;

namespace Web.BFF.Services
{
    public class NumberOne : INumberOne
    {
        private readonly HttpClient _apiClient;
        private readonly UrlsConfig _urls;

        public NumberOne(HttpClient httpClient,  IOptions<UrlsConfig> config)
        {
            _apiClient = httpClient;
            _urls = config.Value;
        }

        public Task<UserData> AddUser(UserData user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserData>> GetAll()
        {
            string url = "https://localhost:44316/api/v1/userdata";
            var content = await _apiClient.GetStringAsync(url);
            var userData = JsonConvert.DeserializeObject<UserData[]>(content);

            return userData;
        }
    }
}
