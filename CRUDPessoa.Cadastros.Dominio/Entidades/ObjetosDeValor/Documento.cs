using CRUDPessoa.Cadastros.Dominio.Enums;

namespace CRUDPessoa.Cadastros.Dominio.Entidades.ObjetosDeValor
{
    public class Documento
    {
        public Documento(string numeroDocumento)
        {
            NumeroDocumento = numeroDocumento;
            DefinirTipoDePessoa(numeroDocumento);
        }

        public string NumeroDocumento { get; private set; }
        public TipoPessoaEnum TipoPessoa {get; private set; }

        private void DefinirTipoDePessoa(string numeroDocumento) => TipoPessoa =
            numeroDocumento.Length == 11 ? TipoPessoaEnum.Fisica : TipoPessoaEnum.Juridica;
    }
}
