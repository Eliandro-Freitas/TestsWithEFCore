using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using TestsEFCore.Tests.Entities;
using TestsEFCore.Tests.Infra;
using Xunit;

namespace TestsEFCore.Tests;

public class InMemoryTests
{
    private readonly ApplicationContext _context;

    public InMemoryTests()
        => _context = CreateContext();

    [Fact]
    public void ShouldAddDepartamentInMemoryDataBase()
    {
        var departamentos = new Departamento
        {
            Descricao = "Tecnologia",
            DataCadastro = DateTime.Now
        };

        _context.Departamentos.Add(departamentos);
        var inseridos = _context.SaveChanges();

        Assert.Equal(1, inseridos);
    }

    private ApplicationContext CreateContext()
    {
        var connection = new SqliteConnection("Datasource=:memory:");
        connection.Open();
        var options = new DbContextOptionsBuilder<ApplicationContext>()
            .UseSqlite(connection)
            .Options;

        var context =  new ApplicationContext(options);
        context.Database.EnsureCreated();
        return context; 
    }
}