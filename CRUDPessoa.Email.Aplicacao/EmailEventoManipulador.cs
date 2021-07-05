using System.Threading;
using System.Threading.Tasks;
using CRUDPessoa.Core.Mensagens.EventosIntegracao;
using MediatR;

namespace CRUDPessoa.Email.Aplicacao
{
    public class EmailEventoManipulador : INotificationHandler<PessoaAdicionadaEvento>
    {
        public async Task Handle(PessoaAdicionadaEvento notification, CancellationToken cancellationToken)
        {
            //TODO ENVIAR EMAIL DE BOAS VINDAS SEMPRE QUE UMA PESSOA FOR ADICIONADA

            await Task.CompletedTask;
        }
    }
}
