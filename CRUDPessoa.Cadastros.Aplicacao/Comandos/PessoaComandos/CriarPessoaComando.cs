using CRUDPessoa.Core.Mensagens.Comandos;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;

namespace CRUDPessoa.Cadastros.Aplicacao.Comandos.PessoaComandos
{
    public class CriarPessoaComando : Notifiable, IComando
    {
        public CriarPessoaComando(string nome, string email, string numeroDocumento)
        {
            Nome = nome;
            Email = email;
            NumeroDocumento = numeroDocumento;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string NumeroDocumento { get; private set; }

        public void Validar() => AddNotifications(new Contract()
            .IsNotNullOrWhiteSpace(Nome, "Nome", "Por favor, informe um nome")
            .IsEmailOrEmpty(Email, "Email", "Por favor, informe um email válido")
            .IsCnpjOrCPF(NumeroDocumento, "NumeroDocumento", "Por favor, informe um documento válido")
        );
    }
}
