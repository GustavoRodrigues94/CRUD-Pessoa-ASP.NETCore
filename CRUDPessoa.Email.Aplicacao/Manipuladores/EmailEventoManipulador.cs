using System.Threading;
using System.Threading.Tasks;
using CRUDPessoa.Core.Mensagens.EventosIntegracao;
using MediatR;

namespace CRUDPessoa.Email.Aplicacao.Manipuladores
{
    public class EmailEventoManipulador : INotificationHandler<PessoaAdicionadaEvento>
    {
        public Task Handle(PessoaAdicionadaEvento pessoaAdicionadaEvento, CancellationToken cancellationToken)
        {
            //TODO ENVIAR EMAIL DE BOAS VINDAS PARA PESSOA ADICIONADA;

            return Task.CompletedTask;
        }
    }
}