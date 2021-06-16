using System.Threading.Tasks;
using CRUDPessoa.Cadastros.Dominio.Entidades;
using CRUDPessoa.Core.RepositorioBase;
using Microsoft.EntityFrameworkCore;

namespace CRUDPessoa.Cadastros.Infra.Contextos
{
    public class CadastrosContexto : DbContext, IUnidadeDeTrabalho
    {
        public CadastrosContexto(DbContextOptions opcoes) : base(opcoes) { }

        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CadastrosContexto).Assembly);
        }

        public async Task<bool> Commit() => await base.SaveChangesAsync() > 0;
    }
}
