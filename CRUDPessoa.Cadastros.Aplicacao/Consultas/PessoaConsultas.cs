using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDPessoa.Cadastros.Aplicacao.Consultas.ViewModels;
using CRUDPessoa.Cadastros.Dominio.Repositorios;

namespace CRUDPessoa.Cadastros.Aplicacao.Consultas
{
    public class PessoaConsultas : IPessoaConsultas
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public PessoaConsultas(IPessoaRepositorio pessoaRepositorio) => _pessoaRepositorio = pessoaRepositorio;

        public async Task<IEnumerable<PessoaViewModel>> ObterTodos()
        {
            var pessoas = await _pessoaRepositorio.ObterTodos();

            var listaPessoas = pessoas?.Select(pessoa => new PessoaViewModel
            {
                Id = pessoa.Id,
                Email = pessoa.Email,
                Nome = pessoa.Nome,
                NumeroDocumento = pessoa.Documento.NumeroDocumento,
                TipoPessoa = pessoa.Documento.TipoPessoa.ToString()
            }).ToList();

            return listaPessoas;
        }

        public async Task<PessoaViewModel> ObterPorId(Guid idPessoa)
        {
            var pessoa = await _pessoaRepositorio.ObterPorId(idPessoa);

            return new PessoaViewModel
            {
                Id = pessoa.Id,
                Email = pessoa.Email,
                Nome = pessoa.Nome,
                NumeroDocumento = pessoa.Documento.NumeroDocumento
            };
        }
    }
}
