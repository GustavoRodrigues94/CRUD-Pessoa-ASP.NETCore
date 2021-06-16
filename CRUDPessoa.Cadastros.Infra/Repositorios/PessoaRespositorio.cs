using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRUDPessoa.Cadastros.Dominio.Entidades;
using CRUDPessoa.Cadastros.Dominio.Repositorios;
using CRUDPessoa.Cadastros.Infra.Contextos;
using CRUDPessoa.Core.RepositorioBase;
using Microsoft.EntityFrameworkCore;

namespace CRUDPessoa.Cadastros.Infra.Repositorios
{
    public class PessoaRespositorio : IPessoaRepositorio
    {
        private readonly CadastrosContexto _contexto;
        public IUnidadeDeTrabalho UnidadeDeTrabalho => _contexto;

        public PessoaRespositorio(CadastrosContexto contexto)
        {
            _contexto = contexto;
        }

        public void Criar(Pessoa pessoa) => _contexto.Pessoas.Add(pessoa);

        public void Atualizar(Pessoa pessoa) => _contexto.Pessoas.Update(pessoa);

        public void Deletar(Pessoa pessoa) => _contexto.Pessoas.Remove(pessoa);

        public async Task<Pessoa> ObterPorId(Guid idPessoa) => await _contexto.Pessoas
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(p => p.Id == idPessoa);

        public async Task<IEnumerable<Pessoa>> ObterTodos() => await _contexto.Pessoas
            .AsNoTrackingWithIdentityResolution()
            .ToListAsync();

        public void Dispose() => _contexto?.Dispose();
    }
}
