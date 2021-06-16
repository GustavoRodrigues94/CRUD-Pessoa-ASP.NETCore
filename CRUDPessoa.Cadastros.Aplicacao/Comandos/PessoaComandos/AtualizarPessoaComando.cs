using System;
using CRUDPessoa.Core.Mensagens.Comandos;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;

namespace CRUDPessoa.Cadastros.Aplicacao.Comandos.PessoaComandos
{
    public class AtualizarPessoaComando : Notifiable, IComando
    {
        public AtualizarPessoaComando(Guid id, string nome, string email, string numeroDocumento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            NumeroDocumento = numeroDocumento;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string NumeroDocumento { get; private set; }

        public void Validar() => AddNotifications(new Contract()
            .IsNotEmpty(Id, "IdPessoa", "Por favor, informe o IdPessoa")
            .IsNotNullOrWhiteSpace(Nome, "Nome", "Por favor, informe um nome")
            .IsEmailOrEmpty(Email, "Email", "Por favor, informe um email válido")
            .IsCnpjOrCPF(NumeroDocumento, "NumeroDocumento", "Por favor, informe um documento válido")
        );
    }
}
