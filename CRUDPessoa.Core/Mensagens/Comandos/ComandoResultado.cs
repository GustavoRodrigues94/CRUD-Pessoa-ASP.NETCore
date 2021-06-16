namespace CRUDPessoa.Core.Mensagens.Comandos
{
    public class ComandoResultado : IComandoResultado
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Dado { get; set; }

        public ComandoResultado(bool sucesso, string mensagem, object dado)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Dado = dado;
        }
    }
}
