using System.Threading.Tasks;

namespace CRUDPessoa.Core.RepositorioBase
{
    public interface IUnidadeDeTrabalho
    {
        Task<bool> Commit();
    }
}
