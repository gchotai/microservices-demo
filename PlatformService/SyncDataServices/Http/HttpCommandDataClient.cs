﻿using PlatformService.Dtos;
using System.Text;
using System.Text.Json;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task SendPlatformToCommand(PlatformReadDto plat)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(plat),
                Encoding.UTF8,
                "application/json");
            var responce = await _httpClient.PostAsync($"{_configuration["CommandService"]}/api/c/Platform/", httpContent);
            if (responce.IsSuccessStatusCode)
                Console.WriteLine("--> Sync POST to Command Service was OK!");
            else
                Console.WriteLine("--> Sync POST to Command Service was not OK!");
        }
    }
}
