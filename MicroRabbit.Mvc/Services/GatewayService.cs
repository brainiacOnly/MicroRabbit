using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MicroRabbit.Mvc.Models.Dto;
using Newtonsoft.Json;

namespace MicroRabbit.Mvc.Services
{
    public class GatewayService : IGatewayService
    {
        private readonly HttpClient apiClient;
        //private readonly IHttpClientFactory clientFactory;

        
        public GatewayService(HttpClient apiClient)
        {
            this.apiClient = apiClient;
        }
        
        /*
        public GatewayService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }
        */
        
        public async Task Transfer(TransferDto dto)
        {
            var uri = "http://localhost:5000/api/Banking";
            var transferContent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await apiClient.PostAsync(uri, transferContent);
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<TransferLogDto>> GetLogs()
        {
            var uri = "http://localhost:5002/api/Transfer";
            var response = await apiClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var stringData = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<TransferLogDto>>(stringData);
            return data;
        }
    }
}