using System;
using System.Collections.Generic;
using CRUDPessoa.Core.Mensagens.Eventos;

namespace CRUDPessoa.Core.DominioBase
{
    public abstract class Entidade
    {
        private List<Evento> _eventos;
        public IReadOnlyCollection<Evento> Eventos => _eventos?.AsReadOnly();

        protected Entidade()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public void AdicionarEvento(Evento evento)
        {
            _eventos ??= new List<Evento>();
            _eventos.Add(evento);
        }

        public void LimparEventos() => _eventos?.Clear();

        public void RemoverEvento(Evento evento) => _eventos?.Remove(evento);
    }
}
