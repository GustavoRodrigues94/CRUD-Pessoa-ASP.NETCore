using System;
using CRUDPessoa.Core.DominioBase;

namespace CRUDPessoa.Core.RepositorioBase
{
    public interface IRepositorio<T> : IDisposable where T : IRaizAgregacao 
    {
        IUnidadeDeTrabalho UnidadeDeTrabalho { get; }
    }
}
