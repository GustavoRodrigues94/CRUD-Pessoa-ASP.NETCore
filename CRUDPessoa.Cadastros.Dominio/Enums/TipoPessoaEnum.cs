using System.ComponentModel;

namespace CRUDPessoa.Cadastros.Dominio.Enums
{
    public enum TipoPessoaEnum
    {
        [Description("Pessoa física")] Fisica,
        [Description("Pessoa jurídica")] Juridica,
        [Description("Indefinido")] Indefinido
    }
}
