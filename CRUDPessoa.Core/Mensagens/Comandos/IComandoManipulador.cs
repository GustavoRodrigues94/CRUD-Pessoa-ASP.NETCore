using System.Threading.Tasks;

namespace CRUDPessoa.Core.Mensagens.Comandos
{
    public interface IComandoManipulador<in T> where T : IComando
    {
        Task<IComandoResultado> Manipular(T comando);
    }
}
