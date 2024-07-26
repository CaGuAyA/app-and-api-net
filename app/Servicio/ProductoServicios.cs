using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using app.Modelo;

namespace app.Servicio
{
    internal class ProductoServicios
    {
        private readonly HttpClient _client;

        public ProductoServicios()
        {
            _client = new HttpClient { BaseAddress = new Uri("https://localhost:7028/api/ProductoControlador/") };
        }

        public async Task<List<Producto>> GetProductsAsync()
        {
            var response = await _client.GetAsync("");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Producto>>(content);
        }

        public async Task<Producto> GetProductAsync(int id)
        {
            var response = await _client.GetAsync($"{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Producto>(content);
        }

        public async Task<Producto> CreateProductAsync(Producto product)
        {
            var content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("", content);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<Producto>(await response.Content.ReadAsStringAsync());
        }

        public async Task UpdateProductAsync(int id, Producto product)
        {
            var content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"{id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProductAsync(int id)
        {
            var response = await _client.DeleteAsync($"{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
