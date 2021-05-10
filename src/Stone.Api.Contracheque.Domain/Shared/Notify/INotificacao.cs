using System.Collections.Generic;

namespace Stone.Api.Contracheque.Domain.Shared.Notify
{
    public interface INotificacao
    {
        public bool Invalido { get; }
        public bool Valido { get; }
        public IReadOnlyCollection<Notificacao> Notificacoes { get; }
        void AdicionaNotificacao(Notificacao notificacao);
        void AdicionaNotificacoes(IList<Notificacao> notificacoes);
        void AdicionaNotificacao(string message);
    }
}
