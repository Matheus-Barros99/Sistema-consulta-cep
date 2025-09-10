using System;
using System.Collections.Generic;

namespace TesteCandidato1.Models;

public partial class Cep
{
    public int Id { get; set; }

    public string? Cep1 { get; set; }

    public string? Logradouro { get; set; }

    public string? Complemento { get; set; }

    public string? Bairro { get; set; }

    public string? Localidade { get; set; }

    public string? Uf { get; set; }

    public long? Unidade { get; set; }

    public int? Ibge { get; set; }

    public string? Gia { get; set; }
}
