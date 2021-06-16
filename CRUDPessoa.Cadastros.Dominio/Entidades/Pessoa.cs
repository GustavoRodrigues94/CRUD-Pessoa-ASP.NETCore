using CRUDPessoa.Cadastros.Dominio.Entidades.ObjetosDeValor;
using CRUDPessoa.Core.DominioBase;

namespace CRUDPessoa.Cadastros.Dominio.Entidades
{
    public class Pessoa : Entidade, IRaizAgregacao
    {
        protected Pessoa() { }

        public Pessoa(string nome, string email, Documento documento)
        {
            Nome = nome;
            Email = email;
            Documento = documento;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public Documento Documento { get; private set; }

        public void Atualizar(string nome, string email, Documento documento)
        {
            Nome = nome;
            Email = email;
            Documento = documento;
        }
    }
}
