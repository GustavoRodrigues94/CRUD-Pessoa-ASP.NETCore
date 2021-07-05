using System.Threading.Tasks;
using CRUDPessoa.Cadastros.Dominio.Entidades;
using CRUDPessoa.Core.Mensagens.Eventos;
using CRUDPessoa.Core.RepositorioBase;
using Microsoft.EntityFrameworkCore;

namespace CRUDPessoa.Cadastros.Infra.Contextos
{
    public class CadastrosContexto : DbContext, IUnidadeDeTrabalho
    {
        private readonly IMediatorManipulador _mediatorManipulador;

        public CadastrosContexto(DbContextOptions opcoes, IMediatorManipulador mediatorManipulador) : base(opcoes)
        {
            _mediatorManipulador = mediatorManipulador;
        }

        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<Evento>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CadastrosContexto).Assembly);
        }

        public async Task<bool> Commit()
        {
            var sucesso = await base.SaveChangesAsync() > 0;
            if (sucesso) await _mediatorManipulador.PublicarEventos(this);

            return sucesso;
        }
    }
}
