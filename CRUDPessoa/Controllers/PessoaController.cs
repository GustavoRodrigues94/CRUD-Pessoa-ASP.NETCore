using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRUDPessoa.Cadastros.Aplicacao.Comandos.PessoaComandos;
using CRUDPessoa.Cadastros.Aplicacao.Consultas;
using CRUDPessoa.Cadastros.Aplicacao.Consultas.ViewModels;
using CRUDPessoa.Cadastros.Aplicacao.Manipuladores;
using CRUDPessoa.Core.Mensagens.Comandos;
using Microsoft.AspNetCore.Mvc;

namespace CRUDPessoa.Controllers
{
    [ApiController]
    [Route("v1/Pessoa")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaConsultas _pessoaConsultas;

        public PessoaController(IPessoaConsultas pessoaConsultas) => _pessoaConsultas = pessoaConsultas;

        [Route("")]
        [HttpPost]
        public async Task<ActionResult<ComandoResultado>> CriarPessoa(
            [FromBody] CriarPessoaComando comando,
            [FromServices] PessoaComandoManipulador manipulador) =>
            (ComandoResultado) await manipulador.Manipular(comando);

        [Route("{idPessoa}")]
        [HttpDelete]
        public async Task<ActionResult<ComandoResultado>> DeletarPessoa(
            [FromServices] PessoaComandoManipulador manipulador, Guid idPessoa) =>
            (ComandoResultado) await manipulador.Manipular(new DeletarPessoaComando(idPessoa));

        [Route("")]
        [HttpPut]
        public async Task<ActionResult<ComandoResultado>> AtualizarPessoa(
            [FromBody] AtualizarPessoaComando comando,
            [FromServices] PessoaComandoManipulador manipulador) =>
            (ComandoResultado)await manipulador.Manipular(comando);

        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<PessoaViewModel>> ObterTodos() => await _pessoaConsultas.ObterTodos();

        [Route("{idPessoa}")]
        [HttpGet]
        public async Task<PessoaViewModel> ObterPorId(Guid idPessoa) => await _pessoaConsultas.ObterPorId(idPessoa);
    }
}
