using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRUDPessoa.Cadastros.Aplicacao.Consultas.ViewModels;


namespace CRUDPessoa.Cadastros.Aplicacao.Consultas
{
    public interface IPessoaConsultas
    {
        Task<IEnumerable<PessoaViewModel>> ObterTodos();
        Task<PessoaViewModel> ObterPorId(Guid idPessoa);
    }
}
