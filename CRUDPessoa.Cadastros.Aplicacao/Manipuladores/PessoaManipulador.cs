using System.Threading.Tasks;
using CRUDPessoa.Cadastros.Aplicacao.Comandos.PessoaComandos;
using CRUDPessoa.Cadastros.Dominio.Entidades;
using CRUDPessoa.Cadastros.Dominio.Entidades.ObjetosDeValor;
using CRUDPessoa.Cadastros.Dominio.Repositorios;
using CRUDPessoa.Core.Mensagens.Comandos;
using Flunt.Notifications;

namespace CRUDPessoa.Cadastros.Aplicacao.Manipuladores
{
    public class PessoaManipulador : Notifiable,
        IManipulador<CriarPessoaComando>,
        IManipulador<AtualizarPessoaComando>,
        IManipulador<DeletarPessoaComando>
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public PessoaManipulador(IPessoaRepositorio pessoaRepositorio) => _pessoaRepositorio = pessoaRepositorio;

        public async Task<IComandoResultado> Manipular(CriarPessoaComando comando)
        {
            comando.Validar();

            if (comando.Invalid)
                return new ComandoResultado(false, "Ocorreu um erro ao criar pessoa", comando.Notifications);

            var pessoa = new Pessoa(comando.Nome, comando.Email, new Documento(comando.NumeroDocumento));

            _pessoaRepositorio.Criar(pessoa);

            await _pessoaRepositorio.UnidadeDeTrabalho.Commit();

            return new ComandoResultado(true, "Pessoa criada com sucesso", pessoa);
        }

        public async Task<IComandoResultado> Manipular(DeletarPessoaComando comando)
        {
            comando.Validar();

            if (comando.Invalid)
                return new ComandoResultado(false, "Ocorreu um erro ao deletar pessoa", comando.Notifications);

            var pessoa = await _pessoaRepositorio.ObterPorId(comando.Id);

            if(pessoa is null)
                return new ComandoResultado(false, "Pessoa não encontrada", null);

            _pessoaRepositorio.Deletar(pessoa);
            await _pessoaRepositorio.UnidadeDeTrabalho.Commit();

            return new ComandoResultado(true, "Pessoa deletada com sucesso", pessoa);
        }

        public async Task<IComandoResultado> Manipular(AtualizarPessoaComando comando)
        {
            comando.Validar();

            if (comando.Invalid)
                return new ComandoResultado(false, "Ocorreu um erro ao atualizar pessoa", comando.Notifications);

            var pessoa = await _pessoaRepositorio.ObterPorId(comando.Id);

            if (pessoa is null)
                return new ComandoResultado(false, "Pessoa não encontrada", null);

            pessoa.Atualizar(comando.Nome, comando.Email, new Documento(comando.NumeroDocumento));

            _pessoaRepositorio.Atualizar(pessoa);
            await _pessoaRepositorio.UnidadeDeTrabalho.Commit();

            return new ComandoResultado(true, "Pessoa atualizada com sucesso", pessoa);
        }
    }
}
