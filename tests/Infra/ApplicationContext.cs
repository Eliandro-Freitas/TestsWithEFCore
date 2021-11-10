using Microsoft.EntityFrameworkCore;
using TestsEFCore.Tests.Entities;

namespace TestsEFCore.Tests.Infra;
public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    public DbSet<Departamento> Departamentos { get; set; }
}