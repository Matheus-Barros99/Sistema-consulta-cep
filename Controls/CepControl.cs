using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using TesteCandidato1.Context;
using TesteCandidato1.Models.DTOs;

namespace TesteCandidato1.Controls
{
    public class CepControl
    {
        private readonly CepContext _contexto;

        public CepControl(CepContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<Models.Cep?> PersistirCep(CepDTO dadosCep)
        {
            try
            {
                Models.Cep cep = new Models.Cep
                {
                    Cep1 = dadosCep.Cep.Replace("-", ""),
                    Logradouro = dadosCep.Logradouro,
                    Complemento = dadosCep.Complemento,
                    Bairro = dadosCep.Bairro,
                    Localidade = dadosCep.Localidade,
                    Uf = dadosCep.UFStr,
                    Unidade = dadosCep.Unidade != "" ? long.Parse(dadosCep.Unidade) : 0,
                    Ibge = int.Parse(dadosCep.Ibge),
                    Gia = dadosCep.Gia
                };

                await _contexto.Ceps.AddAsync(cep);
                await _contexto.SaveChangesAsync();

                _contexto.Entry(cep).State = EntityState.Detached;

                return cep;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar CEP: {ex.Message}");

                throw;
            }
        }
    }
}
