using System.Collections.Generic;
using System.Linq;

namespace Stone.Api.Contracheque.Domain.Shared.Notify
{
    public class Notificador : INotificacao
    {
        private readonly List<Notificacao> _notificacoes;
        public Notificador() => _notificacoes = new List<Notificacao>();
        public IReadOnlyCollection<Notificacao> Notificacoes => _notificacoes;

        public bool Invalido => _notificacoes.Any();
        public bool Valido => !Invalido;

        public void AdicionaNotificacao(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public void AdicionaNotificacoes(IList<Notificacao> notificacoes)
        {
            _notificacoes.AddRange(notificacoes);
        }

        public void AdicionaNotificacao(string message)
        {
            _notificacoes.Add(new Notificacao(message));
        }
    }
}
