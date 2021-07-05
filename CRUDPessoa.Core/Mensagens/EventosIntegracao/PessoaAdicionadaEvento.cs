using System;

namespace CRUDPessoa.Core.Mensagens.EventosIntegracao
{
    public class PessoaAdicionadaEvento : EventoIntegracao
    {
        public Guid PessoaId { get; private set; }

        public string Email { get; private set; }

        public PessoaAdicionadaEvento(Guid pessoaId, string email)
        {
            PessoaId = pessoaId;
            Email = email;
        }
    }
}
