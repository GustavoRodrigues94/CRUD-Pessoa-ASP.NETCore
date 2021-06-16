using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRUDPessoa.Cadastros.Dominio.Entidades;
using CRUDPessoa.Core.RepositorioBase;

namespace CRUDPessoa.Cadastros.Dominio.Repositorios
{
    public interface IPessoaRepositorio : IRepositorio<Pessoa>
    {
        void Criar(Pessoa pessoa);
        void Atualizar(Pessoa pessoa);
        void Deletar(Pessoa pessoa);

        Task<Pessoa> ObterPorId(Guid idPessoa);
        Task<IEnumerable<Pessoa>> ObterTodos();
    }
}
