using System.Linq;
using System.Threading.Tasks;
using CRUDPessoa.Core.DominioBase;
using CRUDPessoa.Core.Mensagens.Eventos;

namespace CRUDPessoa.Cadastros.Infra.Contextos
{
    public static class MediatorExtensao
    {
        public static async Task PublicarEventos(this IMediatorManipulador mediator, CadastrosContexto contexto)
        {
            var dominioEntidades = contexto.ChangeTracker.Entries<Entidade>()
                .Where(x => x.Entity.Eventos != null && x.Entity.Eventos.Any()).ToList();

            var dominioEventos = dominioEntidades.SelectMany(x => x.Entity.Eventos).ToList();

            dominioEntidades.ForEach(entidade => entidade.Entity.LimparEventos());

            var tarefas = dominioEventos.Select(async (dominioEvento) =>
            {
                await mediator.PublicarEvento(dominioEvento);
            });

            await Task.WhenAll(tarefas);
        }
    }
}
