using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TesteAvalAPI.Models;

namespace TesteAvalAPI.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly HttpClient _httpClient;
        
        public PessoaService()
        {
            _httpClient = new HttpClient();

        }
        public async Task<List<Pessoa>> GetPessoas() // get
        {
            var result = await _httpClient.GetStringAsync("https://localhost:44381/api/pessoas");
            return JsonConvert.DeserializeObject<List<Pessoa>>(result);
        }
        public async Task<Pessoa> GetPessoa(int id) // getById
        {
            var result = await _httpClient.GetStringAsync("https://localhost:44381/api/pessoas/" + id);
            return JsonConvert.DeserializeObject<Pessoa>(result);
        }
        public async void AddPessoa(Pessoa item) // create
        {
            var pessoaJson = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("https://localhost:44381/api/pessoas", pessoaJson);
        }

        public async void DeletePessoa(int id) // delete
        {
            await _httpClient.DeleteAsync("https://localhost:44381/api/pessoas/" + id);
        }
        public async Task<bool> PessoaExists(int id)
        {
            var result = await _httpClient.GetAsync("https://localhost:44381/api/pessoas/" + id);
            return result.IsSuccessStatusCode;
        }

        public async void UpdatePessoa(Pessoa item) // Update
        {
            var pessoaJson = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync("https://localhost:44381/api/pessoas", pessoaJson);
        }
    }
}
