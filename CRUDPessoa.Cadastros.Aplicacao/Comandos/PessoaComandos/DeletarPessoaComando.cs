using System;
using CRUDPessoa.Core.Mensagens.Comandos;
using Flunt.Notifications;
using Flunt.Validations;

namespace CRUDPessoa.Cadastros.Aplicacao.Comandos.PessoaComandos
{
    public class DeletarPessoaComando : Notifiable, IComando
    {
        public DeletarPessoaComando(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }

        public void Validar() => AddNotifications(new Contract()
            .IsNotEmpty(Id, "IdPessoa", "Por favor, informe o IdPessoa")
        );
    }
}
