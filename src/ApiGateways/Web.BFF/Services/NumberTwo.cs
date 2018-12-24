using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using NumberOne.API.Models;
using NumberTwo.API.Models;
using Web.BFF.Config;

namespace Web.BFF.Services
{
    public class NumberTwo : INumberTwo
    {
        private readonly HttpClient _apiClient;
        private readonly UrlsConfig _urls;

        public NumberTwo(HttpClient httpClient,  IOptions<UrlsConfig> config)
        {
            _apiClient = httpClient;
            _urls = config.Value;
        }

        public Task<UsersImages> AddUserImage(UsersImages userImage)
        {
            throw new NotImplementedException();
        }

        public Task<UsersImages> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
