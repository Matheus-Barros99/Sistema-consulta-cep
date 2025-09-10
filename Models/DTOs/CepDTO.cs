using System.Text.Json.Serialization;
using System;

namespace TesteCandidato1.Models.DTOs
{
    public class CepDTO
    {
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Unidade { get; set; }
        public string? Bairro { get; set; }
        public string? Localidade { get; set; }

        [JsonPropertyName("uf")]
        public string? UFStr { get; set; }

        public string? Estado { get; set; }

        public string? Regiao { get; set; }
        public string? Ibge { get; set; }
        public string? Gia { get; set; }
        public string? Ddd { get; set; }
        public string? Siafi { get; set; }
    }
}
