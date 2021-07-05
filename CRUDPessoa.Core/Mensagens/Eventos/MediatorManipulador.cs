using System.Threading.Tasks;
using MediatR;

namespace CRUDPessoa.Core.Mensagens.Eventos
{
    public class MediatorManipulador : IMediatorManipulador
    {
        private readonly IMediator _mediator;

        public MediatorManipulador(IMediator mediator) => _mediator = mediator;

        public async Task PublicarEvento<T>(T evento) where T : Evento
        {
            await _mediator.Publish(evento);
        }
    }
}
