using System;

namespace TestsEFCore.Tests.Entities;

public class Departamento
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCadastro { get; set; }
}