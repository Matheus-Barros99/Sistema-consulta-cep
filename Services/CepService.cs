using System.Text.Json;
using TesteCandidato1.Models.DTOs;

namespace TesteCandidato1.Services
{
    public class CepService
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly JsonSerializerOptions _serializerOptions;
        private readonly string _urlCatus = "https://viacep.com.br/ws/";

        public async Task<CepDTO?> RecuperarDadosCep(string cep)
        {
            CepDTO cepInfo = new CepDTO();

            // Verifica se o CEP é nulo ou vazio
            if (String.IsNullOrEmpty(cep))
            {
                return null;
            }

            _client.Timeout = TimeSpan.FromMinutes(1);
            Uri uri = new Uri(string.Format(_urlCatus + cep + "/json/", string.Empty));

            try
            {
                HttpRequestMessage mensagem = new HttpRequestMessage(HttpMethod.Get, uri);

                HttpResponseMessage resposta = await _client.SendAsync(mensagem);

                if (resposta.IsSuccessStatusCode)
                {
                    string content = resposta.Content.ReadAsStringAsync().Result;
                    cepInfo = JsonSerializer.Deserialize<CepDTO>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return cepInfo;
        }
    }
}
