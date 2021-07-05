using System.Threading.Tasks;

namespace CRUDPessoa.Core.Mensagens.Eventos
{
    public interface IMediatorManipulador
    {
        Task PublicarEvento<T>(T evento) where T : Evento;
    }
}
