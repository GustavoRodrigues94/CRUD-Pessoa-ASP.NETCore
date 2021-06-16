using System;

namespace CRUDPessoa.Cadastros.Aplicacao.Consultas.ViewModels
{
    public class PessoaViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string TipoPessoa { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nome { get; set; }
    }
}
